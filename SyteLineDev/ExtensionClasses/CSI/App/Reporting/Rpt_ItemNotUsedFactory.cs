//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemNotUsedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemNotUsedFactory
	{
		public IRpt_ItemNotUsed Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemNotUsed = new Reporting.Rpt_ItemNotUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemNotUsedExt = timerfactory.Create<Reporting.IRpt_ItemNotUsed>(_Rpt_ItemNotUsed);
			
			return iRpt_ItemNotUsedExt;
		}
	}
}
