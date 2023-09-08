//PROJECT NAME: Data
//CLASS NAME: ApsMpsOrderIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsMpsOrderIdFactory
    {
        public IApsMpsOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsMpsOrderId = new Functions.ApsMpsOrderId(appDB);

            return _ApsMpsOrderId;
        }
    }
}
