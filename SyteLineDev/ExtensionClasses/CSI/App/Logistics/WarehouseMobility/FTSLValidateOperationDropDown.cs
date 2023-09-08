//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateOperationDropDown.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateOperationDropDown
	{
		(int? ReturnCode, short? IsComplete,
		string InfoBar) FTSLValidateOperationDropDownSp(string CallForm,
		string Job,
		short? Suffix,
		int? Operation,
		string EmpNum = null,
		short? IsComplete = 0,
		string InfoBar = null);
	}
	
	public class FTSLValidateOperationDropDown : IFTSLValidateOperationDropDown
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateOperationDropDown(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? IsComplete,
		string InfoBar) FTSLValidateOperationDropDownSp(string CallForm,
		string Job,
		short? Suffix,
		int? Operation,
		string EmpNum = null,
		short? IsComplete = 0,
		string InfoBar = null)
		{
			JobType _CallForm = CallForm;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;
			EmpNumType _EmpNum = EmpNum;
			CoLineType _IsComplete = IsComplete;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateOperationDropDownSp";
				
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsComplete", _IsComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsComplete = _IsComplete;
				InfoBar = _InfoBar;
				
				return (Severity, IsComplete, InfoBar);
			}
		}
	}
}
