//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostVerifyPrintFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FatranPostVerifyPrintFactory
	{
		public IFatranPostVerifyPrint Create(IApplicationDB appDB)
		{
			var _FatranPostVerifyPrint = new Finance.FatranPostVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFatranPostVerifyPrintExt = timerfactory.Create<Finance.IFatranPostVerifyPrint>(_FatranPostVerifyPrint);
			
			return iFatranPostVerifyPrintExt;
		}
	}
}
