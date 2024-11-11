using Company.e_Tickets.DAL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.e_Tickets.DAL.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>  /*DbContext + 7 DbSets [Users , Roles] */
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Has Composite Primary Key 
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.MovieId, am.ActorId });

            modelBuilder.Entity<Actor_Movie>().
                HasOne(am => am.Actor).
                WithMany(am => am.Actor_Movie).
                HasForeignKey(am => am.ActorId);


            modelBuilder.Entity<Actor_Movie>().
              HasOne(am => am.Movie).
              WithMany(am => am.Actor_Movies).
              HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<IdentityUserRole<string>>()
        .HasKey(r => new { r.UserId, r.RoleId });

            
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(x => new { x.LoginProvider, x.ProviderKey });

           
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie>  Actor_Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }


    }
}
