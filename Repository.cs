using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    internal class Repository
    {

        DbContext ctx = new DbContext();
        internal IEnumerable<string> getAccessKeys()
        {
            IEnumerable<string> keys = new List<string>();

            using (var conn = ctx.GetConnection())
            {
                string sql = "SELECT accessKey FROM NFe";

                keys = conn.Query<string>(sql);
            }

            return keys;
        }

        internal string getXmlByKeyAccess(string accessKey)
        {
            string xmls = string.Empty;

            using (var conn = ctx.GetConnection())
            {
                string sql = @"SELECT xml FROM NFe
                                WHERE accesskey like CONCAT('%', @accessKey)
";

                xmls = conn.QueryFirstOrDefault<string>(sql, new { accessKey = accessKey });
            }

            return xmls;
        }
    }
}
