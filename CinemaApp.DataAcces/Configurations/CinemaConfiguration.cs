using CinemaApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(ci => ci.CinemaName).IsRequired();

            builder.Property(ci => ci.ShortContent).IsRequired().HasMaxLength(255);

            builder.Property(ci => ci.CinemaPosterURL).IsRequired();

            builder.Ignore(ci => ci.CinemaPosterPhoto);

            builder.Property(ci => ci.OurAdress).IsRequired();

            builder.Property(ci => ci.PhoneNumber).IsRequired();

            builder.Property(ci => ci.MapLocation).IsRequired();

            builder.Property(ci => ci.EMail).IsRequired();

        }
    }
}
