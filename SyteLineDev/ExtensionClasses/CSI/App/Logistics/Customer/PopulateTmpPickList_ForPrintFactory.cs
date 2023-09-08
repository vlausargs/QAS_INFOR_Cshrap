//PROJECT NAME: Logistics
//CLASS NAME: PopulateTmpPickList_ForPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PopulateTmpPickList_ForPrintFactory
	{
		public IPopulateTmpPickList_ForPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PopulateTmpPickList_ForPrint = new Logistics.Customer.PopulateTmpPickList_ForPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPopulateTmpPickList_ForPrintExt = timerfactory.Create<Logistics.Customer.IPopulateTmpPickList_ForPrint>(_PopulateTmpPickList_ForPrint);
			
			return iPopulateTmpPickList_ForPrintExt;
		}
	}
}
