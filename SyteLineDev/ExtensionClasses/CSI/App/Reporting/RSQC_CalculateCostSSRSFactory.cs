//PROJECT NAME: Reporting
//CLASS NAME: RSQC_CalculateCostSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_CalculateCostSSRSFactory
	{
		public IRSQC_CalculateCostSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_CalculateCostSSRS = new Reporting.RSQC_CalculateCostSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CalculateCostSSRSExt = timerfactory.Create<Reporting.IRSQC_CalculateCostSSRS>(_RSQC_CalculateCostSSRS);
			
			return iRSQC_CalculateCostSSRSExt;
		}
	}
}
