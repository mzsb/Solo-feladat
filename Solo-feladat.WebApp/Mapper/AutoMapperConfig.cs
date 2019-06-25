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
                cfg.CreateMap<Solo_feladat.BLL.Dtos.Pilot, Pilot>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
