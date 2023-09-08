//PROJECT NAME: CSICCI
//CLASS NAME: CCITotalAmtChangedFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class CCITotalAmtChangedFactory
	{
		public ICCITotalAmtChanged Create(IApplicationDB appDB)
		{
			var _CCITotalAmtChanged = new Finance.CreditCard.CCITotalAmtChanged(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCCITotalAmtChangedExt = timerfactory.Create<Finance.CreditCard.ICCITotalAmtChanged>(_CCITotalAmtChanged);
			
			return iCCITotalAmtChangedExt;
		}
	}
}
