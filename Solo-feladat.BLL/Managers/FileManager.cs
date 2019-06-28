using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public class FileManager : IFileManager
    {
        private readonly SoloContext context;

        public FileManager(SoloContext context)
        {
            this.context = context;
        }

        public async Task<bool> InsertFilesAsync(List<Solo_feladat.Model.Models.File> files)
        {
            foreach (var f in files)
            {
                await context.Files.AddAsync(f);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public void SaveDataFromFile()
        {
            List<Solo_feladat.Model.Models.File> files = context.Files.ToList();

            if (files.Count > 0)
            {
                foreach (var f in files)
                {
                    if (f.Type.Equals(FileType.Airport))
                    {
                        ProcessAirportFile(f);
                    }
                    else if (f.Type.Equals(FileType.Log))
                    {
                        ProcessLogFile(f);
                    }
                }

                if(context.SaveChanges() > 0)
                {
                    foreach (var f in context.Files)
                    {
                        context.Files.Remove(f);
                    }

                    context.SaveChanges();
                }
            }
        }


        /* Excel feldolgozas */

        private void ProcessAirportFile(Solo_feladat.Model.Models.File file)
        {
            var excelData = GetExcelDataFromFile(file);

            var airports = GetAirportsFromExcelData(excelData);

            foreach (var a in airports)
            {
                if (!context.Airports.Select(ai => ai.Name).Contains(a.Name))
                    context.Airports.AddAsync(a);
            }
        }

        private List<List<String>> GetExcelDataFromFile(Solo_feladat.Model.Models.File file)
        {
            List<List<string>> excelData = new List<List<string>>();

            using (MemoryStream stream = new MemoryStream(file.Data))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        List<string> rowData = new List<string>();

                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                rowData.Add(worksheet.Cells[i, j].Value.ToString());
                            }
                        }

                        excelData.Add(rowData);
                    }
                }
            }

            return excelData;
        }

        private List<Airport> GetAirportsFromExcelData(List<List<string>> excelData)
        {
            List<Airport> airports = new List<Airport>();

            //Fejlec eltavolitasa
            excelData.RemoveAt(0);

            foreach (var i in excelData)
            {
                airports.Add(
                    new Airport
                    {
                        Name = i[0],
                        Coordinate = new Coordinate
                        {
                            LatitudeCoord = float.Parse(i[1]),
                            LongitudeCoord = float.Parse(i[2])
                        }
                    }
                );
            }

            return airports;
        }


        /* Log feldolgozas */

        private void ProcessLogFile(Solo_feladat.Model.Models.File file)
        {
            string logData = Encoding.UTF8.GetString(file.Data);

            List<string> log = logData.Split("\r\n").ToList();

            Flight flight = new Flight();

            flight.Date = EncodeDate(log.ElementAt(1));
        }

        private DateTime EncodeDate(string row)
        {
            return DateTime.Now;
        }


    }
}
