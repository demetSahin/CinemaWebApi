using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Context
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext>options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MovieEntity>().HasQueryFilter(x => x.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    }
}
