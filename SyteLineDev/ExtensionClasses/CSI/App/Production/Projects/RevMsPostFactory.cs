//PROJECT NAME: Production
//CLASS NAME: RevMsPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class RevMsPostFactory
	{
		public IRevMsPost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RevMsPost = new Production.Projects.RevMsPost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRevMsPostExt = timerfactory.Create<Production.Projects.IRevMsPost>(_RevMsPost);
			
			return iRevMsPostExt;
		}
	}
}
