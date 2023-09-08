//PROJECT NAME: CSICustomer
//CLASS NAME: ChkCreditMemoRMAFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ChkCreditMemoRMAFactory
	{
		public IChkCreditMemoRMA Create(IApplicationDB appDB)
		{
			var _ChkCreditMemoRMA = new Logistics.Customer.ChkCreditMemoRMA(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkCreditMemoRMAExt = timerfactory.Create<Logistics.Customer.IChkCreditMemoRMA>(_ChkCreditMemoRMA);
			
			return iChkCreditMemoRMAExt;
		}
	}
}
