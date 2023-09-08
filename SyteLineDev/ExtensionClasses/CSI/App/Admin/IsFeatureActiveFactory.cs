//PROJECT NAME: Codes
//CLASS NAME: IsFeatureActiveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
    public class IsFeatureActiveFactory
    {
        public IIsFeatureActive Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _IsFeatureActive = new Admin.IsFeatureActive(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iIsFeatureActiveExt = timerfactory.Create<Admin.IIsFeatureActive>(_IsFeatureActive);

            return iIsFeatureActiveExt;
        }
    }
}
