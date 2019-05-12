using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
        Stylist.ClearAll();
        Client.ClearAll();
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
        public void SetName_SetName_String()
        {
        string name = "Emmaline";
        string information = "Has an experience in the beauty industry.";
        Stylist newStylist = new Stylist(name, information);
        string updatedName = "Milan";
        newStylist.SetName(updatedName);
        string result = newStylist.GetName();
        Assert.AreEqual(updatedName, result);
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

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
        Stylist testStylist = new Stylist("Emmaline", "Has an experience in the beauty industry.");
        testStylist.Save();
        List<Stylist> result = Stylist.GetAll();
        List<Stylist> testList = new List<Stylist>{testStylist};
        CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {
        Stylist testStylist = new Stylist("Emmaline", "Has an experience in the beauty industry.");
        testStylist.Save();
        Stylist savedStylist = Stylist.GetAll()[0];
        int result = savedStylist.GetId();
        int testId = testStylist.GetId();
        Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Edit_UpdatesStylistNameInDatabase_String()
        {
        Stylist testStylist = new Stylist("Emmaline", "");
        testStylist.Save();
        string secondName = "Anna";
        testStylist.EditName(secondName);
        string result = Stylist.Find(testStylist.GetId()).GetName();
        Assert.AreEqual(secondName, result);
        }

        [TestMethod]
        public void Edit_UpdatesStylistInformationInDatabase_String()
        {
        Stylist testStylist = new Stylist("", "Has an experience in the beauty industry.");
        testStylist.Save();
        string secondInformation = "Super hair dresser.";
        testStylist.EditInformation(secondInformation);
        string result = Stylist.Find(testStylist.GetId()).GetInformation();
        Assert.AreEqual(secondInformation, result);
        }

        [TestMethod]
        public void GetClients_RetrievesAllClientsWithStylist_ClientList()
        {
        Stylist testStylist = new Stylist("Emmaline", "Super hair dresser.");
        testStylist.Save();
        Client firstClient = new Client("Helen", "Hair coloring", DateTime.Parse("11/23/2010"), testStylist.GetId());
        firstClient.Save();
        Client secondClient = new Client("Oleg", "Hair cut", DateTime.Parse("11/23/2010"), testStylist.GetId());
        secondClient.Save();
        List<Client> testClientList = new List<Client> {firstClient, secondClient};
        List<Client> resultClientList = testStylist.GetClients();
        CollectionAssert.AreEqual(testClientList, resultClientList);
        }
    }
}
