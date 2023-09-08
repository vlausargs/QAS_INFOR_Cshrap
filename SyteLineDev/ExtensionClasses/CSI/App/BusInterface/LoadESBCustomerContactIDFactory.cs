//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCustomerContactIDFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCustomerContactIDFactory
	{
		public ILoadESBCustomerContactID Create(IApplicationDB appDB)
		{
			var _LoadESBCustomerContactID = new BusInterface.LoadESBCustomerContactID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCustomerContactIDExt = timerfactory.Create<BusInterface.ILoadESBCustomerContactID>(_LoadESBCustomerContactID);
			
			return iLoadESBCustomerContactIDExt;
		}
	}
}
