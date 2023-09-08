//PROJECT NAME: Logistics
//CLASS NAME: ValidateReqNumForConvert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateReqNumForConvert : IValidateReqNumForConvert
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateReqNumForConvert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? StartLineNum,
		int? EndLineNum,
		string Infobar) ValidateReqNumForConvertSp(string ReqNum,
		int? StartLineNum,
		int? EndLineNum,
		string Infobar)
		{
			ReqNumType _ReqNum = ReqNum;
			ReqLineType _StartLineNum = StartLineNum;
			ReqLineType _EndLineNum = EndLineNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateReqNumForConvertSp";
				
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartLineNum = _StartLineNum;
				EndLineNum = _EndLineNum;
				Infobar = _Infobar;
				
				return (Severity, StartLineNum, EndLineNum, Infobar);
			}
		}
	}
}
