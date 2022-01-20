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
    public class FundPFPersistance_backup
    {
        public long saveNAV(FundPF navToSave)
        {
            /*
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                //string sqlString = "INSERT INTO 'bblam'.'nav' ('PORTCODE', 'TRAN_DATE', 'NAV_BF_FEE', 'NAV_AMOUNT', 'NAV_PER_UNIT', 'UNIT_AMOUNT', 'OFFER_PRICE', 'BID_PRICE', 'Flag') VALUES ('" + navToSave.PORTCODE + "','" + navToSave.TRAN_DATE + "','" + navToSave.NAV_BF_FEE + "','" + navToSave.NAV_AMOUNT + "','" + navToSave.NAV_PER_UNIT + "','" + navToSave.UNIT_AMOUNT + "','" + navToSave.OFFER_PRICE + "','" + navToSave.BID_PRICE + "','" + navToSave.Flag + "');";
                string sqlString = "";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            */
            long id = 0;
            return id;
        }
        
        public ArrayList getFundPFs()
        {
            /*
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                ArrayList navArray = new ArrayList();

                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "select * from bblamapidb.azure_nav where id = 0";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySQLReader = cmd.ExecuteReader();
                
                while (mySQLReader.Read())
                {
                    NAV n = new NAV();
                    n.Id = mySQLReader.GetInt32(0);
                    n.PORTCODE = mySQLReader.GetString(1);
                    n.TRAN_DATE = mySQLReader.GetDateTime(2).ToString("dd/MM/yyy", CultureInfo.CreateSpecificCulture("en-US"));
                    n.NAV_BF_FEE = mySQLReader.GetFloat(3);
                    n.NAV_AMOUNT = mySQLReader.GetFloat(4);
                    n.NAV_PER_UNIT = mySQLReader.GetFloat(5);
                    n.UNIT_AMOUNT = mySQLReader.GetFloat(6);
                    n.OFFER_PRICE = mySQLReader.GetFloat(7);
                    n.BID_PRICE = mySQLReader.GetFloat(8);
                    n.Flag = mySQLReader.GetInt32(9);
                    navArray.Add(n);
                }
                
                return navArray;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
*/
            ArrayList navArray = new ArrayList();
            return navArray;
        }

 
        public ArrayList getFundPFDate(string dt)
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

                ArrayList fundPFArray = new ArrayList();

                /*MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                //string sqlString = "select * from bblamapidb.azure_dividend where id=1";// tran_date = '" + dt + "'";
                string sqlString = "SP_FundPF";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dt", dt);

                //double? double_null;
                //string<T>? string_null = null;

                mySQLReader = cmd.ExecuteReader();
                */
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_FundPF";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@dt", dt);
                mySQLReader = command.ExecuteReader();

                //CultureInfo culture = new CultureInfo(cultureName);

                while (mySQLReader.Read())
                {
                    FundPF fpf = new FundPF();
                    //n.Id = mySQLReader.GetInt32(mySQLReader.GetOrdinal("Id"));
                    fpf.FUND_KIND = mySQLReader.GetValue(mySQLReader.GetOrdinal("FUND KIND")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("FUND KIND"));
                    fpf.FUND_TYPE = mySQLReader.GetValue(mySQLReader.GetOrdinal("FUND TYPE")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("FUND TYPE"));
                    fpf.PORT_CODE = mySQLReader.GetValue(mySQLReader.GetOrdinal("PORTCODE")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("PORTCODE"));
                    fpf.AMC_CODE = mySQLReader.GetValue(mySQLReader.GetOrdinal("AMC CODE")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("AMC CODE"));
                    fpf.AMC_NAME = mySQLReader.GetValue(mySQLReader.GetOrdinal("AMC NAME")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("AMC NAME"));
                    fpf.FUND_NAME_TH = mySQLReader.GetValue(mySQLReader.GetOrdinal("FUND NAME TH")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("FUND NAME TH"));
                    fpf.FUND_NAME_EN = mySQLReader.GetValue(mySQLReader.GetOrdinal("FUND NAME EN")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("FUND NAME EN"));
                    fpf.FUND_CODE = mySQLReader.GetValue(mySQLReader.GetOrdinal("FUND CODE")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("FUND CODE"));
                    fpf.AUM = mySQLReader.GetValue(mySQLReader.GetOrdinal("AUM")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("AUM"));
                    fpf.NAV = mySQLReader.GetValue(mySQLReader.GetOrdinal("NAV")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("NAV"));
                    fpf.DIVIDEND = mySQLReader.GetValue(mySQLReader.GetOrdinal("DIVIDEND")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("DIVIDEND"));
                    fpf.DIVIDEND_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("DIVIDEND DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("DIVIDEND DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.PRICE = mySQLReader.GetValue(mySQLReader.GetOrdinal("PRICE")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("PRICE"));
                    fpf.REDEMPTION_PRICE = mySQLReader.GetValue(mySQLReader.GetOrdinal("REDEMPTION PRICE")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("REDEMPTION PRICE"));
                    //fpf.MINIMUM_FIRST_ORDER = mySQLReader.GetValue(mySQLReader.GetOrdinal("MINIMUM FIRST ORDER")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("MINIMUM FIRST ORDER"));
                    fpf.MINIMUM_FIRST_ORDER = mySQLReader.GetValue(mySQLReader.GetOrdinal("MINIMUM FIRST ORDER")).Equals(DBNull.Value) ? 0 : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("MINIMUM FIRST ORDER"));
                    //fpf.MINIMUM_NEXT_ORDER = mySQLReader.GetValue(mySQLReader.GetOrdinal("MINIMUM NEXT ORDER")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("MINIMUM NEXT ORDER"));
                    fpf.MINIMUM_NEXT_ORDER = mySQLReader.GetValue(mySQLReader.GetOrdinal("MINIMUM NEXT ORDER")).Equals(DBNull.Value) ? 0 : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("MINIMUM NEXT ORDER"));
                    fpf.MANAGEMENT_FEE = mySQLReader.GetValue(mySQLReader.GetOrdinal("MANAGEMENT FEE")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("MANAGEMENT FEE"));
                    fpf.INCEPTION_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("INCEPTION DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("INCEPTION DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    //fpf.INCEPTION_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("INCEPTION DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetValue(mySQLReader.GetOrdinal("INCEPTION DATE")).ToString();
                    fpf.RISK = mySQLReader.GetValue(mySQLReader.GetOrdinal("RISK")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RISK"));
                    fpf.RETURN_1D = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_1D")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_1D"));
                    fpf.RETURN_1M = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_1M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_1M"));
                    fpf.RETURN_3M = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_3M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_3M"));
                    fpf.RETURN_6M = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_6M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_6M"));
                    fpf.RETURN_YTD = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_YTD")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_YTD"));
                    fpf.RETURN_1Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_1Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_1Y"));
                    fpf.RETURN_3Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_3Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_3Y"));
                    fpf.RETURN_5Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_5Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_5Y"));
                    fpf.SD_1D = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_1D")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_1D"));
                    fpf.SD_1M = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_1M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_1M"));
                    fpf.SD_3M = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_3M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_3M"));
                    fpf.SD_6M = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_6M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_6M"));
                    fpf.SD_YTD = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_YTD")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_YTD"));
                    fpf.SD_1Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_1Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_1Y"));
                    fpf.SD_3Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_3Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_3Y"));
                    fpf.SD_5Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_5Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_5Y"));
                    fpf.BENCHMARK_YTD = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK YTD")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK YTD"));
                    fpf.BENCHMARK_3M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK 3M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK 3M"));
                    fpf.BENCHMARK_6M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK 6M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK 6M"));
                    fpf.BENCHMARK_1Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK 1Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK 1Y"));
                    fpf.BENCHMARK_3Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK 3Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK 3Y"));
                    fpf.BENCHMARK_5Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK 5Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK 5Y"));
                    fpf.BENCHMARK_NAME = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK NAME")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("BENCHMARK NAME")).Equals(DBNull.Value) ? "" : mySQLReader.GetString(mySQLReader.GetOrdinal("BENCHMARK NAME"));
                    fpf.RETURN_1D_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_1D_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_1D_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_1M_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_1M_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_1M_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_3M_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_3M_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_3M_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_6M_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_6M_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_6M_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_YTD_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_YTD_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_YTD_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_1Y_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_1Y_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_1Y_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_3Y_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_3Y_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_3Y_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_5Y_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_5Y_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_5Y_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.RETURN_INC = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_INC")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("RETURN_INC"));
                    fpf.RETURN_INC_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("RETURN_INC_DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("RETURN_INC_DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.SD_INC = mySQLReader.GetValue(mySQLReader.GetOrdinal("SD_INC")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("SD_INC"));
                    fpf.BENCHMARK_SD_1D = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_1D")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_1D"));
                    fpf.BENCHMARK_SD_1M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_1M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_1M"));
                    fpf.BENCHMARK_SD_3M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_3M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_3M"));
                    fpf.BENCHMARK_SD_6M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_6M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_6M"));
                    fpf.BENCHMARK_SD_YTD = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_YTD")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_YTD"));
                    fpf.BENCHMARK_SD_1Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_1Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_1Y"));
                    fpf.BENCHMARK_SD_3Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_3Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_3Y"));
                    fpf.BENCHMARK_SD_5Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_5Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_5Y"));
                    fpf.BENCHMARK_SD_INC = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD_INC")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD_INC"));
                    fpf.BENCHMARK_INC = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK INC")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK INC"));
                    fpf.BENCHMARK2_NAME = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 NAME")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("BENCHMARK2 NAME"));
                    fpf.BENCHMARK2_YTD = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 YTD")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 YTD"));
                    fpf.BENCHMARK2_3M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 3M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 3M"));
                    fpf.BENCHMARK2_6M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 6M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 6M"));
                    fpf.BENCHMARK2_1Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 1Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 1Y"));
                    fpf.BENCHMARK2_3Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 3Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 3Y"));
                    fpf.BENCHMARK2_5Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 5Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 5Y"));
                    fpf.BENCHMARK2_INC = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK2 INC")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK2 INC"));
                    fpf.BENCHMARK_SD2_1D = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_1D")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_1D"));
                    fpf.BENCHMARK_SD2_1M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_1M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_1M"));
                    fpf.BENCHMARK_SD2_3M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_3M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_3M"));
                    fpf.BENCHMARK_SD2_6M = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_6M")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_6M"));
                    fpf.BENCHMARK_SD2_YTD = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_YTD")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_YTD"));
                    fpf.BENCHMARK_SD2_1Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_1Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_1Y"));
                    fpf.BENCHMARK_SD2_3Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_3Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_3Y"));
                    fpf.BENCHMARK_SD2_5Y = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_5Y")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_5Y"));
                    fpf.BENCHMARK_SD2_INC = mySQLReader.GetValue(mySQLReader.GetOrdinal("BENCHMARK_SD2_INC")).Equals(DBNull.Value) ? null : (double?)mySQLReader.GetDouble(mySQLReader.GetOrdinal("BENCHMARK_SD2_INC"));
                    fpf.NAV_DATE = mySQLReader.GetValue(mySQLReader.GetOrdinal("NAV DATE")).Equals(DBNull.Value) ? null : mySQLReader.GetDateTime(mySQLReader.GetOrdinal("NAV DATE")).ToString("yyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    fpf.Fund_Fact_Sheet = mySQLReader.GetValue(mySQLReader.GetOrdinal("Fund_Fact_Sheet")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("Fund_Fact_Sheet"));
                    fpf.Monthly_Fund_Update = mySQLReader.GetValue(mySQLReader.GetOrdinal("Monthly_Fund_Update")).Equals(DBNull.Value) ? null : mySQLReader.GetString(mySQLReader.GetOrdinal("Monthly_Fund_Update"));
                    fundPFArray.Add(fpf);
                }
                mySQLReader.Close();

                return fundPFArray;
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