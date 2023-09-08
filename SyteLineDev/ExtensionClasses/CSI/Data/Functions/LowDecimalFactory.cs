//PROJECT NAME: Data
//CLASS NAME: LowDecimalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class LowDecimalFactory
    {
        public ILowDecimal Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _LowDecimal = new Functions.LowDecimal(appDB);

            return _LowDecimal;
        }
    }
}
