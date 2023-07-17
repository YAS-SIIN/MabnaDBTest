using Dapper;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MabnaDBTest.CLI
{
    public class TradeData
    {
        public void InsertRandom(int insertCount)
        {
            StringBuilder SqlQuery = new StringBuilder("INSERT INTO dbo.Trades VALUES ");
            Random random = new Random();
            for (int i = 0; i < insertCount; i++)
            {
                SqlQuery.AppendLine($"('{DateTime.Now}', {random.Next(1000,9999)}, {random.Next(1000, 9999)}, {random.Next(100, 999)}, {random.Next(100, 999)}, 1, 1, '{DateTime.Now}', '{DateTime.Now}', '')");
                if (i == insertCount - 1)
                    SqlQuery.Append(";");
                else
                    SqlQuery.Append(",");

            }
            //SqlQuery.Append("Select * From dbo.EMPEmployee");
            IDbConnection dbConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; UID=sa; Password=ABCabc123456;Database=MabnaDB;");
            using (dbConnection)
            {
               var a= dbConnection.Query(SqlQuery.ToString());
            }
        }
    }
}
