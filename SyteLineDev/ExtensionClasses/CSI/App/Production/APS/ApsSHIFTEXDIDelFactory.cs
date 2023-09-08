//PROJECT NAME: Production
//CLASS NAME: ApsSHIFTEXDIDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsSHIFTEXDIDelFactory
	{
		public IApsSHIFTEXDIDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsSHIFTEXDIDel = new Production.APS.ApsSHIFTEXDIDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSHIFTEXDIDelExt = timerfactory.Create<Production.APS.IApsSHIFTEXDIDel>(_ApsSHIFTEXDIDel);
			
			return iApsSHIFTEXDIDelExt;
		}
	}
}
