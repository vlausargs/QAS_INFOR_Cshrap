//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECSalesListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ECSalesListFactory
	{
		public IRpt_ECSalesList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ECSalesList = new Reporting.Rpt_ECSalesList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ECSalesListExt = timerfactory.Create<Reporting.IRpt_ECSalesList>(_Rpt_ECSalesList);
			
			return iRpt_ECSalesListExt;
		}
	}
}
