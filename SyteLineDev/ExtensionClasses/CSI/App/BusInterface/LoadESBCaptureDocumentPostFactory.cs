//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentPostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCaptureDocumentPostFactory
	{
		public ILoadESBCaptureDocumentPost Create(IApplicationDB appDB)
		{
			var _LoadESBCaptureDocumentPost = new BusInterface.LoadESBCaptureDocumentPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCaptureDocumentPostExt = timerfactory.Create<BusInterface.ILoadESBCaptureDocumentPost>(_LoadESBCaptureDocumentPost);
			
			return iLoadESBCaptureDocumentPostExt;
		}
	}
}
