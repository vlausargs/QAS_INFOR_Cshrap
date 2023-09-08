//PROJECT NAME: Data
//CLASS NAME: ApsOrderIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsOrderIdFactory
    {
        public IApsOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsOrderId = new Functions.ApsOrderId(appDB);

            return _ApsOrderId;
        }
    }
}
