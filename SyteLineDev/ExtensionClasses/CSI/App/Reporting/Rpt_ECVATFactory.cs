//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECVATFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ECVATFactory
	{
		public IRpt_ECVAT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ECVAT = new Reporting.Rpt_ECVAT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ECVATExt = timerfactory.Create<Reporting.IRpt_ECVAT>(_Rpt_ECVAT);
			
			return iRpt_ECVATExt;
		}
	}
}
