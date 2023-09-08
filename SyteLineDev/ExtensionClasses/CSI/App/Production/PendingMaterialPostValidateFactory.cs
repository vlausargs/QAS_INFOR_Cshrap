//PROJECT NAME: CSIProduct
//CLASS NAME: PendingMaterialPostValidateFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PendingMaterialPostValidateFactory
    {
        public IPendingMaterialPostValidate Create(IApplicationDB appDB)
        {
            var _PendingMaterialPostValidate = new PendingMaterialPostValidate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPendingMaterialPostValidateExt = timerfactory.Create<IPendingMaterialPostValidate>(_PendingMaterialPostValidate);

            return iPendingMaterialPostValidateExt;
        }
    }
}
