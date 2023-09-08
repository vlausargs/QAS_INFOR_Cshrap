//PROJECT NAME: Material
//CLASS NAME: GetRuleSetListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class GetRuleSetListFactory
	{
		public IGetRuleSetList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetRuleSetList = new Material.GetRuleSetList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetRuleSetListExt = timerfactory.Create<Material.IGetRuleSetList>(_GetRuleSetList);
			
			return iGetRuleSetListExt;
		}
	}
}
