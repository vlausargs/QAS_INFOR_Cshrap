//PROJECT NAME: Finance
//CLASS NAME: SSSCCIShipAuthUtilFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIShipAuthUtilFactory
	{
		public ISSSCCIShipAuthUtil Create(IApplicationDB appDB)
		{
			var _SSSCCIShipAuthUtil = new Finance.CreditCard.SSSCCIShipAuthUtil(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIShipAuthUtilExt = timerfactory.Create<Finance.CreditCard.ISSSCCIShipAuthUtil>(_SSSCCIShipAuthUtil);
			
			return iSSSCCIShipAuthUtilExt;
		}
	}
}
