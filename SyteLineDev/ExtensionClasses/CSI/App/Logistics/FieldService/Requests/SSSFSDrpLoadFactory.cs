//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDrpLoadFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSDrpLoadFactory
	{
		public ISSSFSDrpLoad Create(IApplicationDB appDB)
		{
			var _SSSFSDrpLoad = new Logistics.FieldService.Requests.SSSFSDrpLoad(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDrpLoadExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSDrpLoad>(_SSSFSDrpLoad);
			
			return iSSSFSDrpLoadExt;
		}
	}
}
