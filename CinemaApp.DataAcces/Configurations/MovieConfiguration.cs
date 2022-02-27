using CinemaApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.MovieName).IsRequired().HasMaxLength(255);

            builder.Property(m => m.AgeLimit).IsRequired();

            builder.Property(m => m.PosterUrl).IsRequired();
            builder.Ignore(m => m.PosterFile);

            builder.Property(m => m.BackgroundImgUrl).IsRequired();
            builder.Ignore(m => m.BackgroundImgFile);

            builder.Property(m => m.TrailerUrl).IsRequired();
            

            builder.Property(m => m.Price).IsRequired();


            builder.Property(m => m.AboutContent).IsRequired().HasMaxLength(255);

            builder.Property(m => m.Country).IsRequired().HasMaxLength(255);

            builder.Property(m => m.Director).IsRequired().HasMaxLength(255);

            builder.Property(m => m.Duration).IsRequired();
        }
    }
}
