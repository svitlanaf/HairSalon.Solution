using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

      [HttpGet("/clients")]
      public ActionResult Index()
      {
          List<Client> allClients = Client.GetAll();
          return View(allClients);
      }

      [HttpGet("/stylists/{id}/clients/new")]
      public ActionResult New(int id)
      {
          Stylist myStylist = Stylist.Find(id);
        return View(myStylist);
      }

      [HttpPost("/stylists/{id}/clients")]
      public ActionResult Create(string name, string details, DateTime appointment, int id)
      {
          Client myClient = new Client(name, details, appointment, id);
          myClient.Save();
          return RedirectToAction("Show", "Stylists", id);
      }

      [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
      public ActionResult Show(int clientId, int stylistId)
      {
          Client myClient = Client.Find(clientId);
          return View(myClient);
      }

      [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int clientId, int stylistId)
        {
        Client editClient = Client.Find(clientId);
       
        return View(editClient);
        }

        [ActionName("Edit"), HttpPost("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Update(int clientId, int stylistId, string name, string details, DateTime appointment)
        {
        Client thisClient = Client.Find(clientId);
        thisClient.Edit(name, details, appointment);
        return RedirectToAction("Show", thisClient);
        }


        [ActionName("Destroy"), HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
        public ActionResult Destroy(int clientId)
        {
        Client deleteClient = Client.Find(clientId);
        deleteClient.Delete();
        return RedirectToAction("Index");
        }

  }

}