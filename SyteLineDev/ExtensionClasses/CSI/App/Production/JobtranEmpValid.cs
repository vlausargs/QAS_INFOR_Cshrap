//PROJECT NAME: Production
//CLASS NAME: JobtranEmpValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtranEmpValid : IJobtranEmpValid
	{
		readonly IApplicationDB appDB;
		
		
		public JobtranEmpValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutShift,
		string OutEmpName,
		decimal? OutPrRate,
		decimal? OutJobRate,
		string PromptMsg,
		string PromptButtons) JobtranEmpValidSp(string EmpNum,
		string PayRate,
		DateTime? TransDate,
		string OutShift,
		string OutEmpName,
		decimal? OutPrRate,
		decimal? OutJobRate,
		string PromptMsg,
		string PromptButtons)
		{
			EmpNumType _EmpNum = EmpNum;
			PayBasisType _PayRate = PayRate;
			DateType _TransDate = TransDate;
			ShiftType _OutShift = OutShift;
			NameType _OutEmpName = OutEmpName;
			PayRateType _OutPrRate = OutPrRate;
			PayRateType _OutJobRate = OutJobRate;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranEmpValidSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayRate", _PayRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutShift", _OutShift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutEmpName", _OutEmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutPrRate", _OutPrRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutJobRate", _OutJobRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutShift = _OutShift;
				OutEmpName = _OutEmpName;
				OutPrRate = _OutPrRate;
				OutJobRate = _OutJobRate;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, OutShift, OutEmpName, OutPrRate, OutJobRate, PromptMsg, PromptButtons);
			}
		}
	}
}
