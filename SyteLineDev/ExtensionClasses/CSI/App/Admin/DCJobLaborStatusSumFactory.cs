//PROJECT NAME: Admin
//CLASS NAME: DCJobLaborStatusSumFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class DCJobLaborStatusSumFactory
	{
		public IDCJobLaborStatusSum Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DCJobLaborStatusSum = new Admin.DCJobLaborStatusSum(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDCJobLaborStatusSumExt = timerfactory.Create<Admin.IDCJobLaborStatusSum>(_DCJobLaborStatusSum);
			
			return iDCJobLaborStatusSumExt;
		}
	}
}
