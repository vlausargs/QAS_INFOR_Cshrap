//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BillofLadingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_BillofLadingFactory
	{
		public IRpt_BillofLading Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_BillofLading = new Reporting.Rpt_BillofLading(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BillofLadingExt = timerfactory.Create<Reporting.IRpt_BillofLading>(_Rpt_BillofLading);
			
			return iRpt_BillofLadingExt;
		}
	}
}
