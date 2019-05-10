using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
        Cuisine.ClearAll();
        Restaurant.ClearAll();
        }

        public StylistTest()
        {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=svitlana_filatova_test;";
        }

        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
        string name = "Emmaline";
        string information = "Has an experience in the beauty industry.";
        Stylist newStylist = new Stylist(name, information);
        Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

        [TestMethod]
        public void GetDescription_ReturnsInformation_String()
        {
        string name = "Emmaline";
        string information = "Has an experience in the beauty industry.";
        Stylist newStylist = new Stylist(name, information);
        string result = newStylist.GetInformation();
        Assert.AreEqual(information, result);
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
        string name = "Emmaline";
        string information = "Has an experience in the beauty industry.";
        Stylist newStylist = new Stylist(name, information);
        string result = newStylist.GetName();
        Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_StylistList()
        {
        List<Stylist> newList = new List<Stylist> { };
        List<Stylist> result = Stylist.GetAll();
        CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfInformationsAreTheSame_Stylist()
        {
        Stylist firstStylist = new Stylist("", "Has an experience in the beauty industry.");
        Stylist secondStylist = new Stylist("", "Has an experience in the beauty industry.");
        Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
        {
        Stylist firstStylist = new Stylist("Emmaline", "");
        Stylist secondStylist = new Stylist("Emmaline", "");
        Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Find_ReturnsStylistInDatabase_Stylist()
        {
        Stylist testStylist = new Stylist("Emmaline", "Has an experience in the beauty industry.");
        testStylist.Save();
        Stylist foundStylist = Stylist.Find(testStylist.GetId());
        Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void GetAll_StylistEmptyAtFirst_List()
        {
        int result = Stylist.GetAll().Count;
        Assert.AreEqual(0, result);
        }
    }
}
