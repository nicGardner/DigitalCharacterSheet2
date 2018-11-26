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


        
    }
}