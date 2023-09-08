//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSIncrementCndtItemFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSIncrementCndtItemFactory
	{
		public ICHSIncrementCndtItem Create(IApplicationDB appDB)
		{
			var _CHSIncrementCndtItem = new Finance.Chinese.CHSIncrementCndtItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSIncrementCndtItemExt = timerfactory.Create<Finance.Chinese.ICHSIncrementCndtItem>(_CHSIncrementCndtItem);
			
			return iCHSIncrementCndtItemExt;
		}
	}
}
