//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLine_UpdFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipLine_UpdFactory
	{
		public ISSSFSSROPackSlipLine_Upd Create(IApplicationDB appDB)
		{
			var _SSSFSSROPackSlipLine_Upd = new Logistics.FieldService.Requests.SSSFSSROPackSlipLine_Upd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROPackSlipLine_UpdExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROPackSlipLine_Upd>(_SSSFSSROPackSlipLine_Upd);
			
			return iSSSFSSROPackSlipLine_UpdExt;
		}
	}
}
