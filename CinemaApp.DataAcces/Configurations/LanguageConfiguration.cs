using CinemaApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(l => l.Lang).IsRequired();
            builder.Property(l => l.LangIconUrl).IsRequired();
            builder.Ignore(l => l.LangIconFile);
            
        }
    }
}
