//PROJECT NAME: CSIFinance
//CLASS NAME: GlPostSFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GlPostSFactory
	{
		public IGlPostS Create(IApplicationDB appDB)
		{
			var _GlPostS = new Finance.GlPostS(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlPostSExt = timerfactory.Create<Finance.IGlPostS>(_GlPostS);
			
			return iGlPostSExt;
		}
	}
}
