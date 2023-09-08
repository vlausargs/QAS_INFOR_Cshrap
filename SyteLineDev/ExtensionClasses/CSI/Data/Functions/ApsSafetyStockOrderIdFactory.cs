//PROJECT NAME: Data
//CLASS NAME: ApsSafetyStockOrderIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsSafetyStockOrderIdFactory
    {
        public IApsSafetyStockOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsSafetyStockOrderId = new Functions.ApsSafetyStockOrderId(appDB);

            return _ApsSafetyStockOrderId;
        }
    }
}
