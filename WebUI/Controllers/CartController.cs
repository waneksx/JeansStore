using DomainModel.Abstract;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IJeansRepository repository;
        public CartController(IJeansRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        
        public RedirectToRouteResult AddToCart(Cart cart, int jeansId, string returnUrl)
        {
            Jeans jeans = repository.Jeans
 .FirstOrDefault(p => p.JeansId == jeansId);
            if (jeans != null)
            {
                cart.AddItem(jeans, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int jeansId, string returnUrl)
        {
            Jeans jeans = repository.Jeans
            .FirstOrDefault(p => p.JeansId == jeansId);
            if (jeans != null)
            {
                cart.RemoveLine(jeans);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}
