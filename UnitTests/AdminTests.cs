using DomainModel.Abstract;
using DomainModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Controllers;

namespace UnitTests
{
    [TestClass]
    class AdminTests
    {

        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange - create the mock repository
                        Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = new Color { Name = "Col1"}},
new Jeans {JeansId = 2, Name = "P2", Color = new Color { Name = "Col2"}},
new Jeans {JeansId = 3, Name = "P3", Color = new Color { Name = "Col1"}}
}.AsQueryable());
            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);
            // Action
            Jeans[] result =
            ((IEnumerable<Jeans>)target.Index().ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }
    }
}
