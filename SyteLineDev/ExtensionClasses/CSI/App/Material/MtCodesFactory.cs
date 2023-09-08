//PROJECT NAME: Material
//CLASS NAME: MtCodesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
    public class MtCodesFactory
    {
        public IMtCodes Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _MtCodes = new Material.MtCodes(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMtCodesExt = timerfactory.Create<Material.IMtCodes>(_MtCodes);

            return iMtCodesExt;
        }
    }
}
