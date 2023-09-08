//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FAMovementFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FAMovementFactory
	{
		public IRpt_FAMovement Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FAMovement = new Reporting.Rpt_FAMovement(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FAMovementExt = timerfactory.Create<Reporting.IRpt_FAMovement>(_Rpt_FAMovement);
			
			return iRpt_FAMovementExt;
		}
	}
}
