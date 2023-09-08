//PROJECT NAME: Logistics
//CLASS NAME: CreateContactEmailCommunicationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CreateContactEmailCommunicationFactory
	{
		public ICreateContactEmailCommunication Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateContactEmailCommunication = new Logistics.Customer.CreateContactEmailCommunication(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateContactEmailCommunicationExt = timerfactory.Create<Logistics.Customer.ICreateContactEmailCommunication>(_CreateContactEmailCommunication);
			
			return iCreateContactEmailCommunicationExt;
		}
	}
}
