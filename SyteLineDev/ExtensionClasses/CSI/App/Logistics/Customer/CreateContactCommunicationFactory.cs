//PROJECT NAME: Logistics
//CLASS NAME: CreateContactCommunicationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CreateContactCommunicationFactory
	{
		public ICreateContactCommunication Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateContactCommunication = new Logistics.Customer.CreateContactCommunication(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateContactCommunicationExt = timerfactory.Create<Logistics.Customer.ICreateContactCommunication>(_CreateContactCommunication);
			
			return iCreateContactCommunicationExt;
		}
	}
}
