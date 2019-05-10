using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
      private int _id;
      private string _name;
      private string _information;

      public Stylist(string name, string information, int id = 0)
      {
          _name = name;
          _information = information;
          _id = id;
      }

    public string GetName()
    {
      return _name;
    }

    public string GetInformation()
    {
      return _information;
    }

     public int GetId()
    {
      return _id;
    }

    public static List<Stylist> GetAll()

    {
      List<Stylist> allStylists = new List<Stylist> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string stylistInformation = rdr.GetString(2);
        
        Stylist newStylist = new Stylist(stylistName, cuisineInformation, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

  }
}
