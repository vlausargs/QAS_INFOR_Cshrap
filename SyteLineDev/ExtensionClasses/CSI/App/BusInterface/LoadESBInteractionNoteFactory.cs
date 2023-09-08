//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBInteractionNoteFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBInteractionNoteFactory
	{
		public ILoadESBInteractionNote Create(IApplicationDB appDB)
		{
			var _LoadESBInteractionNote = new BusInterface.LoadESBInteractionNote(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBInteractionNoteExt = timerfactory.Create<BusInterface.ILoadESBInteractionNote>(_LoadESBInteractionNote);
			
			return iLoadESBInteractionNoteExt;
		}
	}
}
