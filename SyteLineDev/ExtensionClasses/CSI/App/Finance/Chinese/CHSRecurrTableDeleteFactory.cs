//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSRecurrTableDeleteFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSRecurrTableDeleteFactory
	{
		public ICHSRecurrTableDelete Create(IApplicationDB appDB)
		{
			var _CHSRecurrTableDelete = new Finance.Chinese.CHSRecurrTableDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRecurrTableDeleteExt = timerfactory.Create<Finance.Chinese.ICHSRecurrTableDelete>(_CHSRecurrTableDelete);
			
			return iCHSRecurrTableDeleteExt;
		}
	}
}
