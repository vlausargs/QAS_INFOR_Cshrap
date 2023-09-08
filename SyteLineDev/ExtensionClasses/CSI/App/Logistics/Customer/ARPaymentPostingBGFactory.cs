//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentPostingBGFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPaymentPostingBGFactory
	{
		public IARPaymentPostingBG Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPaymentPostingBG = new Logistics.Customer.ARPaymentPostingBG(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPaymentPostingBGExt = timerfactory.Create<Logistics.Customer.IARPaymentPostingBG>(_ARPaymentPostingBG);
			
			return iARPaymentPostingBGExt;
		}
	}
}
