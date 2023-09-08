//PROJECT NAME: Data
//CLASS NAME: RefSetDescFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
    public class RefSetDescFactory
    {
        public IRefSetDesc Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _RefSetDesc = new RefSetDesc(appDB);

            return _RefSetDesc;
        }
    }
}
