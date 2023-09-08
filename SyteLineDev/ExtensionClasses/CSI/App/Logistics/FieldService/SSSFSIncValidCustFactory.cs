//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncValidCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSIncValidCustFactory
	{
		public ISSSFSIncValidCust Create(IApplicationDB appDB)
		{
			var _SSSFSIncValidCust = new Logistics.FieldService.SSSFSIncValidCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncValidCustExt = timerfactory.Create<Logistics.FieldService.ISSSFSIncValidCust>(_SSSFSIncValidCust);
			
			return iSSSFSIncValidCustExt;
		}
	}
}
