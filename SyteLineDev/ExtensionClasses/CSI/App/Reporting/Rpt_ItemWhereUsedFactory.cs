//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemWhereUsedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemWhereUsedFactory
	{
		public IRpt_ItemWhereUsed Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemWhereUsed = new Reporting.Rpt_ItemWhereUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemWhereUsedExt = timerfactory.Create<Reporting.IRpt_ItemWhereUsed>(_Rpt_ItemWhereUsed);
			
			return iRpt_ItemWhereUsedExt;
		}
	}
}
