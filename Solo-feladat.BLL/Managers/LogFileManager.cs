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
    public class LogFileManager : FileManager, ILogFileManager
    {
        private readonly SoloContext context;

        public LogFileManager(SoloContext context) : base(context)
        {
            this.context = context;
        }

        public override void ProcessFile(Model.Models.File file)
        {
            if (file.Type.Equals(FileType.Log))
            {
                string logData = Encoding.UTF8.GetString(file.Data);

                List<string> log = logData.Split("\r\n").ToList();

                Flight flight = new Flight();

                flight.Status = FlightStatus.Wait;

                flight.AppUserId = file.AppUserId;

                var dateRow = log.ElementAt(1);

                dateRow = dateRow.Substring(Math.Max(0, dateRow.Length - (3 * 2)));

                flight.Date = GetDateTime(dateRow, "ddMMyy");

                List<string> fixes = GetFixes(log);

                flight.Duration = GetDuration(fixes);

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
                    AirportId = context.Airports
                                       .Include(a => a.Coordinate)
                                       .Where(a =>
                                        CalculateDistance(a.Coordinate, flight.Coordinates.LastOrDefault()) < 3000.0)
                                       .FirstOrDefault().Id
                });

                flight.AirportFlights.Add(new AirportFlight
                {
                    Type = AirportType.Landing,
                    Airport = context.Airports
                                     .Include(a => a.Coordinate)
                                     .Where(a => CalculateDistance(a.Coordinate, flight.Coordinates.LastOrDefault()) < 3000.0)
                                     .FirstOrDefault()
                                     ?? 
                                     context.Airports
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
                                     }
                });

                context.Flights.Add(flight);
            }
        }

        private DateTime GetDateTime(string row, string format)
        {
            return DateTime.ParseExact(row, format, CultureInfo.InvariantCulture);
        }

        private TimeSpan GetDuration(List<string> fixes)
        {
            return GetDateTime(fixes.Last().Substring(0, 2 * 3), "HHmmss") - 
                   GetDateTime(fixes.First().Substring(0, 2 * 3), "HHmmss");
        }

        private double GetLatitudeCoord(string fix)
        {
            fix = fix.Substring(6,7);

            var c = fix.Substring(2, 2) + "." + fix.Substring(4, 3);

            return double.Parse(fix.Substring(0,2)) + (double.Parse(fix.Substring(2, 2) + "," + fix.Substring(4, 3)) / 60.0);
        }

        private double GetLongitudeCoord(string fix)
        {
            fix = fix.Substring(14, 8);

            return double.Parse(fix.Substring(0, 3)) + (double.Parse(fix.Substring(3, 2) + "," + fix.Substring(5,3)) / 60.0);
        }

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

            return dist * 1609.344; // Méterben adja vissza a távolságot
        }


        private List<string> GetFixes(List<string> logData)
        {
            List<string> fixes = new List<string>();

            foreach (var row in logData.Where(r => r.FirstOrDefault().Equals('B')))
            {
                fixes.Add(row.Substring(1,23));
            }

            return fixes;
        }

    }
}
