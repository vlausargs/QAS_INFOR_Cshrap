//PROJECT NAME: Reporting
//CLASS NAME: Rpt_POVoucherRegisterbyAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_POVoucherRegisterbyAccountFactory
	{
		public IRpt_POVoucherRegisterbyAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_POVoucherRegisterbyAccount = new Reporting.Rpt_POVoucherRegisterbyAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_POVoucherRegisterbyAccountExt = timerfactory.Create<Reporting.IRpt_POVoucherRegisterbyAccount>(_Rpt_POVoucherRegisterbyAccount);
			
			return iRpt_POVoucherRegisterbyAccountExt;
		}
	}
}
