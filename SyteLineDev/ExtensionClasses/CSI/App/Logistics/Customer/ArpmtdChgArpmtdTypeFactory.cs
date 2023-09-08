//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdChgArpmtdTypeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdChgArpmtdTypeFactory
	{
		public IArpmtdChgArpmtdType Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ArpmtdChgArpmtdType = new Logistics.Customer.ArpmtdChgArpmtdType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdChgArpmtdTypeExt = timerfactory.Create<Logistics.Customer.IArpmtdChgArpmtdType>(_ArpmtdChgArpmtdType);
			
			return iArpmtdChgArpmtdTypeExt;
		}
	}
}
