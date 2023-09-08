//PROJECT NAME: Logistics
//CLASS NAME: FTSLRSQC_UpdateCOCFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLRSQC_UpdateCOCFactory
	{
		public IFTSLRSQC_UpdateCOC Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _FTSLRSQC_UpdateCOC = new Logistics.WarehouseMobility.FTSLRSQC_UpdateCOC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLRSQC_UpdateCOCExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLRSQC_UpdateCOC>(_FTSLRSQC_UpdateCOC);
			
			return iFTSLRSQC_UpdateCOCExt;
		}
	}
}
