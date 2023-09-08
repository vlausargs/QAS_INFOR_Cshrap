//PROJECT NAME: Logistics
//CLASS NAME: ValidateToDoNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateToDoNumForCopy : IValidateToDoNumForCopy
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateToDoNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CopyLines,
		string CopyOption,
		string Infobar) ValidateToDoNumForCopySp(string FROMDoNum,
		string ToDoNum,
		string CopyLines,
		string CopyOption,
		string Infobar)
		{
			DoNumType _FROMDoNum = FROMDoNum;
			DoNumType _ToDoNum = ToDoNum;
			StringType _CopyLines = CopyLines;
			StringType _CopyOption = CopyOption;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateToDoNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "FROMDoNum", _FROMDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDoNum", _ToDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyLines", _CopyLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CopyLines = _CopyLines;
				CopyOption = _CopyOption;
				Infobar = _Infobar;
				
				return (Severity, CopyLines, CopyOption, Infobar);
			}
		}
	}
}
