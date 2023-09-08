//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentRowFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCaptureDocumentRowFactory
	{
		public ILoadESBCaptureDocumentRow Create(IApplicationDB appDB)
		{
			var _LoadESBCaptureDocumentRow = new BusInterface.LoadESBCaptureDocumentRow(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCaptureDocumentRowExt = timerfactory.Create<BusInterface.ILoadESBCaptureDocumentRow>(_LoadESBCaptureDocumentRow);
			
			return iLoadESBCaptureDocumentRowExt;
		}
	}
}
