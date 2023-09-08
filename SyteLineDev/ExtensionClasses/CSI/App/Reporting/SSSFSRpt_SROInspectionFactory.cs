//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROInspectionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROInspectionFactory
	{
		public ISSSFSRpt_SROInspection Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROInspection = new Reporting.SSSFSRpt_SROInspection(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROInspectionExt = timerfactory.Create<Reporting.ISSSFSRpt_SROInspection>(_SSSFSRpt_SROInspection);
			
			return iSSSFSRpt_SROInspectionExt;
		}
	}
}
