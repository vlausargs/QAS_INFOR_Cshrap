//PROJECT NAME: Production
//CLASS NAME: RevMsSeqCheckReqFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMsSeqCheckReqFactory
	{
		public IRevMsSeqCheckReq Create(IApplicationDB appDB)
		{
			var _RevMsSeqCheckReq = new Production.Projects.RevMsSeqCheckReq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRevMsSeqCheckReqExt = timerfactory.Create<Production.Projects.IRevMsSeqCheckReq>(_RevMsSeqCheckReq);
			
			return iRevMsSeqCheckReqExt;
		}
	}
}
