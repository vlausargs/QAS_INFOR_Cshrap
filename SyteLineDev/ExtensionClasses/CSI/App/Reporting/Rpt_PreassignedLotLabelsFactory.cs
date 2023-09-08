//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PreassignedLotLabelsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PreassignedLotLabelsFactory
	{
		public IRpt_PreassignedLotLabels Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PreassignedLotLabels = new Reporting.Rpt_PreassignedLotLabels(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PreassignedLotLabelsExt = timerfactory.Create<Reporting.IRpt_PreassignedLotLabels>(_Rpt_PreassignedLotLabels);
			
			return iRpt_PreassignedLotLabelsExt;
		}
	}
}
