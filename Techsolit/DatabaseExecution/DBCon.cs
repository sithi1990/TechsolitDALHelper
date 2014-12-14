using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Techsolit.DatabaseExecution
{
    public class DBCon
    {
        static SqlConnection con;
        

        static SqlTransaction tr;


        static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        
     
        public static void connect()
        {
            con = new SqlConnection(constr);
        }
        public static SqlConnection getNewConnection()
        {
            return new SqlConnection(constr);
        }
        public static SqlConnection Con
        {           
            get
            {
                return con;
            }
        }
        public static void beginTransection()
        {
            
            con = new SqlConnection(constr);
            con.Open();
            tr = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
        }
        public static void commit()
        {
            tr.Commit();
            con.Close();
        }
        public static void rollback()
        {
            tr.Rollback();
            con.Close();
        }
        public static SqlTransaction Transaction
        {
            get
            {
                
                return tr;
            }
        }
        
    }
}
