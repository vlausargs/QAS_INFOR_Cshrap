//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_PartReimbFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_PartReimbFactory
	{
		public ISSSFSRpt_PartReimb Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_PartReimb = new Reporting.SSSFSRpt_PartReimb(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_PartReimbExt = timerfactory.Create<Reporting.ISSSFSRpt_PartReimb>(_SSSFSRpt_PartReimb);
			
			return iSSSFSRpt_PartReimbExt;
		}
	}
}
