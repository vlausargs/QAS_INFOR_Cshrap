//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetUnitInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetUnitInfoFactory
	{
		public ISSSFSGetUnitInfo Create(IApplicationDB appDB)
		{
			var _SSSFSGetUnitInfo = new Logistics.FieldService.SSSFSGetUnitInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetUnitInfoExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetUnitInfo>(_SSSFSGetUnitInfo);
			
			return iSSSFSGetUnitInfoExt;
		}
	}
}
