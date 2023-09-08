//PROJECT NAME: Production
//CLASS NAME: OPRULESaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class OPRULESaveFactory
	{
		public IOPRULESave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _OPRULESave = new Production.APS.OPRULESave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOPRULESaveExt = timerfactory.Create<Production.APS.IOPRULESave>(_OPRULESave);
			
			return iOPRULESaveExt;
		}
	}
}
