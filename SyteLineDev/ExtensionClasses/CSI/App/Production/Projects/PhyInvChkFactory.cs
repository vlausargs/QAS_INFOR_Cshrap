//PROJECT NAME: Production
//CLASS NAME: PhyInvChkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class PhyInvChkFactory
	{
		public IPhyInvChk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyInvChk = new Production.Projects.PhyInvChk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyInvChkExt = timerfactory.Create<Production.Projects.IPhyInvChk>(_PhyInvChk);
			
			return iPhyInvChkExt;
		}
	}
}
