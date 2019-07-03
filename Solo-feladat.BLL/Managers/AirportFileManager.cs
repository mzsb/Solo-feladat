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
    public class AirportFileManager
    {
        private readonly SoloContext context;

        public AirportFileManager(SoloContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// A parameterkent kapott Filet feldolgozza es az igy kapott Airportokat menti az adatbazisba.
        /// </summary>
        /// <param name="file">Feldolgozando File</param>
        /// <returns>Igaz az adatok sikeres mentese eseten, egyebkent hamis</returns>
        public bool ProcessFile(Model.Models.File file)
        {
            var excelData = GetExcelDataFromFile(file);

            var airports = GetAirportsFromExcelData(excelData);

            foreach (var a in airports)
            {
                if (!context.Airports.Select(ai => ai.Name).Contains(a.Name))
                    context.Airports.Add(a);
            }

            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// A parameterkent kapott Filet exceltablakent dolgozza fel.
        /// </summary>
        /// <param name="file">Feldolgozando File</param>
        /// <returns>Az excel fajl cellai</returns>
        private List<List<String>> GetExcelDataFromFile(Model.Models.File file)
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

        /// <summary>
        /// A parameterkent kapott excel cellakbol kinyeri az Airportok adatait
        /// </summary>
        /// <param name="excelData">Feldolgozando excel cellak</param>
        /// <returns>A kinyert Airportok</returns>
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
                            LatitudeCoord = double.Parse(i[1]),
                            LongitudeCoord = double.Parse(i[2])
                        }
                    }
                );
            }

            return airports;
        }
    }
}
