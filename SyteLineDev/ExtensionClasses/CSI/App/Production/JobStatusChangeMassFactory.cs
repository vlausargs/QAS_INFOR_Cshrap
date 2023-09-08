//PROJECT NAME: CSIProduct
//CLASS NAME: JobStatusChangeMassFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class JobStatusChangeMassFactory
	{
		public IJobStatusChangeMass Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _JobStatusChangeMass = new Production.JobStatusChangeMass(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobStatusChangeMassExt = timerfactory.Create<Production.IJobStatusChangeMass>(_JobStatusChangeMass);
			
			return iJobStatusChangeMassExt;
		}
	}
}
