using Microsoft.EntityFrameworkCore;
using csula.labs.HW2.Models;
using Microsoft.Extensions.Configuration.EnvironmentVariables;


namespace csula.labs.HW2.Services
{
    public class AppDbContext : DbContext
    {
        /*7
        //Configuiring the Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Checking the config through terminal

            Console.WriteLine(config["DefaultConnection"]);

            optionsBuilder
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies();
        }

        */

        public AppDbContext(DbContextOptions<AppDbContext> options) : base( options) { }    

        public DbSet<Vaccine> Vaccines { get; set; }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.VaccineCompany)
                .WithMany(v => v.Patients)
                .HasForeignKey(p => p.VaccineCompanyId);
        }

    }
}
