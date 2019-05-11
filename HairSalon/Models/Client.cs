using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
      private int _id;
      private int _stylistId;
      private string _name;
      private string _details;
      private DateTime _appointment;

      public Client(string name, string details, DateTime appointment, int stylistId, int id = 0)
      {
          _name = name;
          _details = details;
          _appointment = appointment;
          _stylistId = stylistId;
          _id = id;
      }


    public int GetStylistId()
    {
    return _stylistId;
    }

     public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetDetails()
    {
      return _details;
    }

    public DateTime GetAppointment()
    {
        return _appointment;
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
        int clientStylistId = 0;
        string clientName = "";
        string clientDetails = "";
        DateTime clientAppointment = new DateTime();
        while(rdr.Read())
        {
            clientId = rdr.GetInt32(0);
            clientStylistId = rdr.GetInt32(1);
            clientName = rdr.GetString(2);
            clientDetails = rdr.GetString(3);
            clientAppointment = rdr.GetDateTime(4);
        }
        Client foundClient = new Client(clientName, clientDetails, clientAppointment, clientStylistId, clientId);
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        return foundClient;
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
                bool nameEquality = this.GetName() == newClient.GetName();
                bool detailsEquality = this.GetDetails() == newClient.GetDetails();
                bool appointmentEquality = this.GetAppointment() == newClient.GetAppointment();
                bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
                return (idEquality && detailsEquality && stylistIdEquality);
            }
        }

        public void Save()
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name, details, appointment, stylist_id) VALUES (@name, @details, @appointment, @stylist_id);";
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this._name;
        cmd.Parameters.Add(name);

        MySqlParameter details = new MySqlParameter();
        details.ParameterName = "@details";
        details.Value = this._details;
        cmd.Parameters.Add(details);

        MySqlParameter appointment = new MySqlParameter();
        appointment.ParameterName = "@appointment";
        appointment.Value = this._appointment;
        cmd.Parameters.Add(appointment);

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

        public void Edit(string newName, string newDetails, DateTime newAppointment)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE clients SET name = @newName, details = @newDetails, appointment = @newAppointment WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@newName";
        name.Value = newName;
        cmd.Parameters.Add(name);
        MySqlParameter details = new MySqlParameter();
        details.ParameterName = "@newDetails";
        details.Value = newDetails;
        cmd.Parameters.Add(details);
        MySqlParameter appointment = new MySqlParameter();
        appointment.ParameterName = "@newAppointment";
        appointment.Value = newAppointment;
        cmd.Parameters.Add(appointment);
        cmd.ExecuteNonQuery();
        _name = newName;
        _details = newDetails;
        _appointment = newAppointment;
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
