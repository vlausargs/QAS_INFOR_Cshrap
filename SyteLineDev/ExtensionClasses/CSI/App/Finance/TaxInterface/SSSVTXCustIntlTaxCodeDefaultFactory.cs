//PROJECT NAME: Finance
//CLASS NAME: SSSVTXCustIntlTaxCodeDefaultFactory.cs

using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXCustIntlTaxCodeDefaultFactory
	{
		public ISSSVTXCustIntlTaxCodeDefault Create(IApplicationDB appDB)
		{
			var _SSSVTXCustIntlTaxCodeDefault = new Finance.TaxInterface.SSSVTXCustIntlTaxCodeDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSVTXCustIntlTaxCodeDefaultExt = timerfactory.Create<Finance.TaxInterface.ISSSVTXCustIntlTaxCodeDefault>(_SSSVTXCustIntlTaxCodeDefault);
			
			return iSSSVTXCustIntlTaxCodeDefaultExt;
		}
	}
}
