//PROJECT NAME: Data
//CLASS NAME: GenericSendEmail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GenericSendEmail : IGenericSendEmail
	{
		readonly IApplicationDB appDB;
		
		public GenericSendEmail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenericSendEmailSp(
			string EmailToAddrs,
			string EmailCCAddrs,
			string EmailSubject,
			string EmailContent,
			string Infobar)
		{
			LongListType _EmailToAddrs = EmailToAddrs;
			LongListType _EmailCCAddrs = EmailCCAddrs;
			LongListType _EmailSubject = EmailSubject;
			NoteType _EmailContent = EmailContent;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenericSendEmailSp";
				
				appDB.AddCommandParameter(cmd, "EmailToAddrs", _EmailToAddrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailCCAddrs", _EmailCCAddrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailSubject", _EmailSubject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailContent", _EmailContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
