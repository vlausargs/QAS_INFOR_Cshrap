//PROJECT NAME: Material
//CLASS NAME: PlanningDetailSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PlanningDetailSaveFactory
	{
		public IPlanningDetailSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PlanningDetailSave = new Material.PlanningDetailSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningDetailSaveExt = timerfactory.Create<Material.IPlanningDetailSave>(_PlanningDetailSave);
			
			return iPlanningDetailSaveExt;
		}
	}
}
