using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

// add reference to web project controllers
using DigitalCharacterSheet2.Controllers;
using DigitalCharacterSheet2.Models;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCharacterSheet2.Tests.Controllers
{
    [TestClass]
    public class AlbumsControllerTest
    {
        Mock<ICharactersMock> mock;
        List<character> characters;
        List<attribute> attributes;
        charactersController controller;

        // sets up fake characters and attributes for testing with
        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<ICharactersMock>();

            characters = new List<character>
            {
                new character { character_name = "testName1", campaign = "testing", advancement_points = 0, plot_points = 0},
                new character { character_name = "testName2", campaign = "testing", advancement_points = 0, plot_points = 0},
                new character { character_name = "testName3", campaign = "testing", advancement_points = 0, plot_points = 0}
            };

            attributes = new List<attribute>
            {
                new attribute { attributeName = "Strength", attributeValue = 0, characterName = characters[0].character_name},
                new attribute { attributeName = "Dexterity", attributeValue = 0, characterName = characters[1].character_name},
                new attribute { attributeName = "Wisdom", attributeValue = 0, characterName = characters[2].character_name}
            };
            mock.Setup(m => m.Characters).Returns(characters.AsQueryable());
            controller = new charactersController(mock.Object);
        }

        // GET: Characters
        #region
        [TestMethod]
        public void IndexReturnsView()
        {
            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexReturnsCharacters()
        {
            // act
            var actual = (List<character>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(characters.ToList(), actual);
        }
        #endregion

        // GET: Characters/Details/5
        #region
        [TestMethod]
        public void DetailsNoId()
        {
            // act
            var result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            var result = (ViewResult)controller.Details("Odysseus");

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidId()
        {
            // act
            character actual = (character)((ViewResult)controller.Details("testName2")).Model;

            // assert
            Assert.AreEqual(characters[1], actual);
        }

        [TestMethod]
        public void DetailsViewLoads()
        {
            // act
            ViewResult result = (ViewResult)controller.Details("testName1");

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }
        #endregion

        // GET: Characters/Create
        #region
        [TestMethod]
        public void CreateReturnsView()
        {
            // act
            ViewResult result = controller.Create() as ViewResult;

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }
        #endregion

        // POST: characters/Create
        #region
        [TestMethod]
        public void CreateValidCharacter()
        {
            // arrange
            character noob = new character
            {
                character_name = "Ned The Noobish",
                campaign = "unitTesting",
                advancement_points = 0,
                plot_points = 0
            };

            // act 
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(noob);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateInvalidCharacter()
        {
            // arrange
            character invalidCharacter = new character();

            // act
            controller.ModelState.AddModelError("Cannot create", "create exception");
            ViewResult result = (ViewResult)controller.Create(invalidCharacter);

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }
        #endregion

        // GET: characters/CreateAttribute
        #region
        //[TestMethod]
        //public void CreateAttributeNoId()
        //{
        //    // act
        //    var result = (ViewResult)controller.CreateAttribute(null);

        //    // assert
        //    Assert.AreEqual("Error", result.ViewName);
        //}

        //public void CreateAttributeInvalidId()
        //{
        //    // act
        //    var result = (ViewResult)controller.CreateAttribute("Odysseus");

        //    // assert
        //    Assert.AreEqual("Error", result.ViewName);
        //}

        //[TestMethod]
        //public void CreateAttributeValidId()
        //{
        //    // act
        //    ViewResult result = (ViewResult)controller.CreateAttribute(characters[0].character_name);

        //    attribute att = new attribute();
        //    att.characterName = characters[0].character_name;
        //    att.attributeName = " ";
        //    att.attributeValue = 0;

        //    // assert
        //    Assert.AreEqual(att, result.ViewName);
        //}
        #endregion
    }
}