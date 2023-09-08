//PROJECT NAME: Production
//CLASS NAME: OPRULEDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class OPRULEDelFactory
	{
		public IOPRULEDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _OPRULEDel = new Production.APS.OPRULEDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOPRULEDelExt = timerfactory.Create<Production.APS.IOPRULEDel>(_OPRULEDel);
			
			return iOPRULEDelExt;
		}
	}
}
