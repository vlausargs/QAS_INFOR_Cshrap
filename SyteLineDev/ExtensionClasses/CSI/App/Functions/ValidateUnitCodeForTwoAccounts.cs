//PROJECT NAME: Data
//CLASS NAME: ValidateUnitCodeForTwoAccounts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateUnitCodeForTwoAccounts : IValidateUnitCodeForTwoAccounts
	{
		readonly IApplicationDB appDB;
		
		public ValidateUnitCodeForTwoAccounts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Unit1Msg,
			string Unit2Msg,
			string Unit3Msg,
			string Unit4Msg,
			int? Unit1Flag,
			int? Unit2Flag,
			int? Unit3Flag,
			int? Unit4Flag) ValidateUnitCodeForTwoAccountsSp(
			string TargetAccount,
			string CompareAccount,
			string Unit1Msg,
			string Unit2Msg,
			string Unit3Msg,
			string Unit4Msg,
			int? Unit1Flag,
			int? Unit2Flag,
			int? Unit3Flag,
			int? Unit4Flag)
		{
			AcctType _TargetAccount = TargetAccount;
			AcctType _CompareAccount = CompareAccount;
			Infobar _Unit1Msg = Unit1Msg;
			Infobar _Unit2Msg = Unit2Msg;
			Infobar _Unit3Msg = Unit3Msg;
			Infobar _Unit4Msg = Unit4Msg;
			FlagNyType _Unit1Flag = Unit1Flag;
			FlagNyType _Unit2Flag = Unit2Flag;
			FlagNyType _Unit3Flag = Unit3Flag;
			FlagNyType _Unit4Flag = Unit4Flag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateUnitCodeForTwoAccountsSp";
				
				appDB.AddCommandParameter(cmd, "TargetAccount", _TargetAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompareAccount", _CompareAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit1Msg", _Unit1Msg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit2Msg", _Unit2Msg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit3Msg", _Unit3Msg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit4Msg", _Unit4Msg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit1Flag", _Unit1Flag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit2Flag", _Unit2Flag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit3Flag", _Unit3Flag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit4Flag", _Unit4Flag, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Unit1Msg = _Unit1Msg;
				Unit2Msg = _Unit2Msg;
				Unit3Msg = _Unit3Msg;
				Unit4Msg = _Unit4Msg;
				Unit1Flag = _Unit1Flag;
				Unit2Flag = _Unit2Flag;
				Unit3Flag = _Unit3Flag;
				Unit4Flag = _Unit4Flag;
				
				return (Severity, Unit1Msg, Unit2Msg, Unit3Msg, Unit4Msg, Unit1Flag, Unit2Flag, Unit3Flag, Unit4Flag);
			}
		}
	}
}
