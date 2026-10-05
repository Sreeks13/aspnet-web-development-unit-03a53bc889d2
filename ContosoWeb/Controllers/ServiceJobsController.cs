using System.Linq;
using System.Web.Mvc;
using ContosoWeb.Models;

namespace ContosoWeb.Controllers
{
    public class ServiceJobsController : Controller
    {
        private static readonly ServiceJob[] Jobs =
        {
            new ServiceJob { Id = 1, Make = "Toyota", ServiceType = "Oil Change", Description = "Engine oil and filter replacement" },
            new ServiceJob { Id = 2, Make = "Toyota", ServiceType = "Brake Service", Description = "Brake inspection and pad replacement" },
            new ServiceJob { Id = 3, Make = "Toyota", ServiceType = "Oil Change", Description = "Synthetic oil service" },
            new ServiceJob { Id = 4, Make = "Honda", ServiceType = "Oil Change", Description = "Routine oil service" }
        };

        public ActionResult ServiceJobsByMake(string make)
        {
            var jobs = Jobs
                .Where(j => j.Make.Equals(make, System.StringComparison.OrdinalIgnoreCase))
                .GroupBy(j => j.ServiceType)
                .OrderBy(g => g.Key)
                .ToList();

            ViewBag.Make = make;
            return View(jobs);
        }

        public ActionResult ServiceJobDetails(string make, int id)
        {
            var job = Jobs.FirstOrDefault(j =>
                j.Id == id &&
                j.Make.Equals(make, System.StringComparison.OrdinalIgnoreCase));

            if (job == null)
                return HttpNotFound();

            return View(job);
        }
    }
}