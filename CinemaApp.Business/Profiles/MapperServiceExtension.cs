using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Profiles
{
    public static class MapperServiceExtension
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            }).CreateMapper());
        }
        
    }
}
