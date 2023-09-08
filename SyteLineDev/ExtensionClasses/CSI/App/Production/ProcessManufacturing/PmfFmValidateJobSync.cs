//PROJECT NAME: Production
//CLASS NAME: PmfFmValidateJobSync.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmValidateJobSync
	{
		(int? ReturnCode, string Infobar, string PromptMsg, string PromptButtons) PmfFmValidateJobSyncSp(string Infobar,
		                                                                                                 Guid? FormulaRowPointer,
		                                                                                                 int? CheckJobSync = 1,
		                                                                                                 int? CheckFormulaSync = 1,
		                                                                                                 string PromptMsg = null,
		                                                                                                 string PromptButtons = null);
	}
	
	public class PmfFmValidateJobSync : IPmfFmValidateJobSync
	{
		readonly IApplicationDB appDB;
		
		public PmfFmValidateJobSync(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string PromptMsg, string PromptButtons) PmfFmValidateJobSyncSp(string Infobar,
		                                                                                                        Guid? FormulaRowPointer,
		                                                                                                        int? CheckJobSync = 1,
		                                                                                                        int? CheckFormulaSync = 1,
		                                                                                                        string PromptMsg = null,
		                                                                                                        string PromptButtons = null)
		{
			InfobarType _Infobar = Infobar;
			RowPointer _FormulaRowPointer = FormulaRowPointer;
			IntType _CheckJobSync = CheckJobSync;
			IntType _CheckFormulaSync = CheckFormulaSync;
			StringType _PromptMsg = PromptMsg;
			StringType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmValidateJobSyncSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FormulaRowPointer", _FormulaRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckJobSync", _CheckJobSync, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckFormulaSync", _CheckFormulaSync, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
