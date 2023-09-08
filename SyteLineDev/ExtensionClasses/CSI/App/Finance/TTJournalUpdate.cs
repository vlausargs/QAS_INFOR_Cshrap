//PROJECT NAME: Finance
//CLASS NAME: TTJournalUpda.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalUpda : ITTJournalUpda
	{
		readonly IApplicationDB appDB;
		
		
		public TTJournalUpda(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TTJournalUpdate(Guid? PRowPointer,
		int? PPost,
		string PJStatus,
		string Infobar)
		{
			RowPointerType _PRowPointer = PRowPointer;
			ListYesNoType _PPost = PPost;
			JournalPostStatusType _PJStatus = PJStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTJournalUpdate";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPost", _PPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJStatus", _PJStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
