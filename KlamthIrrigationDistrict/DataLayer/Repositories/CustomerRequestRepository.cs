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
        public virtual List<CustomerRequest> GetList()
        {
            List<CustomerRequest> RequestList = new List<CustomerRequest>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM CustomerRequest";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CustomerRequest cr = new CustomerRequest();
                            cr.RequestID = int.Parse(reader["RequestID"].ToString());
                            cr.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            cr.CustomerFirstName = reader["CustomerFirstName"].ToString();
                            cr.CustomerLastName = reader["CustomerLastName"].ToString();
                            cr.WaterAmount = int.Parse(reader["WaterAmount"].ToString());
                            cr.WaterOnDate = DateTime.Parse(reader["WaterOnDate"].ToString());
                            cr.WaterOffDate = DateTime.Parse(reader["WaterOffDate"].ToString());
                            cr.Comments = reader["Comments"].ToString();
                            cr.DitchRiderID = int.Parse(reader["DitchRiderID"].ToString());
                            cr.WaterOn = DateTime.Parse(reader["WaterOn"].ToString());
                            cr.WaterOff = DateTime.Parse(reader["WaterOff"].ToString());
                            RequestList.Add(cr);
                        }
                    }
                }
            }
            return (RequestList);
        }
        public CustomerRequest CreateDelete()
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
        public virtual CustomerRequest SetWaterTImes(CustomerRequest water)
        {
            CustomerRequest cr = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_CustomerRequest_SetWaterTImes";
                    if (cr.RequestID != 0)
                    {
                        command.Parameters.AddWithValue("@RequestID", cr.RequestID);
                    }
                    command.Parameters.AddWithValue("@CustomerID", water.CustomerID);
                    command.Parameters.AddWithValue("@CustomerFirstName", water.CustomerFirstName);
                    command.Parameters.AddWithValue("@CustomerLastName", water.CustomerLastName);
                    command.Parameters.AddWithValue("@WaterAmount", water.WaterAmount);
                    command.Parameters.AddWithValue("@WaterOnDate", water.WaterOnDate);
                    command.Parameters.AddWithValue("@WaterOffDate", water.WaterOffDate);
                    command.Parameters.AddWithValue("@Comments", water.Comments);
                    command.Parameters.AddWithValue("@DitchRiderID", water.DitchRiderID);
                    command.Parameters.AddWithValue("@WaterOn", water.WaterOn);
                    command.Parameters.AddWithValue("@WaterOff", water.WaterOff);
                }
            }
            return water;
        }

        public virtual void Save(CustomerRequest request)
        {
            CustomerRequest cr = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_CustomerRequest_CreateDelete";
                    if (request.RequestID != 0)
                    {
                        command.Parameters.AddWithValue("@RequestID", request.RequestID);
                    }
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
}