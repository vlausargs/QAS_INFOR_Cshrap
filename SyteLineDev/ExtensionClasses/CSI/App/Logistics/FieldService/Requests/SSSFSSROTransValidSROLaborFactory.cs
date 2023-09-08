//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValidSROLaborFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValidSROLaborFactory
	{
		public ISSSFSSROTransValidSROLabor Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransValidSROLabor = new Logistics.FieldService.Requests.SSSFSSROTransValidSROLabor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransValidSROLaborExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransValidSROLabor>(_SSSFSSROTransValidSROLabor);
			
			return iSSSFSSROTransValidSROLaborExt;
		}
	}
}
