//PROJECT NAME: Finance
//CLASS NAME: LedgerCompressPostComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class LedgerCompressPostComplete : ILedgerCompressPostComplete
	{
		readonly IApplicationDB appDB;
		
		
		public LedgerCompressPostComplete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LedgerCompressPostCompleteSp(string PLedgerTable,
		Guid? ProcessId,
		string Infobar,
		int? Override = 0,
		int? IsFromFsb = 0)
		{
			LongListType _PLedgerTable = PLedgerTable;
			GuidType _ProcessId = ProcessId;
			InfobarType _Infobar = Infobar;
			IntType _Override = Override;
			ListYesNoType _IsFromFsb = IsFromFsb;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerCompressPostCompleteSp";
				
				appDB.AddCommandParameter(cmd, "PLedgerTable", _PLedgerTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Override", _Override, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsFromFsb", _IsFromFsb, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
