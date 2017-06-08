using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlamthIrrigationDistrict.DataLayer.Interfaces;
using KlamthIrrigationDistrict.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using KlamthIrrigationDistrict.Controllers;

namespace KlamthIrrigationDistrict.DataLayer.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public virtual Customers Get(int id)
        {
            Customers c = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Customers_InsertUpdate";
                    command.Parameters.AddWithValue("@CustomerID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            c = new Customers();
                            c.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            c.CustomerFirstName = reader["CustomerFirstName"].ToString();
                            c.CustomerLastName = reader["CustomerLastName"].ToString();
                            c.Address1 = reader["Address1"].ToString();
                            c.Address2 = reader["Address2"].ToString();
                            c.City = reader["City"].ToString();
                            c.State = reader["State"].ToString();
                            c.Zip = reader["Zip"].ToString();
                            c.CustomerPhoneNumber = reader["CustomerPhoneNumber"].ToString();
                            c.CustomerEmail = reader["CustomerEmail"].ToString();
                        }
                    }
                }
            }
            return (c);
        }
       
        public virtual void Save(Customers customers)
        {
            Customers c = null;
            using (SqlConnection conneciton = new SqlConnection(ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conneciton;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Customers_InsertUpdate";
                    if (customers.CustomerID !=0)
                    {
                        command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                    }
                    command.Parameters.AddWithValue("@CustomerFirstName", customers.CustomerFirstName);
                    command.Parameters.AddWithValue("@CustomerLastName", customers.CustomerLastName);
                    command.Parameters.AddWithValue
                        ("@Address1", customers.Address1);
                    command.Parameters.AddWithValue("@Address2", customers.Address2);
                    command.Parameters.AddWithValue("@City", customers.City);
                    command.Parameters.AddWithValue("@State", customers.State);
                    command.Parameters.AddWithValue("@Zip", customers.Zip);
                    command.Parameters.AddWithValue("@CustomerPhoneNumber", customers.CustomerPhoneNumber);
                    command.Parameters.AddWithValue("@CustomerEmail", customers.CustomerEmail);
                    conneciton.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}