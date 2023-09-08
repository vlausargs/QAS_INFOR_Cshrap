//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PreAssignedSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PreAssignedSerialFactory
	{
		public IRpt_PreAssignedSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PreAssignedSerial = new Reporting.Rpt_PreAssignedSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PreAssignedSerialExt = timerfactory.Create<Reporting.IRpt_PreAssignedSerial>(_Rpt_PreAssignedSerial);
			
			return iRpt_PreAssignedSerialExt;
		}
	}
}
