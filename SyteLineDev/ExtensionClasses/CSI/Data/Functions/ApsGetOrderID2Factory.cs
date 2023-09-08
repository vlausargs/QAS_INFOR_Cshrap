//PROJECT NAME: Data
//CLASS NAME: ApsGetOrderID2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsGetOrderID2Factory
    {
        public IApsGetOrderID2 Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsGetOrderID2 = new Functions.ApsGetOrderID2(appDB);

            return _ApsGetOrderID2;
        }
    }
}
