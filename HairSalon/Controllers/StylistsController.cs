using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
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
  }
}
