//PROJECT NAME: Data
//CLASS NAME: ApsTransferOutOrderIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsTransferOutOrderIdFactory
    {
        public IApsTransferOutOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsTransferOutOrderId = new Functions.ApsTransferOutOrderId(appDB);

            return _ApsTransferOutOrderId;
        }
    }
}
