//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBChartofAccountMappingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBChartofAccountMappingFactory
	{
		public IRpt_MultiFSBChartofAccountMapping Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBChartofAccountMapping = new Reporting.Rpt_MultiFSBChartofAccountMapping(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBChartofAccountMappingExt = timerfactory.Create<Reporting.IRpt_MultiFSBChartofAccountMapping>(_Rpt_MultiFSBChartofAccountMapping);
			
			return iRpt_MultiFSBChartofAccountMappingExt;
		}
	}
}
