//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChangeOrderDetailFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ChangeOrderDetailFactory
	{
		public IRpt_ChangeOrderDetail Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ChangeOrderDetail = new Reporting.Rpt_ChangeOrderDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ChangeOrderDetailExt = timerfactory.Create<Reporting.IRpt_ChangeOrderDetail>(_Rpt_ChangeOrderDetail);
			
			return iRpt_ChangeOrderDetailExt;
		}
	}
}
