//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckConsignmentReplenishmentPOFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CheckConsignmentReplenishmentPOFactory
    {
        public ICheckConsignmentReplenishmentPO Create(IApplicationDB appDB)
        {
            var _CheckConsignmentReplenishmentPO = new CheckConsignmentReplenishmentPO(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckConsignmentReplenishmentPOExt = timerfactory.Create<ICheckConsignmentReplenishmentPO>(_CheckConsignmentReplenishmentPO);

            return iCheckConsignmentReplenishmentPOExt;
        }
    }
}
