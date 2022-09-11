using BaseTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class StorageDbContext : DbContext
    {
        public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var storageOne = new
            {
                StorageId = Guid.NewGuid(),
                StorageFormationDate = DateTime.Now.AddDays(-11),
                Areas = new List<Area>()
            };

            var area1 = new
            {
                AreaId = Guid.NewGuid(),
                StorageId = storageOne.StorageId,
                Title = "101-104",
                AreaFormationDate = DateTime.Now.AddDays(-11)
            };       
            
            var area2 = new
            {
                AreaId = Guid.NewGuid(),
                StorageId = storageOne.StorageId,
                Title = "105",
                AreaFormationDate = DateTime.Now.AddDays(-11)
            };

            var storageTwo = new
            {
                StorageId = Guid.NewGuid(),
                StorageFormationDate = DateTime.Now.AddDays(-11),
                Areas = new List<Area>()
            };

            var area3 = new
            {
                AreaId = Guid.NewGuid(),
                StorageId = storageTwo.StorageId,
                Title = "201-202",
                AreaFormationDate = DateTime.Now.AddDays(-11)
            };            
            
            var area4 = new
            {
                AreaId = Guid.NewGuid(),
                StorageId = storageTwo.StorageId,
                Title = "203-205",
                AreaFormationDate = DateTime.Now.AddDays(11)
            };

            var pic101 = new 
            { 
                AreaId = area1.AreaId, 
                Title = "101", 
                PicketId = Guid.NewGuid()
            };            
            
            var pic102 = new 
            { 
                AreaId = area1.AreaId, 
                Title = "102", 
                PicketId = Guid.NewGuid()
            };            
            
            var pic103 = new 
            { 
                AreaId = area1.AreaId, 
                Title = "103", 
                PicketId = Guid.NewGuid()
            };            
            
            var pic104 = new 
            { 
                AreaId = area1.AreaId, 
                Title = "104", 
                PicketId = Guid.NewGuid()
            };            
            
            var pic105 = new 
            { 
                AreaId = area2.AreaId, 
                Title = "105", 
                PicketId = Guid.NewGuid()
            };            
            
            var pic201 = new 
            { 
                AreaId = area3.AreaId, 
                Title = "201", 
                PicketId = Guid.NewGuid()
            };            
            
            var pic202 = new 
            { 
                AreaId = area3.AreaId, 
                Title = "202", 
                PicketId = Guid.NewGuid()
            };

            var pic203 = new
            {
                AreaId = area3.AreaId,
                Title = "203",
                PicketId = Guid.NewGuid()
            };

            var pic204 = new
            {
                AreaId = area4.AreaId,
                Title = "204",
                PicketId = Guid.NewGuid()
            };

            var pic205 = new
            {
                AreaId = area4.AreaId,
                Title = "205",
                PicketId = Guid.NewGuid()
            };

            var c1 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic101.PicketId,
                Type = CargoType.Powdered,
                Title = "Coal",
                Weight = 3000,
                ShipmentDate = DateTime.Now.AddDays(-10), 
                UnloadingDate = DateTime.Now.AddDays(-5)
            };            
            
            var c2 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic102.PicketId, 
                Type = CargoType.Powdered, 
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 10000
            };            
            
            var c3 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic103.PicketId, 
                Type = CargoType.Powdered, 
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 10000
            };            
            
            
            var c4 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic104.PicketId, 
                Type = CargoType.Powdered, 
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 30000
            };            
            
            var c5 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic105.PicketId, 
                Type = CargoType.Powdered, 
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 5000
            };

            var c6 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic201.PicketId,
                Type = CargoType.Powdered,
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 4000
            };            
            
            var c7 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic202.PicketId,
                Type = CargoType.Powdered,
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 4000
            };

            var c8 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic203.PicketId,
                Type = CargoType.Powdered,
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 5000
            };

            var c9 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic204.PicketId,
                Type = CargoType.Powdered,
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 5000
            };

            var c10 = new
            {
                Id = Guid.NewGuid(),
                PicketId = pic205.PicketId,
                Type = CargoType.Powdered,
                Title = "Coal",
                ShipmentDate = DateTime.Now.AddDays(-10),
                UnloadingDate = DateTime.Now.AddDays(-5),
                Weight = 5000
            };


            modelBuilder.Entity<Storage>()
                .HasData(storageOne, storageTwo);

            modelBuilder.Entity<Area>()
                .HasData(area1, area2, area3, area4);

            modelBuilder.Entity<Picket>()
                .HasData(pic101, pic102, pic103, pic104, pic105, pic201, pic202, pic203, pic204, pic205);

            modelBuilder.Entity<Cargo>()
                .HasData(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);
        }


        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Picket> Pickets { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
    }
}
