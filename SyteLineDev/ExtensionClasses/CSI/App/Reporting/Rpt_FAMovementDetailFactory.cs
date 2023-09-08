//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FAMovementDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FAMovementDetailFactory
	{
		public IRpt_FAMovementDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FAMovementDetail = new Reporting.Rpt_FAMovementDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FAMovementDetailExt = timerfactory.Create<Reporting.IRpt_FAMovementDetail>(_Rpt_FAMovementDetail);
			
			return iRpt_FAMovementDetailExt;
		}
	}
}
