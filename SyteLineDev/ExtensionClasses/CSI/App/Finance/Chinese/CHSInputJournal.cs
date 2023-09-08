//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSInputJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSInputJournal
	{
		int CHSInputJournalSp(Guid? SessionId,
		                      string ControlNumber,
		                      ref string Infobar);
	}
	
	public class CHSInputJournal : ICHSInputJournal
	{
		readonly IApplicationDB appDB;
		
		public CHSInputJournal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CHSInputJournalSp(Guid? SessionId,
		                             string ControlNumber,
		                             ref string Infobar)
		{
			RowPointerType _SessionId = SessionId;
			StringType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSInputJournalSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
