//PROJECT NAME: Logistics
//CLASS NAME: CreateSourceCommunicationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CreateSourceCommunicationFactory
	{
		public ICreateSourceCommunication Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateSourceCommunication = new Logistics.Customer.CreateSourceCommunication(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateSourceCommunicationExt = timerfactory.Create<Logistics.Customer.ICreateSourceCommunication>(_CreateSourceCommunication);
			
			return iCreateSourceCommunicationExt;
		}
	}
}
