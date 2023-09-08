//PROJECT NAME: Production
//CLASS NAME: GetJobMatlsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class GetJobMatlsFactory
	{
		public IGetJobMatls Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetJobMatls = new Production.GetJobMatls(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetJobMatlsExt = timerfactory.Create<Production.IGetJobMatls>(_GetJobMatls);
			
			return iGetJobMatlsExt;
		}
	}
}
