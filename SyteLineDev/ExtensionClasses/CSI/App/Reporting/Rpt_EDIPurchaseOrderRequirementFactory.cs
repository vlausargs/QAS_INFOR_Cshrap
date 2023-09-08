//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EDIPurchaseOrderRequirementFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EDIPurchaseOrderRequirementFactory
	{
		public IRpt_EDIPurchaseOrderRequirement Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EDIPurchaseOrderRequirement = new Reporting.Rpt_EDIPurchaseOrderRequirement(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EDIPurchaseOrderRequirementExt = timerfactory.Create<Reporting.IRpt_EDIPurchaseOrderRequirement>(_Rpt_EDIPurchaseOrderRequirement);
			
			return iRpt_EDIPurchaseOrderRequirementExt;
		}
	}
}
