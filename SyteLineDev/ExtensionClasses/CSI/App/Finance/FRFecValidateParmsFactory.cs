//PROJECT NAME: Finance
//CLASS NAME: FRFecValidateParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FRFecValidateParmsFactory
	{
		public IFRFecValidateParms Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _FRFecValidateParms = new Finance.FRFecValidateParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFRFecValidateParmsExt = timerfactory.Create<Finance.IFRFecValidateParms>(_FRFecValidateParms);
			
			return iFRFecValidateParmsExt;
		}
	}
}
