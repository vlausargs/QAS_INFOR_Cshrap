//PROJECT NAME: Logistics
//CLASS NAME: ValidateFromDoNumForCopyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidateFromDoNumForCopyFactory
	{
		public IValidateFromDoNumForCopy Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateFromDoNumForCopy = new Logistics.Customer.ValidateFromDoNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateFromDoNumForCopyExt = timerfactory.Create<Logistics.Customer.IValidateFromDoNumForCopy>(_ValidateFromDoNumForCopy);
			
			return iValidateFromDoNumForCopyExt;
		}
	}
}
