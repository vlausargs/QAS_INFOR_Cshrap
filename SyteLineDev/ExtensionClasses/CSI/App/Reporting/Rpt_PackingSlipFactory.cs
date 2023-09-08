//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PackingSlipFactory
	{
		public IRpt_PackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PackingSlip = new Reporting.Rpt_PackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PackingSlipExt = timerfactory.Create<Reporting.IRpt_PackingSlip>(_Rpt_PackingSlip);
			
			return iRpt_PackingSlipExt;
		}
	}
}
