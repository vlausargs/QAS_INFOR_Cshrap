using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.SQL
{
    public class SQLBulkCopyFactory : ISQLBulkCopyFactory
    {
        public SQLBulkCopyFactory()
        {
        }

        public ISQLBulkCopy Create(ICommandProvider commandProvider)
        {
            return new SQLBulkCopy(null, commandProvider);
        }
    }
}
