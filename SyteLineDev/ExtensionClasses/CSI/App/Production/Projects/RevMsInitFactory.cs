//PROJECT NAME: Production
//CLASS NAME: RevMsInitFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMsInitFactory
	{
		public IRevMsInit Create(IApplicationDB appDB)
		{
			var _RevMsInit = new Production.Projects.RevMsInit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRevMsInitExt = timerfactory.Create<Production.Projects.IRevMsInit>(_RevMsInit);
			
			return iRevMsInitExt;
		}
	}
}
