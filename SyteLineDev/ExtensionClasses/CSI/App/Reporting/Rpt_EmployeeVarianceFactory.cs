//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EmployeeVarianceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EmployeeVarianceFactory
	{
		public IRpt_EmployeeVariance Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EmployeeVariance = new Reporting.Rpt_EmployeeVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EmployeeVarianceExt = timerfactory.Create<Reporting.IRpt_EmployeeVariance>(_Rpt_EmployeeVariance);
			
			return iRpt_EmployeeVarianceExt;
		}
	}
}
