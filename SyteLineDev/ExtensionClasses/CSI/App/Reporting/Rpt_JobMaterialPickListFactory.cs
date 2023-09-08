//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobMaterialPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobMaterialPickListFactory
	{
		public IRpt_JobMaterialPickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobMaterialPickList = new Reporting.Rpt_JobMaterialPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobMaterialPickListExt = timerfactory.Create<Reporting.IRpt_JobMaterialPickList>(_Rpt_JobMaterialPickList);
			
			return iRpt_JobMaterialPickListExt;
		}
	}
}
