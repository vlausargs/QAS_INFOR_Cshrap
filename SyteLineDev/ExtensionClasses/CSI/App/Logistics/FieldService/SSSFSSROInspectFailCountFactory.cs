//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSSROInspectFailCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInspectFailCountFactory
	{
		public ISSSFSSROInspectFailCount Create(IApplicationDB appDB)
		{
			var _SSSFSSROInspectFailCount = new Logistics.FieldService.SSSFSSROInspectFailCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROInspectFailCountExt = timerfactory.Create<Logistics.FieldService.ISSSFSSROInspectFailCount>(_SSSFSSROInspectFailCount);
			
			return iSSSFSSROInspectFailCountExt;
		}
	}
}
