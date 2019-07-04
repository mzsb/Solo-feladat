using Microsoft.EntityFrameworkCore;
using Solo_feladat.Model.Models;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public class LogFileManager
    {
        private readonly SoloContext context;

        public LogFileManager(SoloContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// A parameterkent kapott Filet feldolgozza es az igy kapott Flightot menti az adatbazisba.
        /// </summary>
        /// <param name="file">Feldolgozando File</param>
        /// <returns>Igaz az adatok sikeres mentese eseten, egyebkent hamis</returns>
        public async Task<bool> ProcessFile(File file)
        {
            var flight = GetFlightFromLogFile(file);

            context.Flights.Add(flight);

            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// A parameterkent kapott Filebol kinyeri egy Flight adatait
        /// </summary>
        /// <param name="excelData">Feldolgozando File</param>
        /// <returns>A kinyert Flight</returns>
        private Flight GetFlightFromLogFile(File file)
        {
            string logData = Encoding.UTF8.GetString(file.Data);

            List<string> log = logData.Split("\r\n").ToList();

            Flight flight = new Flight();

            flight.Status = FlightStatus.Wait;

            flight.AppUserId = file.AppUserId;

            var dateRow = log.ElementAt(1);

            dateRow = dateRow.Substring(Math.Max(0, dateRow.Length - (2 * 3)));

            flight.Date = GetDateTime(dateRow, "ddMMyy");

            List<string> fixes = GetFixes(log);

            flight.Duration = GetDuration(fixes, "HHmmss");

            foreach (var f in fixes)
            {
                flight.Coordinates.Add(new Coordinate
                {
                    LatitudeCoord = GetLatitudeCoord(f),
                    LongitudeCoord = GetLongitudeCoord(f)
                });
            }

            flight.AirportFlights.Add(new AirportFlight
            {
                Type = AirportType.Takeoff,
                Airport = context.Airports
                                   .Include(a => a.Coordinate)
                                   .Where(a =>
                                    CalculateDistance(a.Coordinate, flight.Coordinates.FirstOrDefault()) < 3000.0)
                                   .FirstOrDefault()
                                   ??
                                   GetField()
            });

            flight.AirportFlights.Add(new AirportFlight
            {
                Type = AirportType.Landing,
                Airport = context.Airports
                                 .Include(a => a.Coordinate)
                                 .Where(a => CalculateDistance(a.Coordinate, flight.Coordinates.LastOrDefault()) < 3000.0)
                                 .FirstOrDefault()
                                 ??
                                 GetField()
            });

            return flight;
        }

        /// <summary>
        /// Két Coordinate kozti tavolsagot szamolja ki meterben.
        /// </summary>
        /// <param name="start">Elso Coordinate</param>
        /// <param name="end">Masodik Coordinate</param>
        /// <returns>Az elso es masodik Coordinate kozti tavolsag meterben</returns>
        public double CalculateDistance(Coordinate start, Coordinate end)
        {
            double rlat1 = Math.PI * start.LatitudeCoord / 180;
            double rlat2 = Math.PI * end.LatitudeCoord / 180;
            double theta = start.LongitudeCoord - end.LongitudeCoord;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.344;
        }

        /// <summary>
        /// Parameterkent kapott GPS logfajbol fixeket nyer ki.
        /// </summary>
        /// <param name="logData">A GPS logfajl</param>
        /// <returns>Kinyert fixek</returns>
        private List<string> GetFixes(List<string> logData)
        {
            List<string> fixes = new List<string>();

            foreach (var row in logData.Where(r => r.FirstOrDefault().Equals('B')))
            {
                fixes.Add(row.Substring(1,23));
            }

            return fixes;
        }

        /// <summary>
        /// Egy parameterkent kapott datum logfajlsorbol parameterkent kapott formatumu DateTimeot general
        /// </summary>
        /// <param name="row">Datum logfilesor</param>
        /// <param name="format">Datum formatum</param>
        /// <returns>A formazott DateTime</returns>
        private DateTime GetDateTime(string row, string format)
        {
            return DateTime.ParseExact(row, format, CultureInfo.InvariantCulture);
        }

        private TimeSpan GetDuration(List<string> fixes, string format)
        {
            return GetDateTime(fixes.Last().Substring(0, 2 * 3), format) -
                   GetDateTime(fixes.First().Substring(0, 2 * 3), format);
        }

        private double GetLatitudeCoord(string fix)
        {
            fix = fix.Substring(6, 7);

            return double.Parse(fix.Substring(0, 2)) + (double.Parse(fix.Substring(2, 2) + 
                                                       "," + 
                                                       fix.Substring(4, 3)) / 60.0);
        }

        private double GetLongitudeCoord(string fix)
        {
            fix = fix.Substring(14, 8);

            return double.Parse(fix.Substring(0, 3)) + (double.Parse(fix.Substring(3, 2) + 
                                                       "," + 
                                                       fix.Substring(5, 3)) / 60.0);
        }

        private Airport GetField()
        {
            return context.Airports
                          .Where(a => a.Name.Equals("Terep"))
                          .FirstOrDefault()
            ??
            new Airport
            {
                Name = "Terep",
                Coordinate = new Coordinate
                {
                    LatitudeCoord = -1.0,
                    LongitudeCoord = -1.0
                }
            };
        }
    }
}
