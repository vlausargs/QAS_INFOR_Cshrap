//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetItemInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetItemInfoFactory
	{
		public ISSSFSGetItemInfo Create(IApplicationDB appDB)
		{
			var _SSSFSGetItemInfo = new Logistics.FieldService.SSSFSGetItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetItemInfoExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetItemInfo>(_SSSFSGetItemInfo);
			
			return iSSSFSGetItemInfoExt;
		}
	}
}
