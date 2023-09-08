//PROJECT NAME: CSIBusInterface
//CLASS NAME: ReplDocumentExtDropFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class ReplDocumentExtDropFactory
	{
		public IReplDocumentExtDrop Create(IApplicationDB appDB)
		{
			var _ReplDocumentExtDrop = new BusInterface.ReplDocumentExtDrop(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReplDocumentExtDropExt = timerfactory.Create<BusInterface.IReplDocumentExtDrop>(_ReplDocumentExtDrop);
			
			return iReplDocumentExtDropExt;
		}
	}
}
