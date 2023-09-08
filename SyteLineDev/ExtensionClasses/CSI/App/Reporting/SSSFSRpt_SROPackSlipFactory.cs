//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPackSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPackSlipFactory
	{
		public ISSSFSRpt_SROPackSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROPackSlip = new Reporting.SSSFSRpt_SROPackSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROPackSlipExt = timerfactory.Create<Reporting.ISSSFSRpt_SROPackSlip>(_SSSFSRpt_SROPackSlip);
			
			return iSSSFSRpt_SROPackSlipExt;
		}
	}
}
