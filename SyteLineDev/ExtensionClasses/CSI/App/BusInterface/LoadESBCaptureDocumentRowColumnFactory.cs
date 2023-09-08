//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentRowColumnFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCaptureDocumentRowColumnFactory
	{
		public ILoadESBCaptureDocumentRowColumn Create(IApplicationDB appDB)
		{
			var _LoadESBCaptureDocumentRowColumn = new BusInterface.LoadESBCaptureDocumentRowColumn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCaptureDocumentRowColumnExt = timerfactory.Create<BusInterface.ILoadESBCaptureDocumentRowColumn>(_LoadESBCaptureDocumentRowColumn);
			
			return iLoadESBCaptureDocumentRowColumnExt;
		}
	}
}
