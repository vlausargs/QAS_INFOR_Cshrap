//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPrePackSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPrePackSlipFactory
	{
		public ISSSFSRpt_SROPrePackSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROPrePackSlip = new Reporting.SSSFSRpt_SROPrePackSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROPrePackSlipExt = timerfactory.Create<Reporting.ISSSFSRpt_SROPrePackSlip>(_SSSFSRpt_SROPrePackSlip);
			
			return iSSSFSRpt_SROPrePackSlipExt;
		}
	}
}
