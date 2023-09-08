//PROJECT NAME: Finance
//CLASS NAME: CHSGetCOrVFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSGetCOrVFactory
	{
		public ICHSGetCOrV Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSGetCOrV = new Finance.Chinese.CHSGetCOrV(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSGetCOrVExt = timerfactory.Create<Finance.Chinese.ICHSGetCOrV>(_CHSGetCOrV);
			
			return iCHSGetCOrVExt;
		}
	}
}
