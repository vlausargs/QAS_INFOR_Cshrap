//PROJECT NAME: Logistics
//CLASS NAME: DueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class DueDateFactory
	{
		public IDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DueDate = new Logistics.Vendor.DueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDueDateExt = timerfactory.Create<Logistics.Vendor.IDueDate>(_DueDate);
			
			return iDueDateExt;
		}
	}
}
