//PROJECT NAME: Logistics
//CLASS NAME: SSSTraceStopFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSTraceStopFactory
	{
		public ISSSTraceStop Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _SSSTraceStop = new Logistics.FieldService.SSSTraceStop(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSTraceStopExt = timerfactory.Create<Logistics.FieldService.ISSSTraceStop>(_SSSTraceStop);

			return iSSSTraceStopExt;
		}
	}
}
