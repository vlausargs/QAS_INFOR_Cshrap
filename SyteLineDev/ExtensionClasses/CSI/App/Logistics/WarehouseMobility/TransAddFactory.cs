//PROJECT NAME: Logistics
//CLASS NAME: TransAddFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class TransAddFactory
	{
		public ITransAdd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransAdd = new Logistics.WarehouseMobility.TransAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransAddExt = timerfactory.Create<Logistics.WarehouseMobility.ITransAdd>(_TransAdd);
			
			return iTransAddExt;
		}
	}
}
