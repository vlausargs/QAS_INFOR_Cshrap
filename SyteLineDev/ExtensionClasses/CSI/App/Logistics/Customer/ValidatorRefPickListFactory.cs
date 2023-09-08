//PROJECT NAME: Logistics
//CLASS NAME: ValidatorRefPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidatorRefPickListFactory
	{
		public IValidatorRefPickList Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidatorRefPickList = new Logistics.Customer.ValidatorRefPickList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatorRefPickListExt = timerfactory.Create<Logistics.Customer.IValidatorRefPickList>(_ValidatorRefPickList);
			
			return iValidatorRefPickListExt;
		}
	}
}
