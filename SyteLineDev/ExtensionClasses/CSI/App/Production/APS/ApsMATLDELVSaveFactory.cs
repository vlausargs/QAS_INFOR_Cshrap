//PROJECT NAME: Production
//CLASS NAME: ApsMATLDELVSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMATLDELVSaveFactory
	{
		public IApsMATLDELVSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMATLDELVSave = new Production.APS.ApsMATLDELVSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLDELVSaveExt = timerfactory.Create<Production.APS.IApsMATLDELVSave>(_ApsMATLDELVSave);
			
			return iApsMATLDELVSaveExt;
		}
	}
}
