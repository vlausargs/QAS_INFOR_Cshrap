//PROJECT NAME: Production
//CLASS NAME: ProfileProjectPackingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProfileProjectPackingFactory
	{
		public IProfileProjectPacking Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileProjectPacking = new Production.Projects.ProfileProjectPacking(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileProjectPackingExt = timerfactory.Create<Production.Projects.IProfileProjectPacking>(_ProfileProjectPacking);
			
			return iProfileProjectPackingExt;
		}
	}
}
