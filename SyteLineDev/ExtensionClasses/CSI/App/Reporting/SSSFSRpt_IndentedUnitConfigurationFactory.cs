//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_IndentedUnitConfigurationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_IndentedUnitConfigurationFactory
	{
		public ISSSFSRpt_IndentedUnitConfiguration Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_IndentedUnitConfiguration = new Reporting.SSSFSRpt_IndentedUnitConfiguration(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_IndentedUnitConfigurationExt = timerfactory.Create<Reporting.ISSSFSRpt_IndentedUnitConfiguration>(_SSSFSRpt_IndentedUnitConfiguration);
			
			return iSSSFSRpt_IndentedUnitConfigurationExt;
		}
	}
}
