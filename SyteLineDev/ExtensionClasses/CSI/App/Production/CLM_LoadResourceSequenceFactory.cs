//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_LoadResourceSequenceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_LoadResourceSequenceFactory
	{
		public ICLM_LoadResourceSequence Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadResourceSequence = new Production.CLM_LoadResourceSequence(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadResourceSequenceExt = timerfactory.Create<Production.ICLM_LoadResourceSequence>(_CLM_LoadResourceSequence);
			
			return iCLM_LoadResourceSequenceExt;
		}
	}
}
