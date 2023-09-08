//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentFieldFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCaptureDocumentFieldFactory
	{
		public ILoadESBCaptureDocumentField Create(IApplicationDB appDB)
		{
			var _LoadESBCaptureDocumentField = new BusInterface.LoadESBCaptureDocumentField(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCaptureDocumentFieldExt = timerfactory.Create<BusInterface.ILoadESBCaptureDocumentField>(_LoadESBCaptureDocumentField);
			
			return iLoadESBCaptureDocumentFieldExt;
		}
	}
}
