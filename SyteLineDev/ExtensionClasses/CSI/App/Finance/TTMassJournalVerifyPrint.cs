//PROJECT NAME: Finance
//CLASS NAME: TTMassJournalVerifyPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TTMassJournalVerifyPrint : ITTMassJournalVerifyPrint
	{
		readonly IApplicationDB appDB;
		
		
		public TTMassJournalVerifyPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TTMassJournalVerifyPrintSp(Guid? PSessionID,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTMassJournalVerifyPrintSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
