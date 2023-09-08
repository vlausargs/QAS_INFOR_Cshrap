//PROJECT NAME: CSICCI
//CLASS NAME: CCICalcBalFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class CCICalcBalFactory
	{
		public ICCICalcBal Create(IApplicationDB appDB)
		{
			var _CCICalcBal = new Finance.CreditCard.CCICalcBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCCICalcBalExt = timerfactory.Create<Finance.CreditCard.ICCICalcBal>(_CCICalcBal);
			
			return iCCICalcBalExt;
		}
	}
}
