//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSValidateTransAmountFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSValidateTransAmountFactory
	{
		public ICHSValidateTransAmount Create(IApplicationDB appDB)
		{
			var _CHSValidateTransAmount = new Finance.Chinese.CHSValidateTransAmount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSValidateTransAmountExt = timerfactory.Create<Finance.Chinese.ICHSValidateTransAmount>(_CHSValidateTransAmount);
			
			return iCHSValidateTransAmountExt;
		}
	}
}
