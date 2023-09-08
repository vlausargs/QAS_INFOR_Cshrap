//PROJECT NAME: CSICodes
//CLASS NAME: PostJourChangeQuestion.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPostJourChangeQuestion
	{
		int PostJourChangeQuestionSp(byte? PostJour,
		                             ref string PromptMsg,
		                             ref string Buttons);
	}
	
	public class PostJourChangeQuestion : IPostJourChangeQuestion
	{
		readonly IApplicationDB appDB;
		
		public PostJourChangeQuestion(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PostJourChangeQuestionSp(byte? PostJour,
		                                    ref string PromptMsg,
		                                    ref string Buttons)
		{
			ListYesNoType _PostJour = PostJour;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Buttons = Buttons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostJourChangeQuestionSp";
				
				appDB.AddCommandParameter(cmd, "PostJour", _PostJour, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				Buttons = _Buttons;
				
				return Severity;
			}
		}
	}
}
