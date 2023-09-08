//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostDeleteTmpFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FatranPostDeleteTmpFactory
	{
		public IFatranPostDeleteTmp Create(IApplicationDB appDB)
		{
			var _FatranPostDeleteTmp = new Finance.FatranPostDeleteTmp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFatranPostDeleteTmpExt = timerfactory.Create<Finance.IFatranPostDeleteTmp>(_FatranPostDeleteTmp);
			
			return iFatranPostDeleteTmpExt;
		}
	}
}
