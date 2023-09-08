//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitCustomerUpdateFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitCustomerUpdateFactory
	{
		public ISSSFSUnitCustomerUpdate Create(IApplicationDB appDB)
		{
			var _SSSFSUnitCustomerUpdate = new Logistics.FieldService.SSSFSUnitCustomerUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitCustomerUpdateExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitCustomerUpdate>(_SSSFSUnitCustomerUpdate);
			
			return iSSSFSUnitCustomerUpdateExt;
		}
	}
}
