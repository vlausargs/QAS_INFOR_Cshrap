//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PreassignedSerialLabelsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PreassignedSerialLabelsFactory
	{
		public IRpt_PreassignedSerialLabels Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PreassignedSerialLabels = new Reporting.Rpt_PreassignedSerialLabels(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PreassignedSerialLabelsExt = timerfactory.Create<Reporting.IRpt_PreassignedSerialLabels>(_Rpt_PreassignedSerialLabels);
			
			return iRpt_PreassignedSerialLabelsExt;
		}
	}
}
