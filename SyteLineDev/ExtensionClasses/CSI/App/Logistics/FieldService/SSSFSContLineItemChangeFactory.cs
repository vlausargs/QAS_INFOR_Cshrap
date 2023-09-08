//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSContLineItemChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineItemChangeFactory
	{
		public ISSSFSContLineItemChange Create(IApplicationDB appDB)
		{
			var _SSSFSContLineItemChange = new Logistics.FieldService.SSSFSContLineItemChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContLineItemChangeExt = timerfactory.Create<Logistics.FieldService.ISSSFSContLineItemChange>(_SSSFSContLineItemChange);
			
			return iSSSFSContLineItemChangeExt;
		}
	}
}
