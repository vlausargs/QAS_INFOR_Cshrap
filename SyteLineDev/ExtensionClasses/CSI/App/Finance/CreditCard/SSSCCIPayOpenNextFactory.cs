//PROJECT NAME: CSICCI
//CLASS NAME: SSSCCIPayOpenNextFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIPayOpenNextFactory
	{
		public ISSSCCIPayOpenNext Create(IApplicationDB appDB)
		{
			var _SSSCCIPayOpenNext = new Finance.CreditCard.SSSCCIPayOpenNext(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIPayOpenNextExt = timerfactory.Create<Finance.CreditCard.ISSSCCIPayOpenNext>(_SSSCCIPayOpenNext);
			
			return iSSSCCIPayOpenNextExt;
		}
	}
}
