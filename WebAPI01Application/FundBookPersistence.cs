using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

using System.Collections;
//using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Globalization;
using WebAPI01Application.Models;
using System.Configuration;

namespace WebAPI01Application
{
    public class FundBookPersistence
    {

        public string getFundFactSheet(string fundCode)
        {
            /*
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            */
            OleDbConnection conn = null;
            OleDbCommand command = null;
            OleDbDataReader mySQLReader = null;
            try
            {
                /*
                conn.ConnectionString = myConnectionString;
                conn.Open();
                */
                string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString; ;
                conn = new OleDbConnection(myConnectionString);

                conn.Open();

                command = new OleDbCommand();
                command.Connection = conn;
                command.CommandTimeout = 0;

                //---------------------------------------------------
                command.CommandType = CommandType.Text;
                command.CommandText = "select fund_fact_sheet from azure_mutual_fund where portcode = ?";

                command.Parameters.Clear();

                command.Parameters.AddWithValue("@portcode", fundCode == null ? "" : fundCode.Trim());
                /*
                SqlParameter param = null;

                param = new SqlParameter("@portcode", System.Data.SqlDbType.NVarChar, 20);
                param.Value = fundCode == null ? "" : fundCode.Trim();
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);
                */

                mySQLReader = command.ExecuteReader();

                string url = "";

                while (mySQLReader.Read())
                {
                    url = mySQLReader.GetValue(mySQLReader.GetOrdinal("fund_fact_sheet")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("fund_fact_sheet"));
                }
                mySQLReader.Close();

                return url;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (mySQLReader != null)
                {
                    mySQLReader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public string getMonthlyUpdate(string fundCode)
        {
            /*
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            */
            OleDbConnection conn = null;
            OleDbCommand command = null;
            OleDbDataReader mySQLReader = null;
            try
            {
                /*
                conn.ConnectionString = myConnectionString;
                conn.Open();
                */
                string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString; ;
                conn = new OleDbConnection(myConnectionString);

                conn.Open();

                command = new OleDbCommand();
                command.Connection = conn;
                command.CommandTimeout = 0;

                //---------------------------------------------------
                command.CommandType = CommandType.Text;
                command.CommandText = "select monthly_fund_update from azure_mutual_fund where portcode = ?";

                command.Parameters.Clear();

                command.Parameters.AddWithValue("@portcode", fundCode == null ? "" : fundCode.Trim());
                /*
                SqlParameter param = null;

                param = new SqlParameter("@portcode", System.Data.SqlDbType.NVarChar, 20);
                param.Value = fundCode == null ? "" : fundCode.Trim();
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);
                */

                mySQLReader = command.ExecuteReader();

                string url = "";

                while (mySQLReader.Read())
                {
                    url = mySQLReader.GetValue(mySQLReader.GetOrdinal("monthly_fund_update")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("monthly_fund_update"));
                }
                mySQLReader.Close();

                return url;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (mySQLReader != null)
                {
                    mySQLReader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}