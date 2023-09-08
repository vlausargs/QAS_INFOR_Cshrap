//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PickListFactory
	{
		public IRpt_PickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PickList = new Reporting.Rpt_PickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PickListExt = timerfactory.Create<Reporting.IRpt_PickList>(_Rpt_PickList);
			
			return iRpt_PickListExt;
		}
	}
}
