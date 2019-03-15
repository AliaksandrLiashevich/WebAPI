using Microsoft.EntityFrameworkCore;
using DAL.Configurations;
using DAL.Interfaces.Entities;

namespace DAL.Context
{
    public class DALContext : DbContext
    {
        public DbSet<DataAccessCategory> Categories { get; set; }

        public DbSet<DataAccessProduct> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebDb;Trusted_Connection=True;ConnectRetryCount=0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataAccessCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DataAccessProductConfiguration());

            #region DataAccessCategorySeed
            modelBuilder.Entity<DataAccessCategory>().HasData(
                new DataAccessCategory() { Name = "Bicycling", Code = "BICYC" });
            modelBuilder.Entity<DataAccessCategory>().HasData(
                new DataAccessCategory() { Name = "Martial arts", Code = "MARAR" });
            modelBuilder.Entity<DataAccessCategory>().HasData(
                new DataAccessCategory() { Name = "Fitness", Code = "FITSS" });
            #endregion

            #region DataAccessProductSeed
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 1, Name = "Brakes", Quantity = 10, Price = 50 });
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 1, Name = "Drivetrain", Quantity = 4, Price = 82.3m});
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 1, Name = "Fork", Quantity = 36, Price = 100.25m });

            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 2, Name = "Kimono", Quantity = 200, Price = 15.6m });
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 2, Name = "Boxing gloves", Quantity = 512, Price = 5.5m });
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 2, Name = "Boxing helmet", Quantity = 123, Price = 20 });

            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 3, Name = "Fitness mat", Quantity = 56, Price = 12.32m });
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 3, Name = "Hoop", Quantity = 312, Price = 12.5m });
            modelBuilder.Entity<DataAccessProduct>().HasData(
                new DataAccessProduct() { CategoryId = 3, Name = "Fitball", Quantity = 33, Price = 6.3m });
            #endregion
        }
    }
}
