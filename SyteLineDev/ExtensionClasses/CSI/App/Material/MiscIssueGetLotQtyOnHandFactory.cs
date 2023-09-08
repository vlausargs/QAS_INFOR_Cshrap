//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLotQtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MiscIssueGetLotQtyOnHandFactory
	{
		public IMiscIssueGetLotQtyOnHand Create(IApplicationDB appDB)
		{
			var _MiscIssueGetLotQtyOnHand = new Material.MiscIssueGetLotQtyOnHand(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMiscIssueGetLotQtyOnHandExt = timerfactory.Create<Material.IMiscIssueGetLotQtyOnHand>(_MiscIssueGetLotQtyOnHand);
			
			return iMiscIssueGetLotQtyOnHandExt;
		}
	}
}
