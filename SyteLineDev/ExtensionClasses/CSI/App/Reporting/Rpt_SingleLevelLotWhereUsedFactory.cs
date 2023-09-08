//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SingleLevelLotWhereUsedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SingleLevelLotWhereUsedFactory
	{
		public IRpt_SingleLevelLotWhereUsed Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SingleLevelLotWhereUsed = new Reporting.Rpt_SingleLevelLotWhereUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SingleLevelLotWhereUsedExt = timerfactory.Create<Reporting.IRpt_SingleLevelLotWhereUsed>(_Rpt_SingleLevelLotWhereUsed);
			
			return iRpt_SingleLevelLotWhereUsedExt;
		}
	}
}
