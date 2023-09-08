//PROJECT NAME: Logistics
//CLASS NAME: WfPrintPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class WfPrintPickListFactory
	{
		public IWfPrintPickList Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WfPrintPickList = new Logistics.Customer.WfPrintPickList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWfPrintPickListExt = timerfactory.Create<Logistics.Customer.IWfPrintPickList>(_WfPrintPickList);
			
			return iWfPrintPickListExt;
		}
	}
}
