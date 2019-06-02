using HeroesAndDragons.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.DL
{
    public class AppDbContext : IdentityDbContext<HeroEntity>
    {
        public DbSet<DragonEntity> Dragons { get; set; }
        public DbSet<HitEntity> Hits { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HitEntity>()
                .HasOne(h => h.Dragon)
                .WithMany(d => d.Hits)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HitEntity>()
                .HasOne(h => h.Hero)
                .WithMany(d => d.Hits)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
