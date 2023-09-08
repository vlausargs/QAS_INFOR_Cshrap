//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdValidDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdValidDueDateFactory
	{
		public IArpmtdValidDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtdValidDueDate = new Logistics.Customer.ArpmtdValidDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdValidDueDateExt = timerfactory.Create<Logistics.Customer.IArpmtdValidDueDate>(_ArpmtdValidDueDate);
			
			return iArpmtdValidDueDateExt;
		}
	}
}
