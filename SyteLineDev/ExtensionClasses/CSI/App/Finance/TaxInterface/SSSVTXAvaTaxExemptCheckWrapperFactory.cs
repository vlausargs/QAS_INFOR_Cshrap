//PROJECT NAME: CSITaxInterface
//CLASS NAME: SSSVTXAvaTaxExemptCheckWrapperFactory.cs

using CSI.MG;

namespace CSI.Finance.TaxInterface
{
    public class SSSVTXAvaTaxExemptCheckWrapperFactory
    {
        public ISSSVTXAvaTaxExemptCheckWrapper Create(IApplicationDB appDB)
        {
            var _SSSVTXAvaTaxExemptCheckWrapper = new SSSVTXAvaTaxExemptCheckWrapper(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSVTXAvaTaxExemptCheckWrapperExt = timerfactory.Create<ISSSVTXAvaTaxExemptCheckWrapper>(_SSSVTXAvaTaxExemptCheckWrapper);

            return iSSSVTXAvaTaxExemptCheckWrapperExt;
        }
    }
}
