//PROJECT NAME: Logistics
//CLASS NAME: CustomerUMConversionValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustomerUMConversionValidFactory
	{
		public ICustomerUMConversionValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerUMConversionValid = new Logistics.Customer.CustomerUMConversionValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerUMConversionValidExt = timerfactory.Create<Logistics.Customer.ICustomerUMConversionValid>(_CustomerUMConversionValid);
			
			return iCustomerUMConversionValidExt;
		}
	}
}
