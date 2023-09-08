//PROJECT NAME: Production
//CLASS NAME: CheckMatlCBPctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CheckMatlCBPctFactory
	{
		public ICheckMatlCBPct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckMatlCBPct = new Production.CheckMatlCBPct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckMatlCBPctExt = timerfactory.Create<Production.ICheckMatlCBPct>(_CheckMatlCBPct);
			
			return iCheckMatlCBPctExt;
		}
	}
}
