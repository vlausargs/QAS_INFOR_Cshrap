//PROJECT NAME: CSIFinance
//CLASS NAME: ARDraftRemUpdateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ARDraftRemUpdateFactory
	{
		public IARDraftRemUpdate Create(IApplicationDB appDB)
		{
			var _ARDraftRemUpdate = new Finance.ARDraftRemUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARDraftRemUpdateExt = timerfactory.Create<Finance.IARDraftRemUpdate>(_ARDraftRemUpdate);
			
			return iARDraftRemUpdateExt;
		}
	}
}
