//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetPartnerFactory.cs

using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSGetPartnerFactory
	{
		public ISSSPOSGetPartner Create(IApplicationDB appDB)
		{
			var _SSSPOSGetPartner = new POS.SSSPOSGetPartner(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSGetPartnerExt = timerfactory.Create<POS.ISSSPOSGetPartner>(_SSSPOSGetPartner);
			
			return iSSSPOSGetPartnerExt;
		}
	}
}
