//PROJECT NAME: CSITaxInterface
//CLASS NAME: SSSVTXAvaTaxExemptProcessWrapperFactory.cs

using CSI.MG;

namespace CSI.Finance.TaxInterface
{
    public class SSSVTXAvaTaxExemptProcessWrapperFactory
    {
        public ISSSVTXAvaTaxExemptProcessWrapper Create(IApplicationDB appDB)
        {
            var _SSSVTXAvaTaxExemptProcessWrapper = new SSSVTXAvaTaxExemptProcessWrapper(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSVTXAvaTaxExemptProcessWrapperExt = timerfactory.Create<ISSSVTXAvaTaxExemptProcessWrapper>(_SSSVTXAvaTaxExemptProcessWrapper);

            return iSSSVTXAvaTaxExemptProcessWrapperExt;
        }
    }
}
