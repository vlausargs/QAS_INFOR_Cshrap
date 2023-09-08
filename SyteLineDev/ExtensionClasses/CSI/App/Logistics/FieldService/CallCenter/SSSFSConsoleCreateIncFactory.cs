//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleCreateIncFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSConsoleCreateIncFactory
	{
		public ISSSFSConsoleCreateInc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSConsoleCreateInc = new Logistics.FieldService.CallCenter.SSSFSConsoleCreateInc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConsoleCreateIncExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSConsoleCreateInc>(_SSSFSConsoleCreateInc);
			
			return iSSSFSConsoleCreateIncExt;
		}
	}
}
