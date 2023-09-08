//PROJECT NAME: Finance
//CLASS NAME: TTJournalGetText.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalGetText : ITTJournalGetText
	{
		readonly IApplicationDB appDB;
		
		
		public TTJournalGetText(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ROutOfRange,
		string RToPost,
		string RToPrint,
		string RPosted,
		string REmpty,
		string Infobar) TTJournalGetTextSp(string ROutOfRange,
		string RToPost,
		string RToPrint,
		string RPosted,
		string REmpty,
		string Infobar)
		{
			InfobarType _ROutOfRange = ROutOfRange;
			InfobarType _RToPost = RToPost;
			InfobarType _RToPrint = RToPrint;
			InfobarType _RPosted = RPosted;
			InfobarType _REmpty = REmpty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTJournalGetTextSp";
				
				appDB.AddCommandParameter(cmd, "ROutOfRange", _ROutOfRange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RToPost", _RToPost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RToPrint", _RToPrint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RPosted", _RPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "REmpty", _REmpty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ROutOfRange = _ROutOfRange;
				RToPost = _RToPost;
				RToPrint = _RToPrint;
				RPosted = _RPosted;
				REmpty = _REmpty;
				Infobar = _Infobar;
				
				return (Severity, ROutOfRange, RToPost, RToPrint, RPosted, REmpty, Infobar);
			}
		}
	}
}
