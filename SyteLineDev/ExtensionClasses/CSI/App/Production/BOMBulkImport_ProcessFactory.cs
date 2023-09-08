//PROJECT NAME: Production
//CLASS NAME: BOMBulkImport_ProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class BOMBulkImport_ProcessFactory
	{
		public IBOMBulkImport_Process Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BOMBulkImport_Process = new Production.BOMBulkImport_Process(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBOMBulkImport_ProcessExt = timerfactory.Create<Production.IBOMBulkImport_Process>(_BOMBulkImport_Process);
			
			return iBOMBulkImport_ProcessExt;
		}
	}
}
