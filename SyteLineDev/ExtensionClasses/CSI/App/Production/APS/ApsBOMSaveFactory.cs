//PROJECT NAME: Production
//CLASS NAME: ApsBOMSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsBOMSaveFactory
	{
		public IApsBOMSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsBOMSave = new Production.APS.ApsBOMSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBOMSaveExt = timerfactory.Create<Production.APS.IApsBOMSave>(_ApsBOMSave);
			
			return iApsBOMSaveExt;
		}
	}
}
