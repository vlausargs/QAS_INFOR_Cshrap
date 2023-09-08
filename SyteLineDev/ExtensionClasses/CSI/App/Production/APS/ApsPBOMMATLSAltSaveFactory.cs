//PROJECT NAME: Production
//CLASS NAME: ApsPBOMMATLSAltSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsPBOMMATLSAltSaveFactory
	{
		public IApsPBOMMATLSAltSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsPBOMMATLSAltSave = new Production.APS.ApsPBOMMATLSAltSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsPBOMMATLSAltSaveExt = timerfactory.Create<Production.APS.IApsPBOMMATLSAltSave>(_ApsPBOMMATLSAltSave);
			
			return iApsPBOMMATLSAltSaveExt;
		}
	}
}
