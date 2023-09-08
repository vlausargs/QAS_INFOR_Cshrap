//PROJECT NAME: Finance
//CLASS NAME: FRFecGetPathFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FRFecGetPathFactory
	{
		public IFRFecGetPath Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _FRFecGetPath = new Finance.FRFecGetPath(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFRFecGetPathExt = timerfactory.Create<Finance.IFRFecGetPath>(_FRFecGetPath);
			
			return iFRFecGetPathExt;
		}
	}
}
