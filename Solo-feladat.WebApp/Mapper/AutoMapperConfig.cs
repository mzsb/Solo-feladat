using AutoMapper;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Mapper
{
    public class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, Solo_feladat.BLL.Dtos.Flight>()
                .ForMember(dto => dto.LandingAirport, opt => opt.Ignore())
                .ForMember(dto => dto.TakeOfAirport, opt => opt.Ignore())
                .AfterMap((d, dto, ctx) => {

                    dto.LandingAirport = ctx.Mapper.Map<Solo_feladat.BLL.Dtos.Airport>(
                        d.AirportFlights
                         .Where(dl => dl.Type.Equals(AirportType.Landing))
                         .Select(dl => dl.Airport)
                         .SingleOrDefault());

                    dto.TakeOfAirport = ctx.Mapper.Map<Solo_feladat.BLL.Dtos.Airport>(
                        d.AirportFlights
                         .Where(dl => dl.Type.Equals(AirportType.Takeoff))
                         .Select(dl => dl.Airport)
                         .SingleOrDefault());

                });

                cfg.CreateMap<Solo_feladat.BLL.Dtos.Flight, Flight>()
                .ForMember(d => d.AirportFlights, opt => opt.Ignore())
                .AfterMap((dto, d, ctx) => {

                    d.AirportFlights.Add(
                        new AirportFlight
                        {
                            AirportId = dto.TakeOfAirport.Id,
                            Type = AirportType.Takeoff
                        });

                    d.AirportFlights.Add(
                        new AirportFlight
                        {
                            AirportId = dto.LandingAirport.Id,
                            Type = AirportType.Landing
                        });
                });

                cfg.CreateMap<Solo_feladat.BLL.Dtos.Airport, Airport>().ReverseMap();

                cfg.CreateMap<Solo_feladat.BLL.Dtos.Coordinate, Coordinate>().ReverseMap();

                cfg.CreateMap<Solo_feladat.BLL.Dtos.AppUser, AppUser>().ReverseMap();

                cfg.CreateMap<Solo_feladat.BLL.Dtos.File, File>().ReverseMap();

            });


            return config.CreateMapper();
        }
    }
}
