using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ClinicaEntity;

namespace ClinicaAPI.Models
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<InCita, Cita>();
                //cfg.CreateMap<Department, OutDepartmentModel>();
            });
        }
    }
}