//PROJECT NAME: Production
//CLASS NAME: RSQC_RcvrUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_RcvrUpdateFactory
	{
		public IRSQC_RcvrUpdate Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _RSQC_RcvrUpdate = new Production.Quality.RSQC_RcvrUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_RcvrUpdateExt = timerfactory.Create<Production.Quality.IRSQC_RcvrUpdate>(_RSQC_RcvrUpdate);
			
			return iRSQC_RcvrUpdateExt;
		}
	}
}
