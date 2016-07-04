using DomainModel.Abstract;
using DomainModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Controllers;
using WebUI.Models;

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Arrange - create some test products
            Jeans j1 = new Jeans { JeansId = 1, Name = "P1" };
            Jeans j2 = new Jeans { JeansId = 2, Name = "P2" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(j1, 1);
            target.AddItem(j2, 1);
            CartLine[] results = target.Lines.ToArray();
            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Jeans, j1);
            Assert.AreEqual(results[1].Jeans, j2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange - create some test products
            Jeans j1 = new Jeans { JeansId = 1, Name = "P1" };
            Jeans j2 = new Jeans { JeansId = 2, Name = "P2" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(j1, 1);
            target.AddItem(j2, 1);
            target.AddItem(j1, 10);
            CartLine[] results = target.Lines.OrderBy(c => c.Jeans.JeansId).ToArray();
            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 11);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products
            Jeans j1 = new Jeans { JeansId = 1, Name = "P1" };
            Jeans j2 = new Jeans { JeansId = 2, Name = "P2" };
            Jeans j3 = new Jeans { JeansId = 3, Name = "P3" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.AddItem(j1, 1);
            target.AddItem(j2, 3);
            target.AddItem(j3, 5);
            target.AddItem(j2, 1);
            // Act
            target.RemoveLine(j2);
            // Assert
            Assert.AreEqual(target.Lines.Where(c => c.Jeans == j2).Count(), 0);
            Assert.AreEqual(target.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test products
            Jeans j1 = new Jeans { JeansId = 1, Name = "P1", Price = 100M };
            Jeans j2 = new Jeans { JeansId = 2, Name = "P2", Price = 50M };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(j1, 1);
            target.AddItem(j2, 1);
            target.AddItem(j1, 3);
            decimal result = target.ComputeTotalValue();
            // Assert
            Assert.AreEqual(result, 450M);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Arrange - create some test products
            Jeans j1 = new Jeans { JeansId = 1, Name = "P1", Price = 100M };
            Jeans j2 = new Jeans { JeansId = 2, Name = "P2", Price = 50M };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some items
            target.AddItem(j1, 1);
            target.AddItem(j2, 1);
            // Act - reset the cart
            target.Clear();
            // Assert
            Assert.AreEqual(target.Lines.Count(), 0);
        }

        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Arrange - create the mock repository
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = "Apples"},
}.AsQueryable());
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            // Act - add a product to the cart
            target.AddToCart(cart, 1, null);
            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Jeans.JeansId, 1);
        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            // Arrange - create the mock repository
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = "Apples"},
}.AsQueryable());
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            // Act - add a product to the cart
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");
            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(null);
            // Act - call the Index action method
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart,
            "myUrl").ViewData.Model;
            // Assert
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
