//PROJECT NAME: Data
//CLASS NAME: HighDecimalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class HighDecimalFactory
    {
        public IHighDecimal Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _HighDecimal = new Functions.HighDecimal(appDB);

            return _HighDecimal;
        }
    }
}
