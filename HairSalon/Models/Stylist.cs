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
        
        Stylist newStylist = new Stylist(stylistName, stylistInformation, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string stylistName = "";
      string stylistInformation = "";
      while (rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        stylistName = rdr.GetString(1);
        stylistInformation = rdr.GetString(2);
      }
      Stylist foundStylist= new Stylist(stylistName, stylistInformation, stylistId);
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
      return foundStylist;
    }

    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = (this.GetName() == newStylist.GetName());
        bool InformationEquality = (this.GetInformation() == newStylist.GetInformation());
        return (idEquality && nameEquality && InformationEquality);
      }
    }

  }
}
