//PROJECT NAME: CSIAdmin
//CLASS NAME: JourHdrValidateFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class JourHdrValidateFactory
    {
        public IJourHdrValidate Create(IApplicationDB appDB)
        {
            var _JourHdrValidate = new JourHdrValidate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJourHdrValidateExt = timerfactory.Create<IJourHdrValidate>(_JourHdrValidate);

            return iJourHdrValidateExt;
        }
    }
}
