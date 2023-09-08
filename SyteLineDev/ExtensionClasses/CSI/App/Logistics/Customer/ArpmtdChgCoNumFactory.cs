//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdChgCoNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdChgCoNumFactory
	{
		public IArpmtdChgCoNum Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ArpmtdChgCoNum = new Logistics.Customer.ArpmtdChgCoNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdChgCoNumExt = timerfactory.Create<Logistics.Customer.IArpmtdChgCoNum>(_ArpmtdChgCoNum);
			
			return iArpmtdChgCoNumExt;
		}
	}
}
