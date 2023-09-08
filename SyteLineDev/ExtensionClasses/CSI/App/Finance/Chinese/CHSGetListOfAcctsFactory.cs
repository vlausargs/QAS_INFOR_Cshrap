//PROJECT NAME: Finance
//CLASS NAME: CHSGetListOfAcctsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSGetListOfAcctsFactory
	{
		public ICHSGetListOfAccts Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSGetListOfAccts = new Finance.Chinese.CHSGetListOfAccts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSGetListOfAcctsExt = timerfactory.Create<Finance.Chinese.ICHSGetListOfAccts>(_CHSGetListOfAccts);
			
			return iCHSGetListOfAcctsExt;
		}
	}
}
