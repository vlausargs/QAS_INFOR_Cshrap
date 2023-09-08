//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FatranPostFactory
	{
		public IFatranPost Create(IApplicationDB appDB)
		{
			var _FatranPost = new Finance.FatranPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFatranPostExt = timerfactory.Create<Finance.IFatranPost>(_FatranPost);
			
			return iFatranPostExt;
		}
	}
}
