//PROJECT NAME: Finance
//CLASS NAME: EXTCHSPrePostVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSPrePostVal : IEXTCHSPrePostVal
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSPrePostVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSPrePostValSp(
			string PJournalId,
			Guid? SessionID,
			string Infobar = null)
		{
			JournalIdType _PJournalId = PJournalId;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSPrePostValSp";
				
				appDB.AddCommandParameter(cmd, "PJournalId", _PJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
