//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Ap01FRIFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_Ap01FRIFactory
	{
		public IRpt_Ap01FRI Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Ap01FRI = new Reporting.Rpt_Ap01FRI(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_Ap01FRIExt = timerfactory.Create<Reporting.IRpt_Ap01FRI>(_Rpt_Ap01FRI);
			
			return iRpt_Ap01FRIExt;
		}
	}
}
