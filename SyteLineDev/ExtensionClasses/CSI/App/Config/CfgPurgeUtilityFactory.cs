//PROJECT NAME: CSIConfig
//CLASS NAME: CfgPurgeUtilityFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Config
{
	public class CfgPurgeUtilityFactory
	{
		public ICfgPurgeUtility Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CfgPurgeUtility = new Config.CfgPurgeUtility(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgPurgeUtilityExt = timerfactory.Create<Config.ICfgPurgeUtility>(_CfgPurgeUtility);
			
			return iCfgPurgeUtilityExt;
		}
	}
}
