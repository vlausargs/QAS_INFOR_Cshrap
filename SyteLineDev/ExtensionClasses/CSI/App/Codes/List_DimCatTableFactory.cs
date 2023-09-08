//PROJECT NAME: Codes
//CLASS NAME: List_DimCatTableFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class List_DimCatTableFactory
	{
		public IList_DimCatTable Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _List_DimCatTable = new Codes.List_DimCatTable(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iList_DimCatTableExt = timerfactory.Create<Codes.IList_DimCatTable>(_List_DimCatTable);
			
			return iList_DimCatTableExt;
		}
	}
}
