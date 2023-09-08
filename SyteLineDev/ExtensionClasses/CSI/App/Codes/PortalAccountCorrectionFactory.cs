//PROJECT NAME: CSICodes
//CLASS NAME: PortalAccountCorrectionFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PortalAccountCorrectionFactory
	{
		public IPortalAccountCorrection Create(IApplicationDB appDB)
		{
			var _PortalAccountCorrection = new Codes.PortalAccountCorrection(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalAccountCorrectionExt = timerfactory.Create<Codes.IPortalAccountCorrection>(_PortalAccountCorrection);
			
			return iPortalAccountCorrectionExt;
		}
	}
}
