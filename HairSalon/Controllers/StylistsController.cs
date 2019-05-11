using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

      [HttpGet("/stylists")]
      public ActionResult Index()
      {
          List<Stylist> allStylists = Stylist.GetAll();
          return View(allStylists);
      }

       [HttpGet("/stylists/new")]
      public ActionResult New()
      {
          return View();
      }

      [HttpPost("/stylists/create")]
      public ActionResult Create(string name, string information)
      {
          Stylist myStylist = new Stylist(name, information);
          myStylist.Save();
          return RedirectToAction("Index");
      }

      [HttpGet("/stylists/{id}")]
      public ActionResult Show(int id)
      {
          Stylist myStylist = Stylist.Find(id);
          return View(myStylist);
      }

      [HttpGet("/stylists/{id}/edit")]
        public ActionResult Edit(int id)
        {
        Stylist editStylist = Stylist.Find(id);
        return View(editStylist);
        }

        [ActionName("Edit"), HttpPost("/stylists/{id}/edit")]
        public ActionResult Update(int id, string name, string information)
        {
        Stylist thisStylist = Stylist.Find(id);
        thisStylist.EditName(name);
        thisStylist.EditInformation(information);
        return RedirectToAction("Show", thisStylist);
        }

        [ActionName("Destroy"), HttpPost("/stylists/{id}/delete")]
        public ActionResult Destroy(int id)
        {
        Stylist deleteStylist = Stylist.Find(id);
        List<Client> deleteClients = deleteStylist.GetClients();
        foreach(Client client in deleteClients)
        {
            client.Delete();
        }
        deleteStylist.Delete();
        return RedirectToAction("Index");
        }

  }
}
