//PROJECT NAME: Data
//CLASS NAME: MaxAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class MaxAmtFactory
    {
        public IMaxAmt Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _MaxAmt = new Functions.MaxAmt(appDB);


            return _MaxAmt;
        }
    }
}
