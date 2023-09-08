//PROJECT NAME: Employee
//CLASS NAME: Prtrxgc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPrtrxgc
	{
		(int? ReturnCode, int? RestartFlag, Guid? RestartRow, string PromptMsg, string PromptButtons, string Infobar) PrtrxgcSp(string SEmployee,
		string EEmployee,
		string PIncPayFreq,
		string PEmplType,
		int? RestartFlag,
		Guid? RestartRow,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string PStartEmpCate = null,
		string PEndEmpCate = null);
	}
	
	public class Prtrxgc : IPrtrxgc
	{
		readonly IApplicationDB appDB;
		
		public Prtrxgc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RestartFlag, Guid? RestartRow, string PromptMsg, string PromptButtons, string Infobar) PrtrxgcSp(string SEmployee,
		string EEmployee,
		string PIncPayFreq,
		string PEmplType,
		int? RestartFlag,
		Guid? RestartRow,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string PStartEmpCate = null,
		string PEndEmpCate = null)
		{
			EmpNumType _SEmployee = SEmployee;
			EmpNumType _EEmployee = EEmployee;
			LongListType _PIncPayFreq = PIncPayFreq;
			LongListType _PEmplType = PEmplType;
			IntType _RestartFlag = RestartFlag;
			RowPointerType _RestartRow = RestartRow;
			InfobarType _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxgcSp";
				
				appDB.AddCommandParameter(cmd, "SEmployee", _SEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEmployee", _EEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIncPayFreq", _PIncPayFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmplType", _PEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RestartFlag", _RestartFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RestartRow", _RestartRow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RestartFlag = _RestartFlag;
				RestartRow = _RestartRow;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, RestartFlag, RestartRow, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
