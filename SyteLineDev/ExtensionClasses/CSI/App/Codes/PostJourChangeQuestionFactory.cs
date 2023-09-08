//PROJECT NAME: CSICodes
//CLASS NAME: PostJourChangeQuestionFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PostJourChangeQuestionFactory
	{
		public IPostJourChangeQuestion Create(IApplicationDB appDB)
		{
			var _PostJourChangeQuestion = new Codes.PostJourChangeQuestion(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostJourChangeQuestionExt = timerfactory.Create<Codes.IPostJourChangeQuestion>(_PostJourChangeQuestion);
			
			return iPostJourChangeQuestionExt;
		}
	}
}
