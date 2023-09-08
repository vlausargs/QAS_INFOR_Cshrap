//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PR02riCurPayrollTxsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PR02riCurPayrollTxsFactory
	{
		public IRpt_PR02riCurPayrollTxs Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PR02riCurPayrollTxs = new Reporting.Rpt_PR02riCurPayrollTxs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PR02riCurPayrollTxsExt = timerfactory.Create<Reporting.IRpt_PR02riCurPayrollTxs>(_Rpt_PR02riCurPayrollTxs);
			
			return iRpt_PR02riCurPayrollTxsExt;
		}
	}
}
