//PROJECT NAME: Logistics
//CLASS NAME: GetNextValidDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetNextValidDueDateFactory
	{
		public IGetNextValidDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextValidDueDate = new Logistics.Customer.GetNextValidDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextValidDueDateExt = timerfactory.Create<Logistics.Customer.IGetNextValidDueDate>(_GetNextValidDueDate);
			
			return iGetNextValidDueDateExt;
		}
	}
}
