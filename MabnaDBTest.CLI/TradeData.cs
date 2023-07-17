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
            StringBuilder SqlQuery = new StringBuilder("Select * From dbo.EMPEmployees");
            for (int i = 0; i < insertCount; i++)
            {
                SqlQuery.AppendLine("");
            }
            //SqlQuery.Append("Select * From dbo.EMPEmployee");
            IDbConnection dbConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; UID=sa; Password=ABCabc123456;Database=ERP;");
            using (dbConnection)
            {
               var a= dbConnection.Query(SqlQuery.ToString());
            }
        }
    }
}
