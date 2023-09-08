//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLine_ShipOneFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipLine_ShipOneFactory
	{
		public ISSSFSSROPackSlipLine_ShipOne Create(IApplicationDB appDB)
		{
			var _SSSFSSROPackSlipLine_ShipOne = new Logistics.FieldService.Requests.SSSFSSROPackSlipLine_ShipOne(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROPackSlipLine_ShipOneExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROPackSlipLine_ShipOne>(_SSSFSSROPackSlipLine_ShipOne);
			
			return iSSSFSSROPackSlipLine_ShipOneExt;
		}
	}
}
