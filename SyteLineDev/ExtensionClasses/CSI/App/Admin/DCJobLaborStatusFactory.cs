//PROJECT NAME: Admin
//CLASS NAME: DCJobLaborStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class DCJobLaborStatusFactory
	{
		public IDCJobLaborStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DCJobLaborStatus = new Admin.DCJobLaborStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDCJobLaborStatusExt = timerfactory.Create<Admin.IDCJobLaborStatus>(_DCJobLaborStatus);
			
			return iDCJobLaborStatusExt;
		}
	}
}
