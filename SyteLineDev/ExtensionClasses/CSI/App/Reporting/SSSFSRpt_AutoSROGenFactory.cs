//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_AutoSROGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_AutoSROGenFactory
	{
		public ISSSFSRpt_AutoSROGen Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_AutoSROGen = new Reporting.SSSFSRpt_AutoSROGen(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_AutoSROGenExt = timerfactory.Create<Reporting.ISSSFSRpt_AutoSROGen>(_SSSFSRpt_AutoSROGen);
			
			return iSSSFSRpt_AutoSROGenExt;
		}
	}
}
