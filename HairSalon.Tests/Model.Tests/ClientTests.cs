using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace   HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {
    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=svitlana_filatova_test;";
    }
    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("Clara", "Hair coloring", DateTime.Parse("11/23/2019"), 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Clara";
      string details = "Hair coloring";
      DateTime appointment = DateTime.Parse("11/23/2019");
      Client newClient = new Client(name, details, appointment, 1);
      string result = newClient.GetName();
      Assert.AreEqual(name, result);
    }
    
    [TestMethod]
    public void GetDetails_ReturnsDetails_String()
    {
      string name = "Clara";
      string details = "Hair coloring";
      DateTime appointment = DateTime.Parse("11/23/2019");
      Client newClient = new Client(name, details, appointment, 1);
      string result = newClient.GetDetails();
      Assert.AreEqual(details, result);
    }

     [TestMethod]
    public void GetAppointment_ReturnsAppointmentDate_DateTime()
    {
      string name = "Clara";
      string details = "Hair coloring";
      DateTime appointment = DateTime.Parse("11/23/2019");
      Client newClient = new Client(name, details, appointment, 1);
      DateTime result = newClient.GetAppointment();
      Assert.AreEqual(appointment, result);
    }

    [TestMethod]
    public void SetName_SetName_String()
    {
      string name = "Clara";
      string details = "Hair coloring";
      DateTime appointment = DateTime.Parse("11/23/2019");
      Client newClient = new Client(name, details, appointment, 1);
      string updatedName = "Victoria";
      newClient.SetName(updatedName);
      string result = newClient.GetName();
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void SetDetails_SetDetails_String()
    {
      string name = "Clara";
      string details = "Hair coloring";
      DateTime appointment = DateTime.Parse("11/23/2019");
      Client newClient = new Client(name, details, appointment, 1);
      string updatedDetails = "Hair cut";
      newClient.SetDetails(updatedDetails);
      string result = newClient.GetDetails();
      Assert.AreEqual(updatedDetails, result);
    }

    [TestMethod]
    public void SetAppointment_SetAppointmentDate_DateTime()
    {
      string name = "Clara";
      string details = "Hair coloring";
      DateTime appointment = DateTime.Parse("11/23/2019");
      Client newClient = new Client(name, details, appointment, 1);
      DateTime updatedAppointment = DateTime.Parse("11/25/2019");
      newClient.SetAppointment(updatedAppointment);
      DateTime result = newClient.GetAppointment();
      Assert.AreEqual(updatedAppointment, result);
    }

     [TestMethod]
     public void GetAll_ReturnsEmptyList_ClientList()
    {
      List<Client> newList = new List<Client> { };
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      string name01 = "Ivan";
      string details01 = "Trim";
      DateTime appointment01 = DateTime.Parse("12/03/2019");
      string name02 = "Gitangali";
      string details02 = "Partial hair coloring";
      DateTime appointment02 = DateTime.Parse("12/05/2019");
      Client newClient1 = new Client(name01, details01, appointment01, 1);
      newClient1.Save();
      Client newClient2 = new Client(name02, details02, appointment02, 1);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

     [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      Client testClient = new Client("Ivan", "Trim", DateTime.Parse("12/03/2019"), 1);
      testClient.Save();
      Client foundClient = Client.Find(testClient.GetId());
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      Client firstClient = new Client("Ivan", "Trim", DateTime.Parse("12/03/2019"), 1);
      Client secondClient = new Client("Ivan", "Trim", DateTime.Parse("12/03/2019"), 1);
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_Client()
    {
      Stylist testStylist = new Stylist("Otto", "Awesome stylist", 1);
      testStylist.Save();
      int testId = testStylist.GetId();
      Client testClient = new Client("Ivan", "Trim", DateTime.Parse("12/03/2019"), testId);
      testClient.Save();
      Client result = Client.GetAll()[0];
      Assert.AreEqual(testClient.GetName(), result.GetName());
      Assert.AreEqual(testClient.GetDetails(), result.GetDetails());
      Assert.AreEqual(testClient.GetAppointment(), result.GetAppointment());
      Assert.AreEqual(testClient.GetStylistId(), result.GetStylistId());
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      Client testClient = new Client("Ivan", "Trim", DateTime.Parse("12/03/2019"), 20);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Stylist testStylist = new Stylist("Otto", "Awesome stylist", 1);
      testStylist.Save();
      int testId = testStylist.GetId();
      Client testClient = new Client("Ivan", "Trim", DateTime.Parse("12/03/2019"), testId);
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testClientId = testClient.GetId();
      Assert.AreEqual(testClientId, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientNameInDatabase_String()
    {
      Stylist testStylist = new Stylist("Otto", "Awesome stylist", 1);
      testStylist.Save();
      int testId = testStylist.GetId();
      Client testClient = new Client("Ivan","Trim", DateTime.Parse("12/03/2019"), testId);
      testClient.Save();
      string secondName = "Tristan";
      testClient.Edit(secondName, "Trim", DateTime.Parse("12/03/2019"));
      string result = Client.Find(testClient.GetId()).GetName();
      Assert.AreEqual(secondName, result);
    }

    [TestMethod]
    public void Edit_UpdatesClienDetailsInDatabase_String()
    {
      Stylist testStylist = new Stylist("Otto", "Awesome stylist", 1);
      testStylist.Save();
      int testId = testStylist.GetId();
      Client testClient = new Client("Tristan","Trim", DateTime.Parse("12/03/2019"), testId);
      testClient.Save();
      string secondDetails = "Coloring";
      testClient.Edit("Tristan", secondDetails, DateTime.Parse("12/03/2019"));
      string result = Client.Find(testClient.GetId()).GetDetails();
      Assert.AreEqual(secondDetails, result);
    }

    [TestMethod]
    public void Edit_UpdatesClienAppointmemntDateInDatabase_DateTime()
    {
      Stylist testStylist = new Stylist("Otto", "Awesome stylist", 1);
      testStylist.Save();
      int testId = testStylist.GetId();
      Client testClient = new Client("Tristan","Trim", DateTime.Parse("12/03/2019"), testId);
      testClient.Save();
      DateTime secondAppointment = DateTime.Parse("12/05/2019");
      testClient.Edit("Tristan", "Trim", secondAppointment);
      DateTime result = Client.Find(testClient.GetId()).GetAppointment();
      Assert.AreEqual(secondAppointment, result);
    }
    
    }
}