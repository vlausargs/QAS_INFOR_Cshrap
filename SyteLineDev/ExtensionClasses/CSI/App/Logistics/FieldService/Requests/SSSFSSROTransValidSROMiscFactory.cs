//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValidSROMiscFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValidSROMiscFactory
	{
		public ISSSFSSROTransValidSROMisc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransValidSROMisc = new Logistics.FieldService.Requests.SSSFSSROTransValidSROMisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransValidSROMiscExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransValidSROMisc>(_SSSFSSROTransValidSROMisc);
			
			return iSSSFSSROTransValidSROMiscExt;
		}
	}
}
