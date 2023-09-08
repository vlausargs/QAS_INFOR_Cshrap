//PROJECT NAME: Logistics
//CLASS NAME: AddContactToGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class AddContactToGroupFactory
	{
		public IAddContactToGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AddContactToGroup = new Logistics.Customer.AddContactToGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddContactToGroupExt = timerfactory.Create<Logistics.Customer.IAddContactToGroup>(_AddContactToGroup);
			
			return iAddContactToGroupExt;
		}
	}
}
