//PROJECT NAME: Codes
//CLASS NAME: SendCommentEmail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface ISendCommentEmail
	{
		int? SendCommentEmailSp(string Comment,
		                        string UserName);
	}
	
	public class SendCommentEmail : ISendCommentEmail
	{
		readonly IApplicationDB appDB;
		
		public SendCommentEmail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SendCommentEmailSp(string Comment,
		                               string UserName)
		{
			StringType _Comment = Comment;
			UsernameType _UserName = UserName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SendCommentEmailSp";
				
				appDB.AddCommandParameter(cmd, "Comment", _Comment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
