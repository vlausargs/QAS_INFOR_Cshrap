//PROJECT NAME: Production
//CLASS NAME: ProjPackSlipQtyValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjPackSlipQtyValidFactory
	{
		public IProjPackSlipQtyValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjPackSlipQtyValid = new Production.Projects.ProjPackSlipQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjPackSlipQtyValidExt = timerfactory.Create<Production.Projects.IProjPackSlipQtyValid>(_ProjPackSlipQtyValid);
			
			return iProjPackSlipQtyValidExt;
		}
	}
}
