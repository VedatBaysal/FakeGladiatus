using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities.DbEntities
{
    public class FakeGladiatusDbContext : DbContext
    {
        public FakeGladiatusDbContext(DbContextOptions<FakeGladiatusDbContext> options) : base(options)
        {
                
        }
        public FakeGladiatusDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FakeGladiatus;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<UserDbEntity> Users { get; set; }
        public DbSet<CharacterDbEntity> Characters { get; set; }
    }
}
