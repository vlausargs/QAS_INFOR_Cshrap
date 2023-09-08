//PROJECT NAME: MGCore
//CLASS NAME: HighStringFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class HighStringFactory : IHighStringFactory
    {
        public IHighString Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _HighString = new HighString(appDB);

            return _HighString;
        }
    }
}
