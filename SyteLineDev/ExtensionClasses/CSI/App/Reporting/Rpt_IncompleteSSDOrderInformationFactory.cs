//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IncompleteSSDOrderInformationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_IncompleteSSDOrderInformationFactory
	{
		public IRpt_IncompleteSSDOrderInformation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_IncompleteSSDOrderInformation = new Reporting.Rpt_IncompleteSSDOrderInformation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_IncompleteSSDOrderInformationExt = timerfactory.Create<Reporting.IRpt_IncompleteSSDOrderInformation>(_Rpt_IncompleteSSDOrderInformation);
			
			return iRpt_IncompleteSSDOrderInformationExt;
		}
	}
}
