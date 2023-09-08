//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROWIPValuationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROWIPValuationFactory
	{
		public ISSSFSRpt_SROWIPValuation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROWIPValuation = new Reporting.SSSFSRpt_SROWIPValuation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROWIPValuationExt = timerfactory.Create<Reporting.ISSSFSRpt_SROWIPValuation>(_SSSFSRpt_SROWIPValuation);
			
			return iSSSFSRpt_SROWIPValuationExt;
		}
	}
}
