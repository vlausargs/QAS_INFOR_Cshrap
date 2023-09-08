//PROJECT NAME: Data
//CLASS NAME: ApsProjectOrderIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsProjectOrderIdFactory
    {
        public IApsProjectOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsProjectOrderId = new Functions.ApsProjectOrderId(appDB);

            return _ApsProjectOrderId;
        }
    }
}
