//PROJECT NAME: Finance
//CLASS NAME: CHSGetListOfBanksFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSGetListOfBanksFactory
	{
		public ICHSGetListOfBanks Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSGetListOfBanks = new Finance.Chinese.CHSGetListOfBanks(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSGetListOfBanksExt = timerfactory.Create<Finance.Chinese.ICHSGetListOfBanks>(_CHSGetListOfBanks);
			
			return iCHSGetListOfBanksExt;
		}
	}
}
