//PROJECT NAME: CSIReport
//CLASS NAME: AU_Rpt_QAProcessFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class AU_Rpt_QAProcessFactory
	{
		public IAU_Rpt_QAProcess Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_Rpt_QAProcess = new Reporting.AU_Rpt_QAProcess(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_Rpt_QAProcessExt = timerfactory.Create<Reporting.IAU_Rpt_QAProcess>(_AU_Rpt_QAProcess);
			
			return iAU_Rpt_QAProcessExt;
		}
	}
}
