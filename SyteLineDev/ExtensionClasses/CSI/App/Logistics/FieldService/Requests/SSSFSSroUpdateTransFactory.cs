//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroUpdateTransFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroUpdateTransFactory
	{
		public ISSSFSSroUpdateTrans Create(IApplicationDB appDB)
		{
			var _SSSFSSroUpdateTrans = new Logistics.FieldService.Requests.SSSFSSroUpdateTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroUpdateTransExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroUpdateTrans>(_SSSFSSroUpdateTrans);
			
			return iSSSFSSroUpdateTransExt;
		}
	}
}
