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
    public class DitchRidersRepository : IDitchRidersRepository
    {
        public DitchRider Get(int id)
        {
            DitchRider dr = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM DitchRider";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            dr = new DitchRider();
                            dr.DitchRiderID = int.Parse(reader["DitchRiderID"].ToString());
                            dr.DitchRiderFirstName = reader["DitchRiderFirstName"].ToString();
                            dr.DitchRiderLastName = reader["DitchRiderLastName"].ToString();
                            dr.DitchRiderPhoneNumber = int.Parse(reader["DitchRiderPhoneNumber"].ToString());
                        }
                    }
                }
            }
            return (dr);
        }

        public void Save(DitchRider rider)
        {
            using (SqlConnection connection = new SqlConnection (ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO DitchRider (DitchRiderID, DitchRiderFirstName, DitchRiderLastname, DitchRiderPhoneNumber) VALUES (@DitchRiderID, @DitchRiderFirstName, @DitchRiderLastname, @DitchRiderPhoneNumber)";
                    command.CommandType = CommandType.Text;
                    if (rider.DitchRiderID != 0)
                    {
                        command.Parameters.AddWithValue("@DitchRiderID", rider.DitchRiderID);
                    }
                    command.Parameters.AddWithValue("@DitchRiderFirstName", rider.DitchRiderFirstName);
                    command.Parameters.AddWithValue("@DitchRiderLastName", rider.DitchRiderLastName);
                    command.Parameters.AddWithValue("@DitchRiderPhoneNumber", rider.DitchRiderPhoneNumber);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } 
        }
    }
}