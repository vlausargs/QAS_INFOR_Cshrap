//PROJECT NAME: Logistics
//CLASS NAME: SetPartnerGPSLocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SetPartnerGPSLocFactory
	{
		public ISetPartnerGPSLoc Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _SetPartnerGPSLoc = new Logistics.FieldService.Partner.SetPartnerGPSLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetPartnerGPSLocExt = timerfactory.Create<Logistics.FieldService.Partner.ISetPartnerGPSLoc>(_SetPartnerGPSLoc);
			
			return iSetPartnerGPSLocExt;
		}
	}
}
