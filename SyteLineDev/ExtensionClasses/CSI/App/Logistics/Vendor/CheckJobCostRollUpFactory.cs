//PROJECT NAME: Logistics
//CLASS NAME: CheckJobCostRollUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CheckJobCostRollUpFactory
	{
		public ICheckJobCostRollUp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckJobCostRollUp = new Logistics.Vendor.CheckJobCostRollUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckJobCostRollUpExt = timerfactory.Create<Logistics.Vendor.ICheckJobCostRollUp>(_CheckJobCostRollUp);
			
			return iCheckJobCostRollUpExt;
		}
	}
}
