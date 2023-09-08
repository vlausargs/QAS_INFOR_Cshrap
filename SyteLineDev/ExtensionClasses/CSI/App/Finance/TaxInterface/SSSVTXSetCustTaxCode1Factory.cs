//PROJECT NAME: Finance
//CLASS NAME: SSSVTXSetCustTaxCode1Factory.cs

using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXSetCustTaxCode1Factory
	{
		public ISSSVTXSetCustTaxCode1 Create(IApplicationDB appDB)
		{
			var _SSSVTXSetCustTaxCode1 = new Finance.TaxInterface.SSSVTXSetCustTaxCode1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSVTXSetCustTaxCode1Ext = timerfactory.Create<Finance.TaxInterface.ISSSVTXSetCustTaxCode1>(_SSSVTXSetCustTaxCode1);
			
			return iSSSVTXSetCustTaxCode1Ext;
		}
	}
}
