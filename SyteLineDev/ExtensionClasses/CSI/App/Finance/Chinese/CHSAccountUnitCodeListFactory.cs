//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSAccountUnitCodeListFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSAccountUnitCodeListFactory
	{
		public ICHSAccountUnitCodeList Create(IApplicationDB appDB)
		{
			var _CHSAccountUnitCodeList = new Finance.Chinese.CHSAccountUnitCodeList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSAccountUnitCodeListExt = timerfactory.Create<Finance.Chinese.ICHSAccountUnitCodeList>(_CHSAccountUnitCodeList);
			
			return iCHSAccountUnitCodeListExt;
		}
	}
}
