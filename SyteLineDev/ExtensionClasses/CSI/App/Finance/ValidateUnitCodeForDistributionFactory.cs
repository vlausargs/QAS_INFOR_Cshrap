//PROJECT NAME: CSIFinance
//CLASS NAME: ValidateUnitCodeForDistributionFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class ValidateUnitCodeForDistributionFactory
    {
        public IValidateUnitCodeForDistribution Create(IApplicationDB appDB)
        {
            var _ValidateUnitCodeForDistribution = new ValidateUnitCodeForDistribution(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartBpsExt = timerfactory.Create<IValidateUnitCodeForDistribution>(_ValidateUnitCodeForDistribution);

            return iSLChartBpsExt;
        }
    }
}
