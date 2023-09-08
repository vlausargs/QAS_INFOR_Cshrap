//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PackingSlipDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PackingSlipDetailFactory
	{
		public IRpt_PackingSlipDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PackingSlipDetail = new Reporting.Rpt_PackingSlipDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PackingSlipDetailExt = timerfactory.Create<Reporting.IRpt_PackingSlipDetail>(_Rpt_PackingSlipDetail);
			
			return iRpt_PackingSlipDetailExt;
		}
	}
}
