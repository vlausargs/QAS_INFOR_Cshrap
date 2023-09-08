//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXVATAPPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MXVATAPPostFactory
	{
		public IRpt_MXVATAPPost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MXVATAPPost = new Reporting.Rpt_MXVATAPPost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MXVATAPPostExt = timerfactory.Create<Reporting.IRpt_MXVATAPPost>(_Rpt_MXVATAPPost);
			
			return iRpt_MXVATAPPostExt;
		}
	}
}
