//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSUpdateLedgerCustVendNumFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSUpdateLedgerCustVendNumFactory
	{
		public ICHSUpdateLedgerCustVendNum Create(IApplicationDB appDB)
		{
			var _CHSUpdateLedgerCustVendNum = new Finance.Chinese.CHSUpdateLedgerCustVendNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSUpdateLedgerCustVendNumExt = timerfactory.Create<Finance.Chinese.ICHSUpdateLedgerCustVendNum>(_CHSUpdateLedgerCustVendNum);
			
			return iCHSUpdateLedgerCustVendNumExt;
		}
	}
}
