//PROJECT NAME: Data
//CLASS NAME: AndSqlWhereWithISNULLFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class AndSqlWhereWithISNULLFactory
    {
        public IAndSqlWhereWithISNULL Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _AndSqlWhereWithISNULL = new Functions.AndSqlWhereWithISNULL(appDB);

            return _AndSqlWhereWithISNULL;
        }
    }
}
