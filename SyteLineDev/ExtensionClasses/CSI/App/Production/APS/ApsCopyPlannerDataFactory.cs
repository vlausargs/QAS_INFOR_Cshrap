//PROJECT NAME: Production
//CLASS NAME: ApsCopyPlannerDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsCopyPlannerDataFactory
	{
		public IApsCopyPlannerData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsCopyPlannerData = new Production.APS.ApsCopyPlannerData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsCopyPlannerDataExt = timerfactory.Create<Production.APS.IApsCopyPlannerData>(_ApsCopyPlannerData);
			
			return iApsCopyPlannerDataExt;
		}
	}
}
