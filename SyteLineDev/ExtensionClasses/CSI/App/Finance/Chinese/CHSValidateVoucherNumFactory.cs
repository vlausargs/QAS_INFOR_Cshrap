//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSValidateVoucherNumFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSValidateVoucherNumFactory
	{
		public ICHSValidateVoucherNum Create(IApplicationDB appDB)
		{
			var _CHSValidateVoucherNum = new Finance.Chinese.CHSValidateVoucherNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSValidateVoucherNumExt = timerfactory.Create<Finance.Chinese.ICHSValidateVoucherNum>(_CHSValidateVoucherNum);
			
			return iCHSValidateVoucherNumExt;
		}
	}
}
