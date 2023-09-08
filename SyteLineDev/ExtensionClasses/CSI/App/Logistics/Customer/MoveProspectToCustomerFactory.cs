//PROJECT NAME: Logistics
//CLASS NAME: MoveProspectToCustomerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class MoveProspectToCustomerFactory
	{
		public IMoveProspectToCustomer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MoveProspectToCustomer = new Logistics.Customer.MoveProspectToCustomer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMoveProspectToCustomerExt = timerfactory.Create<Logistics.Customer.IMoveProspectToCustomer>(_MoveProspectToCustomer);
			
			return iMoveProspectToCustomerExt;
		}
	}
}
