using DomainModel.Abstract;
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
    }
}