using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ClinicaEntity;

namespace ClinicaMVC.Models
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<RegistroEnfermeriaModel, RegEnfermeriaViewModel>();
                x.CreateMap<RegEnfermeriaViewModel, RegistroEnfermeriaModel>();
            });
        }
        
    }
}