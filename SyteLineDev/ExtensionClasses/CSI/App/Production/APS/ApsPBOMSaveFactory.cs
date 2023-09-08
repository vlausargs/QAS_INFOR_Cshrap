//PROJECT NAME: Production
//CLASS NAME: ApsPBOMSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsPBOMSaveFactory
	{
		public IApsPBOMSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsPBOMSave = new Production.APS.ApsPBOMSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsPBOMSaveExt = timerfactory.Create<Production.APS.IApsPBOMSave>(_ApsPBOMSave);
			
			return iApsPBOMSaveExt;
		}
	}
}
