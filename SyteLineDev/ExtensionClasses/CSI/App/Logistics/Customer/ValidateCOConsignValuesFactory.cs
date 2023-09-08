//PROJECT NAME: Logistics
//CLASS NAME: ValidateCOConsignValuesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidateCOConsignValuesFactory
	{
		public IValidateCOConsignValues Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateCOConsignValues = new Logistics.Customer.ValidateCOConsignValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateCOConsignValuesExt = timerfactory.Create<Logistics.Customer.IValidateCOConsignValues>(_ValidateCOConsignValues);
			
			return iValidateCOConsignValuesExt;
		}
	}
}
