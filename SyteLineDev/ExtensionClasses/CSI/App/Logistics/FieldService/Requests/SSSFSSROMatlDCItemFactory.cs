//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROMatlDCItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROMatlDCItemFactory
	{
		public ISSSFSSROMatlDCItem Create(IApplicationDB appDB)
		{
			var _SSSFSSROMatlDCItem = new Logistics.FieldService.Requests.SSSFSSROMatlDCItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROMatlDCItemExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROMatlDCItem>(_SSSFSSROMatlDCItem);
			
			return iSSSFSSROMatlDCItemExt;
		}
	}
}
