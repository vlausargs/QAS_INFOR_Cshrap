//PROJECT NAME: Data
//CLASS NAME: MinAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class MinAmtFactory
    {
        public IMinAmt Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _MinAmt = new Functions.MinAmt(appDB);


            return _MinAmt;
        }
    }
}
