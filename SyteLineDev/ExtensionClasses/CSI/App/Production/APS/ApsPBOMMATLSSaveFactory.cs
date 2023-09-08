//PROJECT NAME: Production
//CLASS NAME: ApsPBOMMATLSSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsPBOMMATLSSaveFactory
	{
		public IApsPBOMMATLSSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsPBOMMATLSSave = new Production.APS.ApsPBOMMATLSSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsPBOMMATLSSaveExt = timerfactory.Create<Production.APS.IApsPBOMMATLSSave>(_ApsPBOMMATLSSave);
			
			return iApsPBOMMATLSSaveExt;
		}
	}
}
