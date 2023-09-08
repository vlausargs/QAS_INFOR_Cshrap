//PROJECT NAME: CSIFinance
//CLASS NAME: ValidateSpecifiedUnitCodeForDistributionFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class ValidateSpecifiedUnitCodeForDistributionFactory
    {
        public IValidateSpecifiedUnitCodeForDistribution Create(IApplicationDB appDB)
        {
            var _ValidateSpecifiedUnitCodeForDistribution = new ValidateSpecifiedUnitCodeForDistribution(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartBpsExt = timerfactory.Create<IValidateSpecifiedUnitCodeForDistribution>(_ValidateSpecifiedUnitCodeForDistribution);

            return iSLChartBpsExt;
        }
    }
}