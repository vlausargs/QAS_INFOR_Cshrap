//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MailingLabelsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MailingLabelsFactory
	{
		public IRpt_MailingLabels Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MailingLabels = new Reporting.Rpt_MailingLabels(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MailingLabelsExt = timerfactory.Create<Reporting.IRpt_MailingLabels>(_Rpt_MailingLabels);
			
			return iRpt_MailingLabelsExt;
		}
	}
}
