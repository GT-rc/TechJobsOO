using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;


namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData JobData;

        static JobController()
        {
            JobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job job = JobData.Find(id);
            return View(job);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }
        
        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            
            if (ModelState.IsValid)
            {
                Employer emp = JobData.Employers.Find(newJobViewModel.EmployerID);
                Location loc = JobData.Locations.Find(newJobViewModel.LocationID);
                CoreCompetency skill = JobData.CoreCompetencies.Find(newJobViewModel.CoreCompetenciesID);
                PositionType post = JobData.PositionTypes.Find(newJobViewModel.PositionTypeID);

                Job newJob = new Job
                {
                    Name = newJobViewModel.Name,
                    Employer = emp,
                    Location = loc,
                    CoreCompetency = skill,
                    PositionType = post
                };

                JobData.Jobs.Add(newJob);

                string id = newJob.ID.ToString();
                
                return Redirect("/Job?id=" + id);
                
            } 

            return View(newJobViewModel); 
        }
    }
}
