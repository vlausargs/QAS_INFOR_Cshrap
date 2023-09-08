//PROJECT NAME: Production
//CLASS NAME: ApsMATLRULEDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMATLRULEDelFactory
	{
		public IApsMATLRULEDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMATLRULEDel = new Production.APS.ApsMATLRULEDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLRULEDelExt = timerfactory.Create<Production.APS.IApsMATLRULEDel>(_ApsMATLRULEDel);
			
			return iApsMATLRULEDelExt;
		}
	}
}
