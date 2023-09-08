//PROJECT NAME: Logistics
//CLASS NAME: AddARDueDateSeqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class AddARDueDateSeqFactory
	{
		public IAddARDueDateSeq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AddARDueDateSeq = new Logistics.Customer.AddARDueDateSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddARDueDateSeqExt = timerfactory.Create<Logistics.Customer.IAddARDueDateSeq>(_AddARDueDateSeq);
			
			return iAddARDueDateSeqExt;
		}
	}
}
