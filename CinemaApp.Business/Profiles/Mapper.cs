using AutoMapper;
using CinemaApp.Business.DTOs;
using CinemaApp.Business.DTOs.CategoryDtos;
using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Profiles
{
    class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<MovieCreateDto, Movie>()
                    .ForMember(x => x.PosterFile, opt => opt.Ignore())
                    .ForMember(x => x.BackgroundImgFile, opt => opt.Ignore());

            CreateMap<Category, CategoryReadDto>();
                   
            CreateMap<CategoryCreateDto, Category>()
                   .ForMember(x => x.CategoryPhoto, opt => opt.Ignore());
                   



        }
    }
}
