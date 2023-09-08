//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetDispositionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetDispositionFactory
	{
		public IRpt_FixedAssetDisposition Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FixedAssetDisposition = new Reporting.Rpt_FixedAssetDisposition(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FixedAssetDispositionExt = timerfactory.Create<Reporting.IRpt_FixedAssetDisposition>(_Rpt_FixedAssetDisposition);
			
			return iRpt_FixedAssetDispositionExt;
		}
	}
}
