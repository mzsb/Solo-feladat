using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Helper
{
    public static class FlightStatusHelper
    {
        public static FlightStatus ToFlightStatus(this string str)
        {
            if (str.Equals(FlightStatus.Wait.ToString()))
            {
                return FlightStatus.Wait;
            }
            else if (str.Equals(FlightStatus.Accepted.ToString()))
            {
                return FlightStatus.Accepted;
            }
            else if (str.Equals(FlightStatus.Denied.ToString()))
            {
                return FlightStatus.Denied;
            }
            else
            {
                return FlightStatus.Wait | FlightStatus.Accepted | FlightStatus.Denied;
            }
        }
    }
}
