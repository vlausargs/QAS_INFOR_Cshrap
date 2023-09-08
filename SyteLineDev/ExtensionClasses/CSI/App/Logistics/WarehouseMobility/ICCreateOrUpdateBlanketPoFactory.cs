//PROJECT NAME: Logistics
//CLASS NAME: ICCreateOrUpdateBlanketPoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class ICCreateOrUpdateBlanketPoFactory
	{
		public IICCreateOrUpdateBlanketPo Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ICCreateOrUpdateBlanketPo = new Logistics.WarehouseMobility.ICCreateOrUpdateBlanketPo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iICCreateOrUpdateBlanketPoExt = timerfactory.Create<Logistics.WarehouseMobility.IICCreateOrUpdateBlanketPo>(_ICCreateOrUpdateBlanketPo);
			
			return iICCreateOrUpdateBlanketPoExt;
		}
	}
}
