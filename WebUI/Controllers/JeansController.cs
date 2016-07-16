using DomainModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class JeansController : Controller
    {

        private IJeansRepository repository;
        public int PageSize = 4;
        public JeansController(IJeansRepository jeansRepository)
        {
            this.repository = jeansRepository;
        }

        // GET: Jeans
        public ViewResult Index(string color, int page = 1)
        {
            JeansListViewModel model = new JeansListViewModel
            {
                Jeans = repository.Jeans
                .Where(p => color == null || p.Color.Name == color)
.OrderBy(j => j.JeansId)
.Skip((page - 1) * PageSize)
.Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = color == null ?
repository.Jeans.Count() :
repository.Jeans.Where(e => e.Color.Name == color).Count()
                },
                CurrentColor = color
            };

            return View(model);
        }
    }
}