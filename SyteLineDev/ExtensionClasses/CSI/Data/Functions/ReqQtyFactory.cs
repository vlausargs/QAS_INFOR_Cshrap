//PROJECT NAME: Data
//CLASS NAME: ReqQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ReqQtyFactory
    {
        public IReqQty Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ReqQty = new Functions.ReqQty(appDB);

            return _ReqQty;
        }
    }
}
