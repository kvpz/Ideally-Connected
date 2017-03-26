using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using IdeallyConnected.Controllers;
using IdeallyConnected.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdeallyConnected.Data.Models;
using IdeallyConnected.Models;
using System.Web.Mvc;

namespace IdeallyConnected.Test.Controllers
{
    [TestClass]
    class HomeControllerTest
    {
        private Mock<API.Models.IContactService> _mockContactService;
        private HomeController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockContactService = new Mock<API.Models.IContactService>();
            _controller = new HomeController(_mockContactService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockContactService.VerifyAll();
        }

        [TestMethod]
        public void Index_ExpectViewResultReturned()
        {
            var stubContacts = (new List<Contact>
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "jsmith@johnmail.com"
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Williams",
                    Email = "bobwill@goodwill.com"
                }
            }).AsQueryable();

            _mockContactService.Setup(x => x.GetAllContacts()).Returns(stubContacts);

            var expectedModel = new List<ContactViewModel>();
            foreach(var stubContact in stubContacts)
            {
                expectedModel.Add(new ContactViewModel()
                {
                    Id = stubContact.Id,
                    Email = stubContact.Email,
                    FirstName = stubContact.FirstName,
                    LastName = stubContact.LastName
                });
            }

            var result = _controller.Contact() as ViewResult;
        }
    }
}
