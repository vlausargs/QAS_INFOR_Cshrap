//PROJECT NAME: CSIReport
//CLASS NAME: MO_Rpt_JobMaterialsPercentageValidationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class MO_Rpt_JobMaterialsPercentageValidationFactory
	{
		public IMO_Rpt_JobMaterialsPercentageValidation Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_Rpt_JobMaterialsPercentageValidation = new Reporting.MO_Rpt_JobMaterialsPercentageValidation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_Rpt_JobMaterialsPercentageValidationExt = timerfactory.Create<Reporting.IMO_Rpt_JobMaterialsPercentageValidation>(_MO_Rpt_JobMaterialsPercentageValidation);
			
			return iMO_Rpt_JobMaterialsPercentageValidationExt;
		}
	}
}
