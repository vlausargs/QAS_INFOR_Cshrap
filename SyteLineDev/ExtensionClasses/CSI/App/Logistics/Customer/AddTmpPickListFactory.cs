//PROJECT NAME: Logistics
//CLASS NAME: AddTmpPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class AddTmpPickListFactory
	{
		public IAddTmpPickList Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AddTmpPickList = new Logistics.Customer.AddTmpPickList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddTmpPickListExt = timerfactory.Create<Logistics.Customer.IAddTmpPickList>(_AddTmpPickList);
			
			return iAddTmpPickListExt;
		}
	}
}
