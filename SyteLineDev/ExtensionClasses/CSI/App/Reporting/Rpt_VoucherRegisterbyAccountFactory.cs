//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherRegisterbyAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoucherRegisterbyAccountFactory
	{
		public IRpt_VoucherRegisterbyAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoucherRegisterbyAccount = new Reporting.Rpt_VoucherRegisterbyAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoucherRegisterbyAccountExt = timerfactory.Create<Reporting.IRpt_VoucherRegisterbyAccount>(_Rpt_VoucherRegisterbyAccount);
			
			return iRpt_VoucherRegisterbyAccountExt;
		}
	}
}
