//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemGenMixFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemGenMixFactory
	{
		public IRpt_ItemGenMix Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemGenMix = new Reporting.Rpt_ItemGenMix(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemGenMixExt = timerfactory.Create<Reporting.IRpt_ItemGenMix>(_Rpt_ItemGenMix);
			
			return iRpt_ItemGenMixExt;
		}
	}
}
