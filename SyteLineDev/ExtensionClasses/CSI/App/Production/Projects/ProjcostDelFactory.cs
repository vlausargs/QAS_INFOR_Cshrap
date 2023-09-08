//PROJECT NAME: Production
//CLASS NAME: ProjcostDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjcostDelFactory
	{
		public IProjcostDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjcostDel = new Production.Projects.ProjcostDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjcostDelExt = timerfactory.Create<Production.Projects.IProjcostDel>(_ProjcostDel);
			
			return iProjcostDelExt;
		}
	}
}
