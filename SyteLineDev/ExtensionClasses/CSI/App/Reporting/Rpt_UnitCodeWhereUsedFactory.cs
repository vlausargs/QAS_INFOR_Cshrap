//PROJECT NAME: Reporting
//CLASS NAME: Rpt_UnitCodeWhereUsedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_UnitCodeWhereUsedFactory
	{
		public IRpt_UnitCodeWhereUsed Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_UnitCodeWhereUsed = new Reporting.Rpt_UnitCodeWhereUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_UnitCodeWhereUsedExt = timerfactory.Create<Reporting.IRpt_UnitCodeWhereUsed>(_Rpt_UnitCodeWhereUsed);
			
			return iRpt_UnitCodeWhereUsedExt;
		}
	}
}
