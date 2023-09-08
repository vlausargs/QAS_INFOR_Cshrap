//PROJECT NAME: Production
//CLASS NAME: ApsMatlDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMatlDelFactory
	{
		public IApsMatlDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMatlDel = new Production.APS.ApsMatlDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMatlDelExt = timerfactory.Create<Production.APS.IApsMatlDel>(_ApsMatlDel);
			
			return iApsMatlDelExt;
		}
	}
}
