//PROJECT NAME: Logistics
//CLASS NAME: ChangePOInvalidDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ChangePOInvalidDueDateFactory
	{
		public IChangePOInvalidDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ChangePOInvalidDueDate = new Logistics.Vendor.ChangePOInvalidDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChangePOInvalidDueDateExt = timerfactory.Create<Logistics.Vendor.IChangePOInvalidDueDate>(_ChangePOInvalidDueDate);
			
			return iChangePOInvalidDueDateExt;
		}
	}
}
