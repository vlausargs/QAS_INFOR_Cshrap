//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_RecurrVoucherPreviewToPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_RecurrVoucherPreviewToPrintFactory
	{
		public ICHSRpt_RecurrVoucherPreviewToPrint Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_RecurrVoucherPreviewToPrint = new Reporting.CHSRpt_RecurrVoucherPreviewToPrint(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_RecurrVoucherPreviewToPrintExt = timerfactory.Create<Reporting.ICHSRpt_RecurrVoucherPreviewToPrint>(_CHSRpt_RecurrVoucherPreviewToPrint);
			
			return iCHSRpt_RecurrVoucherPreviewToPrintExt;
		}
	}
}
