//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroMiscRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroMiscRateFactory
	{
		public ISSSFSSroMiscRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSroMiscRate = new Logistics.FieldService.Requests.SSSFSSroMiscRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroMiscRateExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroMiscRate>(_SSSFSSroMiscRate);
			
			return iSSSFSSroMiscRateExt;
		}
	}
}
