//PROJECT NAME: CSIBusInterface
//CLASS NAME: ReplDocumentExtPivotFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class ReplDocumentExtPivotFactory
	{
		public IReplDocumentExtPivot Create(IApplicationDB appDB)
		{
			var _ReplDocumentExtPivot = new BusInterface.ReplDocumentExtPivot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReplDocumentExtPivotExt = timerfactory.Create<BusInterface.IReplDocumentExtPivot>(_ReplDocumentExtPivot);
			
			return iReplDocumentExtPivotExt;
		}
	}
}
