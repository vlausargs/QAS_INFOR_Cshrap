//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROGetItemInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROGetItemInfoFactory
	{
		public ISSSFSSROGetItemInfo Create(IApplicationDB appDB)
		{
			var _SSSFSSROGetItemInfo = new Logistics.FieldService.Requests.SSSFSSROGetItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROGetItemInfoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROGetItemInfo>(_SSSFSSROGetItemInfo);
			
			return iSSSFSSROGetItemInfoExt;
		}
	}
}
