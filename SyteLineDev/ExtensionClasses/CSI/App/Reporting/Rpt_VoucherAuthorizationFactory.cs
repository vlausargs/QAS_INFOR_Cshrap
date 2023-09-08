//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherAuthorizationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoucherAuthorizationFactory
	{
		public IRpt_VoucherAuthorization Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoucherAuthorization = new Reporting.Rpt_VoucherAuthorization(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoucherAuthorizationExt = timerfactory.Create<Reporting.IRpt_VoucherAuthorization>(_Rpt_VoucherAuthorization);
			
			return iRpt_VoucherAuthorizationExt;
		}
	}
}
