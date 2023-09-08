//PROJECT NAME: CSIMaterial
//CLASS NAME: CombineXferShipReceiveSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CombineXferShipReceiveSetVarsFactory
	{
		public ICombineXferShipReceiveSetVars Create(IApplicationDB appDB)
		{
			var _CombineXferShipReceiveSetVars = new Material.CombineXferShipReceiveSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferShipReceiveSetVarsExt = timerfactory.Create<Material.ICombineXferShipReceiveSetVars>(_CombineXferShipReceiveSetVars);
			
			return iCombineXferShipReceiveSetVarsExt;
		}
	}
}
