//PROJECT NAME: Logistics
//CLASS NAME: ValidateFromDoNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateFromDoNumForCopy : IValidateFromDoNumForCopy
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateFromDoNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CopyLines,
		int? StartLineNum,
		int? EndLineNum,
		string Infobar) ValidateFromDoNumForCopySp(string FROMDoNum,
		string CopyLines,
		int? StartLineNum,
		int? EndLineNum,
		string Infobar)
		{
			DoNumType _FROMDoNum = FROMDoNum;
			StringType _CopyLines = CopyLines;
			DoLineType _StartLineNum = StartLineNum;
			DoLineType _EndLineNum = EndLineNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateFromDoNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "FROMDoNum", _FROMDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyLines", _CopyLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CopyLines = _CopyLines;
				StartLineNum = _StartLineNum;
				EndLineNum = _EndLineNum;
				Infobar = _Infobar;
				
				return (Severity, CopyLines, StartLineNum, EndLineNum, Infobar);
			}
		}
	}
}
