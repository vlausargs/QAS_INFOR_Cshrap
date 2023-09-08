//PROJECT NAME: Production
//CLASS NAME: LOOKUPSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class LOOKUPSaveFactory
	{
		public ILOOKUPSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LOOKUPSave = new Production.APS.LOOKUPSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLOOKUPSaveExt = timerfactory.Create<Production.APS.ILOOKUPSave>(_LOOKUPSave);
			
			return iLOOKUPSaveExt;
		}
	}
}
