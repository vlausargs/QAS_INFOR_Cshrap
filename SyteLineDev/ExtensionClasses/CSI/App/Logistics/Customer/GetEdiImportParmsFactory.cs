//PROJECT NAME: Logistics
//CLASS NAME: GetEdiImportParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetEdiImportParmsFactory
	{
		public IGetEdiImportParms Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetEdiImportParms = new Logistics.Customer.GetEdiImportParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEdiImportParmsExt = timerfactory.Create<Logistics.Customer.IGetEdiImportParms>(_GetEdiImportParms);
			
			return iGetEdiImportParmsExt;
		}
	}
}
