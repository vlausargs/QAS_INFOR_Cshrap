//PROJECT NAME: Production
//CLASS NAME: ApsMATLRULESaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMATLRULESaveFactory
	{
		public IApsMATLRULESave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMATLRULESave = new Production.APS.ApsMATLRULESave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLRULESaveExt = timerfactory.Create<Production.APS.IApsMATLRULESave>(_ApsMATLRULESave);
			
			return iApsMATLRULESaveExt;
		}
	}
}
