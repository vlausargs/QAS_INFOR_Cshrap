//PROJECT NAME: Codes
//CLASS NAME: SendCommentEmailFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class SendCommentEmailFactory
	{
		public ISendCommentEmail Create(IApplicationDB appDB)
		{
			var _SendCommentEmail = new Codes.SendCommentEmail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSendCommentEmailExt = timerfactory.Create<Codes.ISendCommentEmail>(_SendCommentEmail);
			
			return iSendCommentEmailExt;
		}
	}
}
