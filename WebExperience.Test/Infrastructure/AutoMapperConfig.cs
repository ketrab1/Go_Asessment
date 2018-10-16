using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralKnowledge.Test.App.Domain.Model;
using WebExperience.Test.Models;

namespace WebExperience.Test.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Asset, AssetDto>().ForMember(d => d.Country, x => x.MapFrom(d => d.Country.Name))
                    .ForMember(d => d.MimeType, x => x.MapFrom(d => d.MimeType.Type));
               
            });
        }
    }
}