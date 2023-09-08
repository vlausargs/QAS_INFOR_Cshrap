//PROJECT NAME: Material
//CLASS NAME: GetListSourceForTrnLinesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class GetListSourceForTrnLinesFactory
	{
		public IGetListSourceForTrnLines Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetListSourceForTrnLines = new Material.GetListSourceForTrnLines(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetListSourceForTrnLinesExt = timerfactory.Create<Material.IGetListSourceForTrnLines>(_GetListSourceForTrnLines);
			
			return iGetListSourceForTrnLinesExt;
		}
	}
}
