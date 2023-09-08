//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransGenReimbTaxFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransGenReimbTaxFactory
	{
		public ISSSFSSROTransGenReimbTax Create(IApplicationDB appDB)
		{
			var _SSSFSSROTransGenReimbTax = new Logistics.FieldService.Requests.SSSFSSROTransGenReimbTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransGenReimbTaxExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransGenReimbTax>(_SSSFSSROTransGenReimbTax);
			
			return iSSSFSSROTransGenReimbTaxExt;
		}
	}
}
