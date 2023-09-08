//PROJECT NAME: CSIFinance
//CLASS NAME: GLYearEndClosingFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GLYearEndClosingFactory
	{
		public IGLYearEndClosing Create(IApplicationDB appDB)
		{
			var _GLYearEndClosing = new Finance.GLYearEndClosing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGLYearEndClosingExt = timerfactory.Create<Finance.IGLYearEndClosing>(_GLYearEndClosing);
			
			return iGLYearEndClosingExt;
		}
	}
}
