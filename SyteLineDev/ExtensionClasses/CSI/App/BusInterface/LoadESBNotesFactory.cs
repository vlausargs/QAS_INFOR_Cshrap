//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBNotesFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBNotesFactory
	{
		public ILoadESBNotes Create(IApplicationDB appDB)
		{
			var _LoadESBNotes = new BusInterface.LoadESBNotes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBNotesExt = timerfactory.Create<BusInterface.ILoadESBNotes>(_LoadESBNotes);
			
			return iLoadESBNotesExt;
		}
	}
}
