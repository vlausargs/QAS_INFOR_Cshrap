//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherRegisterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoucherRegisterFactory
	{
		public IRpt_VoucherRegister Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoucherRegister = new Reporting.Rpt_VoucherRegister(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoucherRegisterExt = timerfactory.Create<Reporting.IRpt_VoucherRegister>(_Rpt_VoucherRegister);
			
			return iRpt_VoucherRegisterExt;
		}
	}
}
