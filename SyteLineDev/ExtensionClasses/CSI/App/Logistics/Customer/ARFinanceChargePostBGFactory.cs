//PROJECT NAME: Logistics
//CLASS NAME: ARFinanceChargePostBGFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARFinanceChargePostBGFactory
	{
		public IARFinanceChargePostBG Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARFinanceChargePostBG = new Logistics.Customer.ARFinanceChargePostBG(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinanceChargePostBGExt = timerfactory.Create<Logistics.Customer.IARFinanceChargePostBG>(_ARFinanceChargePostBG);
			
			return iARFinanceChargePostBGExt;
		}
	}
}
