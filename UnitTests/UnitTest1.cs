using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DomainModel.Abstract;
using DomainModel.Entities;
using System.Linq;
using WebUI.Controllers;
using WebUI.Models;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1"},
new Jeans {JeansId = 2, Name = "P2"},
new Jeans {JeansId = 3, Name = "P3"},
new Jeans {JeansId = 4, Name = "P4"},
new Jeans {JeansId = 5, Name = "P5"}
}.AsQueryable());
            // Arrange
            JeansController controller = new JeansController(mock.Object);
            controller.PageSize = 3;
            // Act
            JeansListViewModel result = (JeansListViewModel)controller.Index(null, 2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1"},
new Jeans {JeansId = 2, Name = "P2"},
new Jeans {JeansId = 3, Name = "P3"},
new Jeans {JeansId = 4, Name = "P4"},
new Jeans {JeansId = 5, Name = "P5"}
}.AsQueryable());
            // Arrange
            JeansController controller = new JeansController(mock.Object);
            controller.PageSize = 3;
            // Act
            JeansListViewModel result = (JeansListViewModel)controller.Index(null, 2).Model;
            // Assert
            Jeans[] jeansArray = result.Jeans.ToArray();
            Assert.IsTrue(jeansArray.Length == 2);
            Assert.AreEqual(jeansArray[0].Name, "P4");
            Assert.AreEqual(jeansArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = new Color { Name = "Col1"} },
new Jeans {JeansId = 2, Name = "P2", Color = new Color { Name = "Col2"}},
new Jeans {JeansId = 3, Name = "P3", Color = new Color { Name = "Col1"}},
new Jeans {JeansId = 4, Name = "P4", Color = new Color { Name = "Col2"}},
new Jeans {JeansId = 5, Name = "P5", Color = new Color { Name = "Col3"}}
}.AsQueryable());
            // Arrange
            JeansController controller = new JeansController(mock.Object);
            controller.PageSize = 3;
            // Act
            Jeans[] result = ((JeansListViewModel)controller.Index("Col2", 1).Model).Jeans.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Color.Name == "Col2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Color.Name == "Col2");
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            // - create the mock repository
            // Arrange
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = new Color { Name = "Apples"}},
new Jeans {JeansId = 2, Name = "P2", Color = new Color { Name = "Apples"}},
new Jeans {JeansId = 3, Name = "P3", Color = new Color { Name = "Plums"}},
new Jeans {JeansId = 4, Name = "P4", Color = new Color { Name = "Oranges"}},

}.AsQueryable());
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();
            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange
            // - create the mock repository
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = new Color { Name = "Apples"}},
new Jeans {JeansId = 4, Name = "P2", Color = new Color { Name = "Oranges"}},

}.AsQueryable());
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);
            // Arrange - define the category to selected
            string colorToSelect = "Apples";
            // Action
            string result = target.Menu(colorToSelect).ViewBag.SelectedColor;
            // Assert
            Assert.AreEqual(colorToSelect, result);
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            mock.Setup(m => m.Jeans).Returns(new Jeans[] {
new Jeans {JeansId = 1, Name = "P1", Color = new Color { Name = "Col1"}},
new Jeans {JeansId = 2, Name = "P2", Color = new Color { Name = "Col2"}},
new Jeans {JeansId = 3, Name = "P3", Color = new Color { Name = "Col1"}},
new Jeans {JeansId = 4, Name = "P4", Color = new Color { Name = "Col2"}},
new Jeans {JeansId = 5, Name = "P5", Color = new Color { Name = "Col3"}}
}.AsQueryable());
            // Arrange
            JeansController target = new JeansController(mock.Object);
            target.PageSize = 3;           
            // Action - test the product counts for different categories
            int res1 = ((JeansListViewModel)target
            .Index("Col1").Model).PagingInfo.TotalItems;
            int res2 = ((JeansListViewModel)target
            .Index("Col2").Model).PagingInfo.TotalItems;
            int res3 = ((JeansListViewModel)target
            .Index("Col3").Model).PagingInfo.TotalItems;
            int resAll = ((JeansListViewModel)target
            .Index(null).Model).PagingInfo.TotalItems;
            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
