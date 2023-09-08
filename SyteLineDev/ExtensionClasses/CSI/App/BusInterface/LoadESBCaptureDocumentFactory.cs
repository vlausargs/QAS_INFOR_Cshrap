//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCaptureDocumentFactory
	{
		public ILoadESBCaptureDocument Create(IApplicationDB appDB)
		{
			var _LoadESBCaptureDocument = new BusInterface.LoadESBCaptureDocument(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCaptureDocumentExt = timerfactory.Create<BusInterface.ILoadESBCaptureDocument>(_LoadESBCaptureDocument);
			
			return iLoadESBCaptureDocumentExt;
		}
	}
}
