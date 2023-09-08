//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInteractionNoteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInteractionNoteFactory
	{
		public ICLM_ESBInteractionNote Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInteractionNote = new BusInterface.CLM_ESBInteractionNote(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInteractionNoteExt = timerfactory.Create<BusInterface.ICLM_ESBInteractionNote>(_CLM_ESBInteractionNote);
			
			return iCLM_ESBInteractionNoteExt;
		}
	}
}
