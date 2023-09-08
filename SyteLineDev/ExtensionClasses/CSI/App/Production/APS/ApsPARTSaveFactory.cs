//PROJECT NAME: Production
//CLASS NAME: ApsPARTSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsPARTSaveFactory
	{
		public IApsPARTSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsPARTSave = new Production.APS.ApsPARTSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsPARTSaveExt = timerfactory.Create<Production.APS.IApsPARTSave>(_ApsPARTSave);
			
			return iApsPARTSaveExt;
		}
	}
}
