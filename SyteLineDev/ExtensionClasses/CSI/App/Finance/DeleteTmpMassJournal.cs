//PROJECT NAME: CSIFinance
//CLASS NAME: DeleteTmpMassJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IDeleteTmpMassJournal
	{
		(int? ReturnCode, string Infobar) DeleteTmpMassJournalSp(Guid? ProcessId,
		byte? Initialize = (byte)0,
		string Infobar = null);
	}
	
	public class DeleteTmpMassJournal : IDeleteTmpMassJournal
	{
		readonly IApplicationDB appDB;
		
		public DeleteTmpMassJournal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteTmpMassJournalSp(Guid? ProcessId,
		byte? Initialize = (byte)0,
		string Infobar = null)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Initialize = Initialize;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTmpMassJournalSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Initialize", _Initialize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
