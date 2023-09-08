//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APRemittanceAdviceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_APRemittanceAdviceFactory
	{
		public IRpt_APRemittanceAdvice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APRemittanceAdvice = new Reporting.Rpt_APRemittanceAdvice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APRemittanceAdviceExt = timerfactory.Create<Reporting.IRpt_APRemittanceAdvice>(_Rpt_APRemittanceAdvice);
			
			return iRpt_APRemittanceAdviceExt;
		}
	}
}
