using CinemaApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Configurations
{
    public class FormatConfiguration : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> builder)
        {
            builder.Property(f => f.FormatType).IsRequired();
        }
    }
}
