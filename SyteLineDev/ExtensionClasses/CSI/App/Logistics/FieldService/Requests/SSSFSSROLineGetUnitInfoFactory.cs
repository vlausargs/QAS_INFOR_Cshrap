//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLineGetUnitInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROLineGetUnitInfoFactory
	{
		public ISSSFSSROLineGetUnitInfo Create(IApplicationDB appDB)
		{
			var _SSSFSSROLineGetUnitInfo = new Logistics.FieldService.Requests.SSSFSSROLineGetUnitInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROLineGetUnitInfoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROLineGetUnitInfo>(_SSSFSSROLineGetUnitInfo);
			
			return iSSSFSSROLineGetUnitInfoExt;
		}
	}
}
