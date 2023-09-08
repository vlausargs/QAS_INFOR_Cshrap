//PROJECT NAME: Production
//CLASS NAME: ApsSHIFTEXDISaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsSHIFTEXDISaveFactory
	{
		public IApsSHIFTEXDISave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsSHIFTEXDISave = new Production.APS.ApsSHIFTEXDISave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSHIFTEXDISaveExt = timerfactory.Create<Production.APS.IApsSHIFTEXDISave>(_ApsSHIFTEXDISave);
			
			return iApsSHIFTEXDISaveExt;
		}
	}
}
