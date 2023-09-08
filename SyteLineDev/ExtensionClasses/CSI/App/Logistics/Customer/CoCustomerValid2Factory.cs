//PROJECT NAME: Logistics
//CLASS NAME: CoCustomerValid2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoCustomerValid2Factory
	{
		public ICoCustomerValid2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoCustomerValid2 = new Logistics.Customer.CoCustomerValid2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoCustomerValid2Ext = timerfactory.Create<Logistics.Customer.ICoCustomerValid2>(_CoCustomerValid2);
			
			return iCoCustomerValid2Ext;
		}
	}
}
