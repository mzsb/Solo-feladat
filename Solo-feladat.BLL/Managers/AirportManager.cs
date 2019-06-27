using OfficeOpenXml;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public class AirportManager : IAirportManager
    {
        private readonly SoloContext context;

        public AirportManager(SoloContext context)
        {
            this.context = context;
        }

        public async Task InsertAirportAsync(Airport airport)
        {
            await context.Airports.AddAsync(airport);

            await context.SaveChangesAsync();
        }

        public async Task InsertAirportFilesAsync(List<AirportFile> airportFile)
        {
            foreach (var af in airportFile)
            {
                await context.AirportFiles.AddAsync(af);

                var excelData = GetExcelDataAsync(af);

                var airports = GetAirportsFromExcelDataAsync(excelData);

                foreach (var a in airports)
                {
                    await InsertAirportAsync(a);
                }
            }

            await context.SaveChangesAsync();
        }

        private List<Airport> GetAirportsFromExcelDataAsync(List<List<string>> excelData)
        {
            List<Airport> airports = new List<Airport>();

            excelData.RemoveAt(0);

            foreach (var i in excelData)
            {
                airports.Add(
                    new Airport
                    {
                        Name = i[0],
                        LatitudeCoord = float.Parse(i[1]),
                        LongitudeCoord = float.Parse(i[2])
                    }    
                );
            }

            return airports;
        }

        private List<List<String>> GetExcelDataAsync(AirportFile airportFile)
        {
            List<List<string>> excelData = new List<List<string>>();

            using (MemoryStream stream = new MemoryStream(airportFile.File))
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
    }
}
