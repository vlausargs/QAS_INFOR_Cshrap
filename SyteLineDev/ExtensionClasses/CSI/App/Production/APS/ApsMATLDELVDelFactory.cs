//PROJECT NAME: Production
//CLASS NAME: ApsMATLDELVDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMATLDELVDelFactory
	{
		public IApsMATLDELVDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMATLDELVDel = new Production.APS.ApsMATLDELVDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLDELVDelExt = timerfactory.Create<Production.APS.IApsMATLDELVDel>(_ApsMATLDELVDel);
			
			return iApsMATLDELVDelExt;
		}
	}
}
