//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncGetItemInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncGetItemInfoFactory
	{
		public ISSSFSIncGetItemInfo Create(IApplicationDB appDB)
		{
			var _SSSFSIncGetItemInfo = new Logistics.FieldService.CallCenter.SSSFSIncGetItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncGetItemInfoExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncGetItemInfo>(_SSSFSIncGetItemInfo);
			
			return iSSSFSIncGetItemInfoExt;
		}
	}
}
