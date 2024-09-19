using csula.labs.HW2.Services;
using csula.labs.HW2.Models; 
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace csula.labs.HW2.Controllers
{

    /*
     *  This is where the Constructor Injection  happens  
     *  
     *  _vaccineService will hold that value/object that will be injected to the interface 
     * 
     */
    public class VaccinesController : Controller
    {
        //
        private readonly IVaccineService _vaccineService; 

        public VaccinesController(IVaccineService vaccineService)
        {
            //The instance is coming from the framework
            //Note we do not have instiantiate an object because the framework will do it for us 
            _vaccineService = vaccineService;
        }


        /*
         * Aciton Method
         * 
         * What is really returning in return View(...)
         *      - ControllerBase Class
         *          - Contains helper methods such as redirect 
         *      - Controller Class
         *          - inherits from ControllerBase
         *          - MVC inherits from this class 
         *          - Example is View (helper method) 
         *          
         * 
         * ViewData and View Bag
         *      -Answer the question if have to pass one or more model 
         *      -ViewData 
         *          - ViewData["Name"] = "CS45_60"; 
         *          - to use in view, reference using the key: <h2>ViewData["Name"]...
         *          - if more than on object, use the special way to cast in view 
         */
        public IActionResult Index()
        {
            return View(_vaccineService.GetVaccines());
        }



        //Action: DisplayForm 
        //EDIT 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_vaccineService.GetVaccine(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, Vaccine update)
        {
            var vaccine = _vaccineService.GetVaccine(id);
            
            //Updating the object within the database
            vaccine.Name = update.Name;
            vaccine.DosesRequired = update.DosesRequired;
            vaccine.DosesInBetween = update.DosesInBetween;
            vaccine.DosesRecieved = update.DosesRecieved;
            vaccine.TotalDosesLeft = update.TotalDosesLeft;

            //Save the changes
            _vaccineService.SaveChanges();

            //Redirect back to Vaccine Pages
            return RedirectToAction("Index");
        }




        //Action: DisplayForm 
        //ADD: adding  a new vaccine to the database and displaying it to view 
        [HttpGet]
        public IActionResult AddVaccine()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddVaccine(Vaccine nVaccine)
        {
            //Add the vaccine 
            _vaccineService.AddVaccine(nVaccine);

            //Redirect back to Vaccine Pages
            return RedirectToAction("Index");

        }




        //ADD: adding  a new vaccine to the database and displaying it to view 
        [HttpGet]
        public IActionResult NewDoses()
        {   
            //Displaying as List (drop down select list option)
            ViewBag.Vaccines = _vaccineService.GetVaccines()
                .Select(e => new SelectListItem(e.Name, e.Id.ToString()))
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult NewDoses(int id, Vaccine update)
        {

            var vaccine = _vaccineService.GetVaccine(id);

            //Updating the object within the database
           
            vaccine.DosesRecieved = vaccine.DosesRecieved + update.DosesRecieved;
            vaccine.TotalDosesLeft = vaccine.TotalDosesLeft + update.DosesRecieved;

            //Save the changes
            _vaccineService.SaveChanges();

            //Redirect back to Vaccine Pages
            return RedirectToAction("Index");

        }

    }//End of Vaccine Controller class

}//End of namepsace
