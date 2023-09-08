//PROJECT NAME: Logistics
//CLASS NAME: CustomerSeqValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustomerSeqValidFactory
	{
		public ICustomerSeqValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerSeqValid = new Logistics.Customer.CustomerSeqValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerSeqValidExt = timerfactory.Create<Logistics.Customer.ICustomerSeqValid>(_CustomerSeqValid);
			
			return iCustomerSeqValidExt;
		}
	}
}
