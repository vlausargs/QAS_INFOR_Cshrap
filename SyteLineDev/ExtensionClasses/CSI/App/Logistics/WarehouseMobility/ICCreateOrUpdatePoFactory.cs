//PROJECT NAME: Logistics
//CLASS NAME: ICCreateOrUpdatePoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class ICCreateOrUpdatePoFactory
	{
		public IICCreateOrUpdatePo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ICCreateOrUpdatePo = new Logistics.WarehouseMobility.ICCreateOrUpdatePo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iICCreateOrUpdatePoExt = timerfactory.Create<Logistics.WarehouseMobility.IICCreateOrUpdatePo>(_ICCreateOrUpdatePo);
			
			return iICCreateOrUpdatePoExt;
		}
	}
}
