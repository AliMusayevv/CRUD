using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConn
{
    internal class DataSource
    {


        public static string DS
        {
            get
            {
                return "Data Source=MARCELINE;Initial Catalog=Northwind;Integrated Security = True";
            }

        }
    }
}