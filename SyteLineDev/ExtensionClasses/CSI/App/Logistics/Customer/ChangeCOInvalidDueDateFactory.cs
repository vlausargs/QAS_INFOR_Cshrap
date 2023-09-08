//PROJECT NAME: Logistics
//CLASS NAME: ChangeCOInvalidDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ChangeCOInvalidDueDateFactory
	{
		public IChangeCOInvalidDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ChangeCOInvalidDueDate = new Logistics.Customer.ChangeCOInvalidDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChangeCOInvalidDueDateExt = timerfactory.Create<Logistics.Customer.IChangeCOInvalidDueDate>(_ChangeCOInvalidDueDate);
			
			return iChangeCOInvalidDueDateExt;
		}
	}
}
