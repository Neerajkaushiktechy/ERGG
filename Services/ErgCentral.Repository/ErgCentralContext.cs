using ErgCentral.Repository.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Repository
{
    public class ErgCentralContext : IdentityDbContext
    {

        #region Constructor
        public ErgCentralContext(DbContextOptions<ErgCentralContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Races> Races { get; set; }
        public DbSet<Participants> Participants { get; set; }
        #endregion
        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Public methods
        public override int SaveChanges()
        {
            return base.SaveChanges(true);
        }
        #endregion
    }
}
