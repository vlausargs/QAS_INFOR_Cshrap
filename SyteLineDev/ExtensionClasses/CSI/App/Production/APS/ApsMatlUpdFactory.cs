//PROJECT NAME: Production
//CLASS NAME: ApsMatlUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMatlUpdFactory
	{
		public IApsMatlUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMatlUpd = new Production.APS.ApsMatlUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMatlUpdExt = timerfactory.Create<Production.APS.IApsMatlUpd>(_ApsMatlUpd);
			
			return iApsMatlUpdExt;
		}
	}
}
