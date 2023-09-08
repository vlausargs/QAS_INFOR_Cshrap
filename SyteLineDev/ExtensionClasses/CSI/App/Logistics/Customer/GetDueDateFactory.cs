//PROJECT NAME: Logistics
//CLASS NAME: GetDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetDueDateFactory
	{
		public IGetDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDueDate = new Logistics.Customer.GetDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDueDateExt = timerfactory.Create<Logistics.Customer.IGetDueDate>(_GetDueDate);
			
			return iGetDueDateExt;
		}
	}
}
