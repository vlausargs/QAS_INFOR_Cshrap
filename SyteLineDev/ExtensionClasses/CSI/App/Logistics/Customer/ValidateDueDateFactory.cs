//PROJECT NAME: Logistics
//CLASS NAME: ValidateDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidateDueDateFactory
	{
		public IValidateDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateDueDate = new Logistics.Customer.ValidateDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateDueDateExt = timerfactory.Create<Logistics.Customer.IValidateDueDate>(_ValidateDueDate);
			
			return iValidateDueDateExt;
		}
	}
}
