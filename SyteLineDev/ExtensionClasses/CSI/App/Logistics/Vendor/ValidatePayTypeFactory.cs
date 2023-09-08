//PROJECT NAME: Logistics
//CLASS NAME: ValidatePayTypeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ValidatePayTypeFactory
	{
		public IValidatePayType Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ValidatePayType = new Logistics.Vendor.ValidatePayType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePayTypeExt = timerfactory.Create<Logistics.Vendor.IValidatePayType>(_ValidatePayType);
			
			return iValidatePayTypeExt;
		}
	}
}
