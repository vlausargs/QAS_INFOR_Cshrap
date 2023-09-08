//PROJECT NAME: Logistics
//CLASS NAME: RepRuleForObjectExistsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class RepRuleForObjectExistsFactory
	{
		public IRepRuleForObjectExists Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _RepRuleForObjectExists = new Logistics.Vendor.RepRuleForObjectExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRepRuleForObjectExistsExt = timerfactory.Create<Logistics.Vendor.IRepRuleForObjectExists>(_RepRuleForObjectExists);
			
			return iRepRuleForObjectExistsExt;
		}
	}
}
