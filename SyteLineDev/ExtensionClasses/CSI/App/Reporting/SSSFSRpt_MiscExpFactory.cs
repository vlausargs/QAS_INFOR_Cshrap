//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_MiscExpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_MiscExpFactory
	{
		public ISSSFSRpt_MiscExp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_MiscExp = new Reporting.SSSFSRpt_MiscExp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_MiscExpExt = timerfactory.Create<Reporting.ISSSFSRpt_MiscExp>(_SSSFSRpt_MiscExp);
			
			return iSSSFSRpt_MiscExpExt;
		}
	}
}
