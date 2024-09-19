using csula.labs.HW2.Services;
using Microsoft.EntityFrameworkCore;

/*
 * Middleware and Dependency Injection
 * Steps to go through lab
 * 1. Service Registration
 * 2. Contructor Injection  (See Vaccine Controller)  
 * 
 * 
 * Two Needed Dependcies 
 * 1. Microsoft.EntityFrameworkCore.SqlServer
 * 2. Microsoft.EntityFrameworkCore.Design
 * Right click project >  Manage NuGet Packages 
 * 
 * 
 * Service Colletion Using the Database
 * 1. Create Implementation from the VaccineService Interface (See under Services)
 * 2. appsetting.json > see the ConnectionString Setup 
 * 3. Main program, see below: use Services and scoped 
 * 
 * 
 * Understanding Action MEthod
 * 1. Lookinto Vaccines Controller for more documentation 
 */
namespace csula.labs.HW2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        
        //Accessing the Database
        /*
         * AppDbContext is registered as a scoped service 
         * Configuration from appsettings.kjosn is automatically loaded and injected into Main 
         */
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer (
           builder.Configuration.GetConnectionString ("DefaultConnection"))
        );

        /*
         * Cannot use a Singleton for VaccineService
         * This is because VaccineService has its own dependency (See under Services > Vaccine Service)
         * Avoid Captured Dependecy
         */
        builder.Services.AddScoped<IVaccineService, VaccineService>();
        builder.Services.AddScoped<IPatientService, PatientService>();




        /*
         *Service Registration Example CheckList
         * 
         * 1. Create model class: Vaccine
         *      See Vaccine Model class
         * 2. Create interface: IVaccineService 
         *      See under Service dir
         * 3. Create implementation for Interface 
         *      SEe Under Service dir
         * 4  Register with service Colletion 
         * 
         * 
         * Service Lifetime (how long the service will live;  will live as long as the software is running)
         * Transient
         *  - new instance of the service is created whenever the service is required 
         * Scoped 
         *  - the same instance of the service will be used through the processing of a requests
         *  - a different instance will used for a different request 
         * Singleton 
         *  - the same instance will used for all requuest 
         *
         */


        //using the interface and implementation / Service Registration part 
        //First argument: the type of service registered
        //builder.Services.AddSingleton<IVaccineService, MockVaccineService>();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
     
        app.UseHttpsRedirection();
        
        
        app.UseStaticFiles();

        app.UseRouting();

        //rapp.UseAuthorization();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
