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
    public class CustomerRequestRepository : ICustomerRequestRepository
    {
      public  CustomerRequest CreateDelete()
        {
            CustomerRequest cr = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KIDTIMEPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_CustomerRequest_CreateDelete";
                    connection.Open();
                     command.CommandText = "UPDATE CustomerRequest SET CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, WaterAmount = @WaterAmount, WaterOnDate = @WaterOnDate, WaterOffDate= @WaterOffDate, Comments = @Comments";
                    command.Parameters.AddWithValue("@CustomerFirstname", cr.CustomerFirstName);
                    command.Parameters.AddWithValue("@CustomerLastname", cr.CustomerLastName);
                    command.Parameters.AddWithValue("@WaterAmount", cr.WaterAmount);
                    command.Parameters.AddWithValue("@WaterOnDate", cr.WaterOnDate);
                    command.Parameters.AddWithValue("@WaterOffDate", cr.WaterOffDate);
                    command.Parameters.AddWithValue("@Comments", cr.Comments);
                    connection.Open();
                    command.ExecuteNonQuery();
                    }
                }
            return (cr);
            }
        }
        public CustomerRequest SetWaterTImes()
        {
            CustomerRequest cr = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "sp_CustomerRequest_SetWaterTImes";
                    command.Parameters.AddWithValue("@RequestID", cr.RequestID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        {
                        if (reader.Read())
                        {
                            CustomerRequest r = new CustomerRequest();
                            r.RequestID = int.Parse(reader["RequestID"].ToString());
                            r.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            r.CustomerFirstName = reader["CustomerFirstName"].ToString();
                            r.CustomerLastName = reader["CustomerLastName"].ToString();
                            r.WaterAmount = int.Parse(reader["WaterAmount"].ToString());
                            r.WaterOnDate = DateTime.Parse(reader["WaterOnDate"].ToString());
                            r.WaterOffDate = DateTime.Parse(reader["WaterOffDate"].ToString());
                            r.Comments = reader["Comments"].ToString();
                            r.WaterOn = DateTime.Parse(reader["WaterOn"].ToString());
                            r.WaterOff = DateTime.Parse(reader["WaterOff"].ToString());
                        }
                    }

                }
            }
            return (cr);
        }
       public void Save (CustomerRequest request)
        {
            CustomerRequest cr = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                    {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    if (request.RequestID != 0)
                    {
                        command.Parameters.AddWithValue("@RequestID", request.RequestID); command.CommandText = "UPDATE CustomerRequest SET RequestID = @RequestID, CustomerID = @CustomerID, CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, WaterAmount = @WaterAmount, WaterOnDate = @WaterOnDate, WaterOffDate = @WaterOffDate, Comments = @Comments, DitchRiderID= @DitchRiderID, WaterOn = @WaterOn, WaterOff = @WaterOff";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO CustomerRequest (RequestID, CustomerID, CustomerFirstName, CustomerLastName, WaterAmount, WaterOnDate, WaterOffDate, Comments, DitchRiderID, WaterOn, WaterOff";
                    }
                    command.Parameters.AddWithValue("@RequestID", request.RequestID);
                    command.Parameters.AddWithValue("@CustomerID", request.CustomerID);
                    command.Parameters.AddWithValue("@CustomerFirstName", request.CustomerFirstName);
                    command.Parameters.AddWithValue("@CustomerLastName", request.CustomerLastName);
                    command.Parameters.AddWithValue("@WaterAmount", request.WaterAmount);
                    command.Parameters.AddWithValue("@WaterOnDate", request.WaterOnDate);
                    command.Parameters.AddWithValue("@WaterOffDate", request.WaterOffDate);
                    command.Parameters.AddWithValue("@Comments", request.Comments);
                    command.Parameters.AddWithValue("@DitchRiderID", request.DitchRiderID);
                    command.Parameters.AddWithValue("@WaterOn", request.WaterOn);
                    command.Parameters.AddWithValue("@WaterOff", request.WaterOff);
                    connection.Open();
                    command.ExecuteNonQuery();
                        
                }
            }
        }
    }