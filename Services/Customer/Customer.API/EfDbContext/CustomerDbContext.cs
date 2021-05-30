using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Customer.API.EfDbContext
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Entities.Customer> Customer { get; set; }

        public CustomerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuation = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var connectionString = configuation.Build().GetSection("connectionString").GetSection("DefaultConnection").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Customer>().ToTable("Customer");//puvyazka tabluci People do User
                /*.Property(u => u.Id).HasColumnName("Id");*///puklad perevuznacenya spivstavlenya stovpcya
            //  modelBuilder.Entity<User>().HasKey(u => u.Ident);                                           //pruklad vstanovlenya kluca
            //  modelBuilder.Entity<User>().HasKey(u => new { u.PassportSeria, u.PassportNumber});          //pruklad stvorenya kluca z dekilkox vlastuvostey
            //  modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("UsersPrimaryKey");                   //pruklad nalashtuvanya IMYA obmejenya, uake zadayetsya dlya primary key
            //  modelBuilder.Entity<User>().HasAlternateKey(u => u.Passport);                               //pruklad stvorenya alternatuvnogo klyuca
            //  modelBuilder.Entity<User>().HasAlternateKey(u => new { u.Passport, u.PhoneNumber });        //pruklad stvorenya alternatuvnux klyuciv
            //  modelBuilder.Entity<User>().HasIndex(u => u.Passport);                                      //pruklad vstanovlenya indexsu
            //  modelBuilder.Entity<User>().HasIndex(u => u.Passport).IsUnique();                           //pruklad vstanovlenya indexsu yakuy maye bytu ynicalnum
            //  modelBuilder.Entity<User>().HasIndex(u => new { u.Passport, u.PhoneNumber });               //pruklad vstanovlenya indexsiv dlya dekilkoh vlastuvostey
            //  modelBuilder.Entity<User>().HasIndex(u => u.PhoneNumber).HasDatabaseName("PhoneIndex");     //pruklad vstanovlenya imya indexsa
            //  modelBuilder.Entity<User>().HasIndex(u => u.PhoneNumber).HasFilter("[PhoneNumber] IS NOT NULL");
        }
    }
}
