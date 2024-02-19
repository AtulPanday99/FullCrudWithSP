using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_With_ADO.Models
{
    public class DBManager
    {
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        //Function to Insert,Update and Delete
        internal bool ExecuteMyNonQuery(string MyCommand)
        {
            SqlCommand cmd = new SqlCommand(MyCommand,con);
            if(con.State==ConnectionState.Closed)
               con.Open();
            int n=cmd.ExecuteNonQuery();
            con.Close();
            return n > 0 ? true : false ;
        }
        //Function to Show All Record
        internal DataTable ExecuteMyQuery(string MyCommand)
        {
            SqlDataAdapter da = new SqlDataAdapter(MyCommand,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Function to Show Single Record
        internal object GetSingleValue(string MyCommand)
        {
            SqlCommand cmd=new SqlCommand(MyCommand,con);
            if(con.State==ConnectionState.Closed)
                con.Open();
            object obj=cmd.ExecuteScalar();
            con.Close() ;
            return obj;
        }
    }
}