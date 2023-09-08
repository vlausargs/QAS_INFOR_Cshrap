//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransPostUtilCleanupFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransPostUtilCleanupFactory
	{
		public ISSSFSSROTransPostUtilCleanup Create(IApplicationDB appDB)
		{
			var _SSSFSSROTransPostUtilCleanup = new Logistics.FieldService.Requests.SSSFSSROTransPostUtilCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransPostUtilCleanupExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransPostUtilCleanup>(_SSSFSSROTransPostUtilCleanup);
			
			return iSSSFSSROTransPostUtilCleanupExt;
		}
	}
}
