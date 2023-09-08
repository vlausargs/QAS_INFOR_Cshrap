//PROJECT NAME: Admin
//CLASS NAME: FireGenericNotifyToGC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class FireGenericNotifyToGC : IFireGenericNotifyToGC
	{
		readonly IApplicationDB appDB;
		
		
		public FireGenericNotifyToGC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FireGenericNotifyToGCSp(string GlobalConstants,
		string Subject,
		string Category = null,
		string Body = null,
		string HTMLBody = null,
		string Infobar = null)
		{
			LongListType _GlobalConstants = GlobalConstants;
			MessageSubjectType _Subject = Subject;
			MessageCategoryType _Category = Category;
			NoteType _Body = Body;
			NoteType _HTMLBody = HTMLBody;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FireGenericNotifyToGCSp";
				
				appDB.AddCommandParameter(cmd, "GlobalConstants", _GlobalConstants, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Subject", _Subject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Body", _Body, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HTMLBody", _HTMLBody, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
