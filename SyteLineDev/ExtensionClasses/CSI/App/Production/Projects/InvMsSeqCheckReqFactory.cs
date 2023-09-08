//PROJECT NAME: CSIProjects
//CLASS NAME: InvMsSeqCheckReqFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class InvMsSeqCheckReqFactory
	{
		public IInvMsSeqCheckReq Create(IApplicationDB appDB)
		{
			var _InvMsSeqCheckReq = new Production.Projects.InvMsSeqCheckReq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvMsSeqCheckReqExt = timerfactory.Create<Production.Projects.IInvMsSeqCheckReq>(_InvMsSeqCheckReq);
			
			return iInvMsSeqCheckReqExt;
		}
	}
}
