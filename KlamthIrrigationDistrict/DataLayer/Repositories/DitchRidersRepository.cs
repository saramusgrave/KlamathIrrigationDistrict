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
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SELECT * FROM DitchRider WHERE DitchRiderID = @DitchRiderID";
                    command.Parameters.AddWithValue("@DitchRiderID", id);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            dr = new DitchRider();
                            dr.DitchRiderID = int.Parse(reader["DitchRiderID"].ToString());
                            dr.DitchRiderFirstName = reader["DitchRiderFirstName"].ToString();
                            dr.DitchRiderLastname = reader["DitchRiderLastname"].ToString();
                            dr.DitchRiderPhoneNumber = int.Parse(reader["DitchRiderPhoneNumber"].ToString());
                        }
                    }
                }
            }
            return (dr);
        }

        public void Save(DitchRider rider)
        {
            DitchRider dr = null;
            using (SqlConnection connection = new SqlConnection (ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    if (rider.DitchRiderID != 0)
                    {
                        command.Parameters.AddWithValue("@DitchRiderID", rider.DitchRiderID);
                        command.CommandText = "UPDATE DitchRider SET  DitchRiderFirstName = @DitchRiderFirstName, DitchRiderLastname = @DitchRiderLastname, DitchRiderPhoneNumber = @DitchRiderPhoneNumber WHERE DitchRiderID = @DitchRIderID";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO DitchRider (DitchRiderFirstName, DitchRiderLastname, DitchRiderPhoneNumber) VALUES (@DitchRiderFirstName, @DitchRiderLastname, @DitchRiderPhoneNumber)";
                    }
                    command.Parameters.AddWithValue("@DitchRiderFirstName", rider.DitchRiderFirstName);
                    command.Parameters.AddWithValue("@DitchRiderLastname", rider.DitchRiderLastname);
                    command.Parameters.AddWithValue("@DitchRiderPhoneNumber", rider.DitchRiderPhoneNumber);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } 
        }
    }
}