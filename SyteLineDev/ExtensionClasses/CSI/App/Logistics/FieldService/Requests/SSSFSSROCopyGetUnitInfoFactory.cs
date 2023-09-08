//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROCopyGetUnitInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROCopyGetUnitInfoFactory
	{
		public ISSSFSSROCopyGetUnitInfo Create(IApplicationDB appDB)
		{
			var _SSSFSSROCopyGetUnitInfo = new Logistics.FieldService.Requests.SSSFSSROCopyGetUnitInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROCopyGetUnitInfoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROCopyGetUnitInfo>(_SSSFSSROCopyGetUnitInfo);
			
			return iSSSFSSROCopyGetUnitInfoExt;
		}
	}
}
