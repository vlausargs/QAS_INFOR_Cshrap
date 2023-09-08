//PROJECT NAME: Logistics
//CLASS NAME: ValidateToDoNumForCopyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidateToDoNumForCopyFactory
	{
		public IValidateToDoNumForCopy Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateToDoNumForCopy = new Logistics.Customer.ValidateToDoNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateToDoNumForCopyExt = timerfactory.Create<Logistics.Customer.IValidateToDoNumForCopy>(_ValidateToDoNumForCopy);
			
			return iValidateToDoNumForCopyExt;
		}
	}
}
