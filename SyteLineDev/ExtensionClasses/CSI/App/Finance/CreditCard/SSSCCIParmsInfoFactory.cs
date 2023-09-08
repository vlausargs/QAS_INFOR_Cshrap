//PROJECT NAME: CSICCI
//CLASS NAME: SSSCCIParmsInfoFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIParmsInfoFactory
	{
		public ISSSCCIParmsInfo Create(IApplicationDB appDB)
		{
			var _SSSCCIParmsInfo = new Finance.CreditCard.SSSCCIParmsInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIParmsInfoExt = timerfactory.Create<Finance.CreditCard.ISSSCCIParmsInfo>(_SSSCCIParmsInfo);
			
			return iSSSCCIParmsInfoExt;
		}
	}
}
