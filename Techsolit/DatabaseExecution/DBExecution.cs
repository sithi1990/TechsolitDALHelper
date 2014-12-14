using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Techsolit.DatabaseExecution
{
    public class DBExecution
    {
        private string procname;

        public string ProcedureName
        {
            get { return procname; }
            set { procname = value; }
        }

        object[] o;

        public object[] Parameter
        {
            get { return o; }
            set { o = value; }
        }

        SqlCommand com;
        SqlConnection con = DBCon.getNewConnection();
       
        public static void CommitTransaction()
        {
            DBCon.commit();
        }
       
        public void ExecuteNonQuery()
        {
          
                com = new SqlCommand(procname + " " + getParaString(), con);
                setParams();
                con.Open();
                com.ExecuteNonQuery();
                con.Close();         

        }

        public void ExecuteNonQuery(bool isbegin)
        {
            if (isbegin)
            {
                DBCon.beginTransection();
            }
            com = new SqlCommand(procname + " " + getParaString(), DBCon.Con, DBCon.Transaction);
            setParams();
            com.ExecuteNonQuery();
          
        }

        public object executeScaler()
        {
            com = new SqlCommand(procname + " " + getParaString(), con);
            setParams();
            con.Open();
            object val=com.ExecuteScalar();
            con.Close();
            return val;
        }
        public object executeScaler(bool isbegin)
        {
            if (isbegin)
            {
                DBCon.beginTransection();
            }
            com = new SqlCommand(procname + " " + getParaString(), DBCon.Con, DBCon.Transaction);
            setParams();           
            object val = com.ExecuteScalar();
            return val;
           
        }
        private string getParaString()
        {
            try
            {
                string str = "";

                int numparas = o.Length;
                for (int i = 0; i < o.Length; i++)
                {
                    str += "@" + i.ToString();
                    if (i != (o.Length - 1))
                    {
                        str += ",";
                    }
                }

                return str;
            }
            catch
            {
                return "";
            }
        }

        public DataTable executeReader()
        {
            com = new SqlCommand(procname + " " + getParaString(), con);
            setParams();
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        public DataTable executeReader(bool isbegin)
        {
            com = new SqlCommand(procname + " " + getParaString(), DBCon.Con, DBCon.Transaction);
            setParams();
            if (isbegin)
            {
                DBCon.beginTransection();
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
            else
            {
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
            
        }
        private void setParams()
        {
            try
            {
                for (int i = 0; i < o.Length; i++)
                {
                    com.Parameters.AddWithValue(i.ToString(), o[i]);
                }
            }
            catch
            {
            }
        }
        

    }
}
