//PROJECT NAME: THLOC
//CLASS NAME: THAGetCompNameAndAddrFactory.cs

using CSI.MG;

namespace CSI.THLOC
{
	public class THAGetCompNameAndAddrFactory
	{
		public ITHAGetCompNameAndAddr Create(IApplicationDB appDB)
		{
			var _THAGetCompNameAndAddr = new THLOC.THAGetCompNameAndAddr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAGetCompNameAndAddrExt = timerfactory.Create<THLOC.ITHAGetCompNameAndAddr>(_THAGetCompNameAndAddr);
			
			return iTHAGetCompNameAndAddrExt;
		}
	}
}
