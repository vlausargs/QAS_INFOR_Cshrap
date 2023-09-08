//PROJECT NAME: Logistics
//CLASS NAME: ARFinanceChargePostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARFinanceChargePostFactory
	{
		public IARFinanceChargePost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARFinanceChargePost = new Logistics.Customer.ARFinanceChargePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinanceChargePostExt = timerfactory.Create<Logistics.Customer.IARFinanceChargePost>(_ARFinanceChargePost);
			
			return iARFinanceChargePostExt;
		}
	}
}
