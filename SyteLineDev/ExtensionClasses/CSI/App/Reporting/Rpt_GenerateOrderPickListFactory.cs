//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GenerateOrderPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GenerateOrderPickListFactory
	{
		public IRpt_GenerateOrderPickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GenerateOrderPickList = new Reporting.Rpt_GenerateOrderPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GenerateOrderPickListExt = timerfactory.Create<Reporting.IRpt_GenerateOrderPickList>(_Rpt_GenerateOrderPickList);
			
			return iRpt_GenerateOrderPickListExt;
		}
	}
}
