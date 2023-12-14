using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiquetCine.Models;

namespace TiquetCine.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorPelicula>().HasKey(am => new
            {
                am.ActorId,
                am.PeliculaId
            });

            modelBuilder.Entity<ActorPelicula>().HasOne(m => m.Pelicula).WithMany(am => am.ActorPeliculas).HasForeignKey(m => m.PeliculaId);
            modelBuilder.Entity<ActorPelicula>().HasOne(m => m.Actor).WithMany(am => am.ActorPeliculas).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }

        internal Task GetAllAsync(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<ActorPelicula> ActorPeliculas { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Productor> Productors { get; set; }

    }
}
