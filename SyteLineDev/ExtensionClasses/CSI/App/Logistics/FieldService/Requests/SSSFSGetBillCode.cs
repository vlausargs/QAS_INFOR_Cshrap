//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetBillCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetBillCode : ISSSFSGetBillCode
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSGetBillCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OBillCode,
		string Prompt,
		string PromptButtons,
		string Infobar) SSSFSGetBillCodeSp(string Table,
		string ISroNum,
		int? ISroLine,
		int? ISroOper,
		DateTime? TransDate,
		DateTime? LineExchDate,
		string OBillCode,
		string Prompt,
		string PromptButtons,
		string Infobar)
		{
			StringType _Table = Table;
			FSSRONumType _ISroNum = ISroNum;
			FSSROLineType _ISroLine = ISroLine;
			FSSROOperType _ISroOper = ISroOper;
			DateType _TransDate = TransDate;
			DateType _LineExchDate = LineExchDate;
			FSSROBillCodeType _OBillCode = OBillCode;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetBillCodeSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISroNum", _ISroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISroLine", _ISroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISroOper", _ISroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineExchDate", _LineExchDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OBillCode", _OBillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OBillCode = _OBillCode;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, OBillCode, Prompt, PromptButtons, Infobar);
			}
		}
	}
}
