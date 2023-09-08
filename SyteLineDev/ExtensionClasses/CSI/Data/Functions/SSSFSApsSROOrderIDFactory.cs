//PROJECT NAME: Data
//CLASS NAME: SSSFSApsSROOrderIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class SSSFSApsSROOrderIDFactory
    {
        public ISSSFSApsSROOrderID Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _SSSFSApsSROOrderID = new Functions.SSSFSApsSROOrderID(appDB);

            return _SSSFSApsSROOrderID;
        }
    }
}
