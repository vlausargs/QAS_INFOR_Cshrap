//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipHdr_UpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipHdr_UpdFactory
	{
		public ISSSFSSROPackSlipHdr_Upd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROPackSlipHdr_Upd = new Logistics.FieldService.Requests.SSSFSSROPackSlipHdr_Upd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROPackSlipHdr_UpdExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROPackSlipHdr_Upd>(_SSSFSSROPackSlipHdr_Upd);
			
			return iSSSFSSROPackSlipHdr_UpdExt;
		}
	}
}
