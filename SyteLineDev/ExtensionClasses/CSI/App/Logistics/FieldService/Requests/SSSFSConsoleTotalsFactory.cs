//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleTotalsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSConsoleTotalsFactory
	{
		public ISSSFSConsoleTotals Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSConsoleTotals = new Logistics.FieldService.Requests.SSSFSConsoleTotals(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConsoleTotalsExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSConsoleTotals>(_SSSFSConsoleTotals);
			
			return iSSSFSConsoleTotalsExt;
		}
	}
}
