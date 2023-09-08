//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_IncidentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_IncidentFactory
	{
		public ISSSFSRpt_Incident Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_Incident = new Reporting.SSSFSRpt_Incident(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_IncidentExt = timerfactory.Create<Reporting.ISSSFSRpt_Incident>(_SSSFSRpt_Incident);
			
			return iSSSFSRpt_IncidentExt;
		}
	}
}
