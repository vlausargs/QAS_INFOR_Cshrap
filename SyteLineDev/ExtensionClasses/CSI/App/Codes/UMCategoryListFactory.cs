//PROJECT NAME: Codes
//CLASS NAME: UMCategoryListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class UMCategoryListFactory
	{
		public IUMCategoryList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _UMCategoryList = new Codes.UMCategoryList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUMCategoryListExt = timerfactory.Create<Codes.IUMCategoryList>(_UMCategoryList);
			
			return iUMCategoryListExt;
		}
	}
}
