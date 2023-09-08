//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_AcmTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_AcmTransFactory
	{
		public ISSSFSRpt_AcmTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_AcmTrans = new Reporting.SSSFSRpt_AcmTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_AcmTransExt = timerfactory.Create<Reporting.ISSSFSRpt_AcmTrans>(_SSSFSRpt_AcmTrans);
			
			return iSSSFSRpt_AcmTransExt;
		}
	}
}
