//PROJECT NAME: Logistics
//CLASS NAME: CostCodeGetAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CostCodeGetAccountFactory
	{
		public ICostCodeGetAccount Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CostCodeGetAccount = new Logistics.Vendor.CostCodeGetAccount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCostCodeGetAccountExt = timerfactory.Create<Logistics.Vendor.ICostCodeGetAccount>(_CostCodeGetAccount);
			
			return iCostCodeGetAccountExt;
		}
	}
}
