//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FatranPostVerifyCloseFormFactory
	{
		public IFatranPostVerifyCloseForm Create(IApplicationDB appDB)
		{
			var _FatranPostVerifyCloseForm = new Finance.FatranPostVerifyCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFatranPostVerifyCloseFormExt = timerfactory.Create<Finance.IFatranPostVerifyCloseForm>(_FatranPostVerifyCloseForm);
			
			return iFatranPostVerifyCloseFormExt;
		}
	}
}
