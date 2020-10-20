using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using LinqToDB.Mapping;
using Models;
using LinqToDB;

namespace Connection
{
    public class Connections : DataConnection
    {
        /*
        public Connections() : base(new  LinqToDB.DataProvider.MySql.MySqlDataProvider(""),
            "Server=localhost; Port=3306; Database=sales_system;Uid=root;Pwd='';charset=utf8;SslMode=none")
        {

        }*/
        public Connections() : base(new SqlServerDataProvider("", SqlServerVersion.v2017),
            "Data Source=UNKNOWN\\SQLEXPRESS;Database=sales_system;Integrated Security=True;")
        {

        }
        public ITable<TUsers> TUsers => GetTable<TUsers>();
    }
}
