//PROJECT NAME: Logistics
//CLASS NAME: NextTrnFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class NextTrnFactory
	{
		public INextTrn Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NextTrn = new Logistics.WarehouseMobility.NextTrn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextTrnExt = timerfactory.Create<Logistics.WarehouseMobility.INextTrn>(_NextTrn);
			
			return iNextTrnExt;
		}
	}
}
