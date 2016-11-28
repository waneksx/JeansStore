using DomainModel.Abstract;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IJeansRepository repository;
        public AdminController(IJeansRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Jeans);
        }

        public ViewResult Edit(int jeansId)
        {
            Jeans jeans = repository.Jeans
            .FirstOrDefault(p => p.JeansId == jeansId);
            return View(jeans);
        }


        [HttpPost]
        public ActionResult Edit(Jeans jeans)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(jeans);
                TempData["message"] = string.Format("{0} has been saved", jeans.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(jeans);
            }
        }

    }
}