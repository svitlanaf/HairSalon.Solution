using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
      private int _id;
      private int _stylistId;
      private string _details;

      public Client(string details, int stylistId, int id = 0)
      {
          _details = details;
          _stylistId = stylistId;
          _id = id;
      }

    public string GetDetails()
    {
      return _details;
    }

    public int GetStylistId()
    {
    return _stylistId;
    }

     public int GetId()
    {
      return _id;
    }

    public static List<Client> GetAll()

    {
    List<Client> allClients = new List<Client> { };
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM clients;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
        int clientId = rdr.GetInt32(0);
        int clientStylistId = rdr.GetInt32(1);
        string clientDetails = rdr.GetString(2);
        
        Client newClient = new Client(clientDetails, clientId, clientStylistId);
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
        cmd.CommandText = @"DELETE FROM clients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
            {
            conn.Dispose();
            }
        }
    
    public static Client Find(int id)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int clientId = 0;
        string clientDetails = "";
        int clientStylistId = 0;
        while(rdr.Read())
        {
            clientId = rdr.GetInt32(0);
            clientStylistId = rdr.GetInt32(1);
            clientDetails = rdr.GetString(2);
        }
        Client newClient = new Client(clientDetails, clientStylistId, clientId);
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        return newClient;
        }

        public override int GetHashCode()
        {
        return this.GetId().GetHashCode();
        }
        public override bool Equals(System.Object otherClient)
        {
        if (!(otherClient is Client))
            {
                return false;
            }
        else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = this.GetId() == newClient.GetId();
                bool informationEquality = this.GetDetails() == newClient.GetDetails();
                bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
                return (idEquality && informationEquality && stylistIdEquality);
            }
        }

        public void Save()
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (details, stylist_id) VALUES (@details, @stylist_id);";
        MySqlParameter details = new MySqlParameter();
        details.ParameterName = "@details";
        details.Value = this._details;
        cmd.Parameters.Add(details);
        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@stylist_id";
        stylistId.Value = this._stylistId;
        cmd.Parameters.Add(stylistId);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void EditDetails(string newDetails)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE clients SET details = @newdetails WHERE id = @searchId;";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);
        MySqlParameter details = new MySqlParameter();
        details.ParameterName = "@newDetails";
        details.Value = newDetails;
        cmd.Parameters.Add(details);
        cmd.ExecuteNonQuery();
        _details = newDetails;
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
        MySqlCommand cmd = new MySqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);
        MySqlParameter clientParameter = new MySqlParameter();
        clientParameter.ParameterName = "@ClientId";
        clientParameter.Value = _id;
        cmd.Parameters.Add(clientParameter);
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
            {
            conn.Dispose();
            }
      }

  }
}
