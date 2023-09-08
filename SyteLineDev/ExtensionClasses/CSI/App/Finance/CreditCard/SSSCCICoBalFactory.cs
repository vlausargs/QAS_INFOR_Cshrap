//PROJECT NAME: Finance
//CLASS NAME: SSSCCICoBalFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCICoBalFactory
	{
		public ISSSCCICoBal Create(IApplicationDB appDB)
		{
			var _SSSCCICoBal = new Finance.CreditCard.SSSCCICoBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCICoBalExt = timerfactory.Create<Finance.CreditCard.ISSSCCICoBal>(_SSSCCICoBal);
			
			return iSSSCCICoBalExt;
		}
	}
}
