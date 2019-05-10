using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
      private int _id;
      private string _stylistId;
      private string _details;

      public Client(string details, string stylistId, int id = 0)
      {
          _details = details;
          _stylistId - stylistId;
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
  }
}
