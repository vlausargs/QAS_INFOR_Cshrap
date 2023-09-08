//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncGetUnitInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncGetUnitInfoFactory
	{
		public ISSSFSIncGetUnitInfo Create(IApplicationDB appDB)
		{
			var _SSSFSIncGetUnitInfo = new Logistics.FieldService.CallCenter.SSSFSIncGetUnitInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncGetUnitInfoExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncGetUnitInfo>(_SSSFSIncGetUnitInfo);
			
			return iSSSFSIncGetUnitInfoExt;
		}
	}
}
