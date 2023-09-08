//PROJECT NAME: Finance
//CLASS NAME: EXTCHSPurgeJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSPurgeJournal : IEXTCHSPurgeJournal
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSPurgeJournal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSPurgeJournalSp(
			string JournalId,
			DateTime? CutoffDate,
			int? CutoffDateOffset = null,
			string Infobar = null)
		{
			JournalIdType _JournalId = JournalId;
			DateType _CutoffDate = CutoffDate;
			DateOffsetType _CutoffDateOffset = CutoffDateOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSPurgeJournalSp";
				
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
