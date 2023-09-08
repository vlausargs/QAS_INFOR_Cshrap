//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLocQtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MiscIssueGetLocQtyOnHandFactory
	{
		public IMiscIssueGetLocQtyOnHand Create(IApplicationDB appDB)
		{
			var _MiscIssueGetLocQtyOnHand = new Material.MiscIssueGetLocQtyOnHand(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMiscIssueGetLocQtyOnHandExt = timerfactory.Create<Material.IMiscIssueGetLocQtyOnHand>(_MiscIssueGetLocQtyOnHand);
			
			return iMiscIssueGetLocQtyOnHandExt;
		}
	}
}
