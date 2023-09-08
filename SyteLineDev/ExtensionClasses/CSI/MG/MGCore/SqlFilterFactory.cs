//PROJECT NAME: Data
//CLASS NAME: SqlFilterFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class SqlFilterFactory
    {
        public ISqlFilter Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _SqlFilter = new SqlFilter(appDB);


            return _SqlFilter;
        }
    }
}
