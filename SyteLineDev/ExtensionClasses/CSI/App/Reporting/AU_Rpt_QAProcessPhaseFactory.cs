//PROJECT NAME: CSIReport
//CLASS NAME: AU_Rpt_QAProcessPhaseFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class AU_Rpt_QAProcessPhaseFactory
	{
		public IAU_Rpt_QAProcessPhase Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_Rpt_QAProcessPhase = new Reporting.AU_Rpt_QAProcessPhase(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_Rpt_QAProcessPhaseExt = timerfactory.Create<Reporting.IAU_Rpt_QAProcessPhase>(_AU_Rpt_QAProcessPhase);
			
			return iAU_Rpt_QAProcessPhaseExt;
		}
	}
}
