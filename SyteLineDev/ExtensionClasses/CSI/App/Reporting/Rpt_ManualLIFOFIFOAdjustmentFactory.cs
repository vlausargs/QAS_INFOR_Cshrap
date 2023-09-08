//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ManualLIFOFIFOAdjustmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ManualLIFOFIFOAdjustmentFactory
	{
		public IRpt_ManualLIFOFIFOAdjustment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ManualLIFOFIFOAdjustment = new Reporting.Rpt_ManualLIFOFIFOAdjustment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ManualLIFOFIFOAdjustmentExt = timerfactory.Create<Reporting.IRpt_ManualLIFOFIFOAdjustment>(_Rpt_ManualLIFOFIFOAdjustment);
			
			return iRpt_ManualLIFOFIFOAdjustmentExt;
		}
	}
}
