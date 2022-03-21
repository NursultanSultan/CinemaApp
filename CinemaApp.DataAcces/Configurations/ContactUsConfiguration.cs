using CinemaApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Configurations
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.Property(c => c.UserMail).IsRequired();

            builder.Property(c => c.Subject).IsRequired().HasMaxLength(255);

            builder.Property(c => c.Message).IsRequired().HasMaxLength(255);


        }
    }
}
