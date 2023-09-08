//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobMaterialKitPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobMaterialKitPickListFactory
	{
		public IRpt_JobMaterialKitPickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobMaterialKitPickList = new Reporting.Rpt_JobMaterialKitPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobMaterialKitPickListExt = timerfactory.Create<Reporting.IRpt_JobMaterialKitPickList>(_Rpt_JobMaterialKitPickList);
			
			return iRpt_JobMaterialKitPickListExt;
		}
	}
}
