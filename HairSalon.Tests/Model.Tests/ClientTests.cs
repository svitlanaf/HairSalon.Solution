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
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=svitlana_filatova_test;";
    }

    // [TestMethod]
    // {
        
    // }
    }
}