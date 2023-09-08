//PROJECT NAME: CSIReport
//CLASS NAME: MO_Rpt_DispatchListFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class MO_Rpt_DispatchListFactory
	{
		public IMO_Rpt_DispatchList Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_Rpt_DispatchList = new Reporting.MO_Rpt_DispatchList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_Rpt_DispatchListExt = timerfactory.Create<Reporting.IMO_Rpt_DispatchList>(_MO_Rpt_DispatchList);
			
			return iMO_Rpt_DispatchListExt;
		}
	}
}
