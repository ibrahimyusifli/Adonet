﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetTask.Data
{
    internal class SQL
    {
        private const string _connectionString = "server=DESKTOP-OD15AGH\\SQLEXPRESS;database=Musicibo;trusted_connection=true;integrated security=true;";
        private static SqlConnection _connection = new SqlConnection(_connectionString);


        public int ExecuteCommand(string cmd)
        {
            int result = 0;
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(cmd, _connection);
                result = command.ExecuteNonQuery();


            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
                adapter.Fill(table);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _connection.Close();
            }


            return table;
        }


    }
}
