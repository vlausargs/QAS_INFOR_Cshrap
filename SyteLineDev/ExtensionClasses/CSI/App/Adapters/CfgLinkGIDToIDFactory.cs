//PROJECT NAME: Adapters
//CLASS NAME: CfgLinkGIDToIDFactory.cs

using CSI.MG;

namespace CSI.Adapters
{
	public class CfgLinkGIDToIDFactory
	{
		public ICfgLinkGIDToID Create(IApplicationDB appDB)
		{
			var _CfgLinkGIDToID = new Adapters.CfgLinkGIDToID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgLinkGIDToIDExt = timerfactory.Create<Adapters.ICfgLinkGIDToID>(_CfgLinkGIDToID);
			
			return iCfgLinkGIDToIDExt;
		}
	}
}
