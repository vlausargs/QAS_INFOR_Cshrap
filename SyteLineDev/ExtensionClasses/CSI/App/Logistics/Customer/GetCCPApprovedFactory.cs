//PROJECT NAME: Logistics
//CLASS NAME: GetCCPApprovedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCCPApprovedFactory
	{
		public IGetCCPApproved Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCCPApproved = new Logistics.Customer.GetCCPApproved(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCCPApprovedExt = timerfactory.Create<Logistics.Customer.IGetCCPApproved>(_GetCCPApproved);
			
			return iGetCCPApprovedExt;
		}
	}
}
