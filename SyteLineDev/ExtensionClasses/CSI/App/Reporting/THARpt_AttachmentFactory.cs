//PROJECT NAME: Reporting
//CLASS NAME: THARpt_AttachmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_AttachmentFactory
	{
		public ITHARpt_Attachment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_Attachment = new Reporting.THARpt_Attachment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_AttachmentExt = timerfactory.Create<Reporting.ITHARpt_Attachment>(_THARpt_Attachment);
			
			return iTHARpt_AttachmentExt;
		}
	}
}
