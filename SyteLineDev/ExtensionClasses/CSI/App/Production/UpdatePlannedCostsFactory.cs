//PROJECT NAME: Production
//CLASS NAME: UpdatePlannedCostsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class UpdatePlannedCostsFactory
	{
		public IUpdatePlannedCosts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdatePlannedCosts = new Production.UpdatePlannedCosts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePlannedCostsExt = timerfactory.Create<Production.IUpdatePlannedCosts>(_UpdatePlannedCosts);
			
			return iUpdatePlannedCostsExt;
		}
	}
}
