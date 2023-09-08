//PROJECT NAME: Data
//CLASS NAME: EFTImportBankStatementDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EFTImportBankStatementDelete : IEFTImportBankStatementDelete
	{
		readonly IApplicationDB appDB;
		
		public EFTImportBankStatementDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EFTImportBankStatementDeleteSp(
			string FileName,
			string Infobar)
		{
			OSResourceNameType _FileName = FileName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportBankStatementDelete";
				
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
