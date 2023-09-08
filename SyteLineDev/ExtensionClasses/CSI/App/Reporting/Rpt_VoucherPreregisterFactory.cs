//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherPreregisterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoucherPreregisterFactory
	{
		public IRpt_VoucherPreregister Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoucherPreregister = new Reporting.Rpt_VoucherPreregister(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoucherPreregisterExt = timerfactory.Create<Reporting.IRpt_VoucherPreregister>(_Rpt_VoucherPreregister);
			
			return iRpt_VoucherPreregisterExt;
		}
	}
}
