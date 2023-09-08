//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListFactory
	{
		public IGenerateOrderPickList Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateOrderPickList = new Logistics.Customer.GenerateOrderPickList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateOrderPickListExt = timerfactory.Create<Logistics.Customer.IGenerateOrderPickList>(_GenerateOrderPickList);
			
			return iGenerateOrderPickListExt;
		}
	}
}
