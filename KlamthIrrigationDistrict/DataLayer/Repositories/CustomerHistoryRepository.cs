using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KlamthIrrigationDistrict.DataLayer.Interfaces;
using KlamthIrrigationDistrict.DataLayer.DataModels;
using KlamthIrrigationDistrict.Controllers;

namespace KlamthIrrigationDistrict.DataLayer.Repositories
{
    public class CustomerHistoryRepository : ICustomerHistoryRepository
    {
        public virtual List<CustomerHistory> GetList()
        {
            List<CustomerHistory> HistoryList = new List<CustomerHistory>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KIDTEMPLATE"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_CustomerHistory_GetList";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerHistory ch = new CustomerHistory();
                            ch.CustomerHistoryID = int.Parse(reader["CustomerHistoryID"].ToString());
                            ch.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            ch.Date = DateTime.Parse(reader["Date"].ToString());
                            ch.WaterUsage = decimal.Parse(reader["WaterUsage"].ToString());
                            HistoryList.Add(ch);
                        }
                    }                    
                }
            }
            return HistoryList;
        }
    }
}