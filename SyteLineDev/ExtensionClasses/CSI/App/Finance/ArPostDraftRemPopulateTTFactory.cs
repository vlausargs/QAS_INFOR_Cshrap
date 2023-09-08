//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostDraftRemPopulateTTFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class ArPostDraftRemPopulateTTFactory
	{
		public IArPostDraftRemPopulateTT Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ArPostDraftRemPopulateTT = new Finance.ArPostDraftRemPopulateTT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArPostDraftRemPopulateTTExt = timerfactory.Create<Finance.IArPostDraftRemPopulateTT>(_ArPostDraftRemPopulateTT);
			
			return iArPostDraftRemPopulateTTExt;
		}
	}
}
