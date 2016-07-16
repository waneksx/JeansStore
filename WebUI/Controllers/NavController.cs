using DomainModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IJeansRepository repository;
        public NavController(IJeansRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string color = null)
        {
            ViewBag.SelectedColor = color;
            IEnumerable<string> categories = repository.Jeans
            .Select(x => x.Color.Name)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}