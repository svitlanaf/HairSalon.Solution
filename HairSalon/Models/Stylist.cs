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

    public string SetName()
    {
      return _name;
    }

    public string SetInformation()
    {
      return _information;
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

    public List<Client> GetClients()
    {
        List<Client> allClients = new List<Client>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @thisId;";
        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@thisId";
        thisId.Value = _id;
        cmd.Parameters.Add(thisId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            int clientId = rdr.GetInt32(0);
            int clientStylistId = rdr.GetInt32(1);
            string clientName = rdr.GetString(2);
            string clientDetails = rdr.GetString(3);
            DateTime clientAppointment = rdr.GetDateTime(4);
                
            Client newClient = new Client(clientName, clientDetails, clientAppointment, clientId, clientStylistId);
            allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allClients;
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


    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
    public override bool Equals(System.Object secondStylist)
    {
      if (!(secondStylist is Stylist))
      {
        return false;
      }
      else 
      {
        Stylist firstStylist = (Stylist) secondStylist;
        bool idEquality = (this.GetId() == firstStylist.GetId());
        bool nameEquality = (this.GetName() == firstStylist.GetName());
        bool informationEquality = (this.GetInformation() == firstStylist.GetInformation());
        return (idEquality && nameEquality && informationEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (information, name) VALUES (@StylistInformation, @StylistName);";
      MySqlParameter information = new MySqlParameter();
      information.ParameterName = "@StylistInformation";
      information.Value = this._information;
      cmd.Parameters.Add(information);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@StylistName";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
    }

    public void EditName(string newName)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE stylists SET name = @newName WHERE id = @searchId;";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@newName";
        name.Value = newName;
        cmd.Parameters.Add(name);
        cmd.ExecuteNonQuery();
        _name = newName;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        }

    public void EditInformation(string newInformation)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE stylists SET information = @newInformation WHERE id = @searchId;";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);
        MySqlParameter information = new MySqlParameter();
        information.ParameterName = "@newInformation";
        information.Value = newInformation;
        cmd.Parameters.Add(information);
        cmd.ExecuteNonQuery();
        _information = newInformation;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        }

    public void Delete()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("DELETE FROM stylists WHERE id = @StylistId;", conn);
        MySqlParameter stylistIdParameter = new MySqlParameter();
        stylistIdParameter.ParameterName = "@StylistId";
        stylistIdParameter.Value = _id;
        cmd.Parameters.Add(stylistIdParameter);
        cmd.ExecuteNonQuery();
        if (conn != null)
        {
          conn.Close();
        }
      }

  }
}
