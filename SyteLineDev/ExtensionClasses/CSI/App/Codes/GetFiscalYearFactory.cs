//PROJECT NAME: Codes
//CLASS NAME: GetFiscalYearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetFiscalYearFactory
	{
		public IGetFiscalYear Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetFiscalYear = new Codes.GetFiscalYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFiscalYearExt = timerfactory.Create<Codes.IGetFiscalYear>(_GetFiscalYear);
			
			return iGetFiscalYearExt;
		}
	}
}
