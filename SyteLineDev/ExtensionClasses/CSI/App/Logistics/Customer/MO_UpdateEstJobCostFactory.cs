//PROJECT NAME: Logistics
//CLASS NAME: MO_UpdateEstJobCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class MO_UpdateEstJobCostFactory
	{
		public IMO_UpdateEstJobCost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_UpdateEstJobCost = new Logistics.Customer.MO_UpdateEstJobCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_UpdateEstJobCostExt = timerfactory.Create<Logistics.Customer.IMO_UpdateEstJobCost>(_MO_UpdateEstJobCost);
			
			return iMO_UpdateEstJobCostExt;
		}
	}
}
