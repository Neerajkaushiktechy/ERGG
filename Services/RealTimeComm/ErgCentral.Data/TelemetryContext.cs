using ErgCentral.Data.Base;
using ErgCentral.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace ErgCentral.Data
{
    public sealed class TelemetryContext : DbContext
    {
        public TelemetryContext(DbContextOptions<TelemetryContext> options) : base(options)
        {
            ChangeTracker.Tracked += OnTracked;
            ChangeTracker.StateChanged += OnStateChanged;
        }

        public DbSet<Distance> Distance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Distance>().Property(d => d.ParticipantName).HasMaxLength(20);
            modelBuilder.Entity<Distance>().Property(d => d.RaceId).HasMaxLength(10);
        }

        #region Private Methods

        private void OnStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is IHasCreatedLastModified entity)
            {
                entity.LastModified = DateTime.Now;
            }
        }

        private void OnTracked(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added
                             && e.Entry.Entity is IHasCreatedLastModified entity
                             && entity.Created == default)
            {
                entity.Created = DateTime.Now;
            }
        }

        #endregion Private Methods
    }
}