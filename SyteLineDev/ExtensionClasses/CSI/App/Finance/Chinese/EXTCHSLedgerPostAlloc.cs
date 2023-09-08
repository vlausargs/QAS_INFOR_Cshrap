//PROJECT NAME: Finance
//CLASS NAME: EXTCHSLedgerPostAlloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSLedgerPostAlloc : IEXTCHSLedgerPostAlloc
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSLedgerPostAlloc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSLedgerPostAllocSp(
			string pJournalId,
			string Infobar = null)
		{
			JournalIdType _pJournalId = pJournalId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSLedgerPostAllocSp";
				
				appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
