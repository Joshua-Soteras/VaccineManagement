using csula.labs.HW2.Services;
using csula.labs.HW2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;


namespace csula.labs.HW2.Controllers
{
    public class PatientsController : Controller


    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            //The instance is coming from the framework
            //Note we do not have instiantiate an object because the framework will do it for us 
            _patientService = patientService;
        }

        public IActionResult PatientsIndex()
        {
            ViewBag.VaccineCompanies = _patientService.GetVaccines();
            return View(_patientService.GetPatients());
        }



        //ADD: adding  a new patient to the database and displaying it to view 
        [HttpGet]
        public IActionResult AddPatient()
        {
            //Displaying as List (drop down select list option)
            ViewBag.Vaccines = _patientService.GetAvailVaccines()
                .Select(e => new SelectListItem(e.Name, e.Id.ToString()))
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult AddPatient(int id, Patient newPatient)
        {

            var vaccine = _patientService.GetVaccine(newPatient.VaccineCompanyId);

            vaccine.TotalDosesLeft = vaccine.TotalDosesLeft - 1;

            _patientService.AddPatient(newPatient);
          
        
            //Redirect back to Vaccine Pages
            return RedirectToAction("PatientsIndex");

        }


        //ADD: adding  a second does 
        [HttpGet]
        public IActionResult ReciDose(int id)
        {   
            ViewBag.time = DateTime.Now;

            return View(_patientService.GetPatient(id));
        }


        [HttpPost]
        public IActionResult ReciDose(int id, Patient update)
        {
            ViewBag.time = DateTime.Now;
            var patient = _patientService.GetPatient(id);

            var vaccine = _patientService.GetVaccine(patient.VaccineCompanyId);
            vaccine.TotalDosesLeft = vaccine.TotalDosesLeft - 1; 

            patient.SecondDose = update.SecondDose;
            _patientService.SaveChanges();

            return RedirectToAction("PatientsIndex");

        }
    }
}
