//PROJECT NAME: Data
//CLASS NAME: MinQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class MinQtyFactory
    {
        public IMinQty Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _MinQty = new Functions.MinQty(appDB);


            return _MinQty;
        }
    }
}
