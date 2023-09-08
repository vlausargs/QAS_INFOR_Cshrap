//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Ap01RIVoidedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_Ap01RIVoidedFactory
	{
		public IRpt_Ap01RIVoided Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Ap01RIVoided = new Reporting.Rpt_Ap01RIVoided(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_Ap01RIVoidedExt = timerfactory.Create<Reporting.IRpt_Ap01RIVoided>(_Rpt_Ap01RIVoided);
			
			return iRpt_Ap01RIVoidedExt;
		}
	}
}
