//PROJECT NAME: Production
//CLASS NAME: GetProjMatFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class GetProjMatFactory
	{
		public IGetProjMat Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetProjMat = new Production.Projects.GetProjMat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjMatExt = timerfactory.Create<Production.Projects.IGetProjMat>(_GetProjMat);
			
			return iGetProjMatExt;
		}
	}
}
