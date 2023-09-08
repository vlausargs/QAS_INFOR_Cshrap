//PROJECT NAME: Logistics
//CLASS NAME: GetUMConvFactorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetUMConvFactorFactory
	{
		public IGetUMConvFactor Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetUMConvFactor = new Logistics.Customer.GetUMConvFactor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetUMConvFactorExt = timerfactory.Create<Logistics.Customer.IGetUMConvFactor>(_GetUMConvFactor);
			
			return iGetUMConvFactorExt;
		}
	}
}
