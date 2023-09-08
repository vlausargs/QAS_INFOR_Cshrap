//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroValidCustCurrencyFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroValidCustCurrencyFactory
	{
		public ISSSFSSroValidCustCurrency Create(IApplicationDB appDB)
		{
			var _SSSFSSroValidCustCurrency = new Logistics.FieldService.Requests.SSSFSSroValidCustCurrency(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroValidCustCurrencyExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroValidCustCurrency>(_SSSFSSroValidCustCurrency);
			
			return iSSSFSSroValidCustCurrencyExt;
		}
	}
}
