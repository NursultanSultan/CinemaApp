using CinemaApp.DataAcces.Configurations;
using CinemaApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MovieCinema> MovieCinemas { get; set; }
        public DbSet<MovieSession> MovieSessions { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieFormat> MovieFormats{ get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaConfiguration());
            modelBuilder.ApplyConfiguration(new FormatConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
