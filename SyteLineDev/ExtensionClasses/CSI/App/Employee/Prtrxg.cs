//PROJECT NAME: Employee
//CLASS NAME: Prtrxg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPrtrxg
	{
		(int? ReturnCode, string Infobar) PrtrxgSp(string SDepartment,
		string EDepartment,
		string SEmployee,
		string EEmployee,
		DateTime? PStartDate,
		DateTime? PEndDate,
		string PIncPayFreq,
		byte? PJobTrx,
		byte? PProjTrx,
		byte? PTimeAttend,
		byte? PSumAttend,
		string PEmplType,
		byte? PPrHrs,
		byte? PPrComm,
		byte? PPrServiceHours,
		DateTime? PCheckDate,
		string PPrDelWhich,
		string Infobar,
		string PStartEmpCate = null,
		string PEndEmpCate = null);
	}
	
	public class Prtrxg : IPrtrxg
	{
		readonly IApplicationDB appDB;
		
		public Prtrxg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PrtrxgSp(string SDepartment,
		string EDepartment,
		string SEmployee,
		string EEmployee,
		DateTime? PStartDate,
		DateTime? PEndDate,
		string PIncPayFreq,
		byte? PJobTrx,
		byte? PProjTrx,
		byte? PTimeAttend,
		byte? PSumAttend,
		string PEmplType,
		byte? PPrHrs,
		byte? PPrComm,
		byte? PPrServiceHours,
		DateTime? PCheckDate,
		string PPrDelWhich,
		string Infobar,
		string PStartEmpCate = null,
		string PEndEmpCate = null)
		{
			DeptType _SDepartment = SDepartment;
			DeptType _EDepartment = EDepartment;
			EmpNumType _SEmployee = SEmployee;
			EmpNumType _EEmployee = EEmployee;
			DateType _PStartDate = PStartDate;
			DateType _PEndDate = PEndDate;
			LongListType _PIncPayFreq = PIncPayFreq;
			ListYesNoType _PJobTrx = PJobTrx;
			ListYesNoType _PProjTrx = PProjTrx;
			ListYesNoType _PTimeAttend = PTimeAttend;
			ListYesNoType _PSumAttend = PSumAttend;
			LongListType _PEmplType = PEmplType;
			ListYesNoType _PPrHrs = PPrHrs;
			ListYesNoType _PPrComm = PPrComm;
			ListYesNoType _PPrServiceHours = PPrServiceHours;
			DateType _PCheckDate = PCheckDate;
			StringType _PPrDelWhich = PPrDelWhich;
			InfobarType _Infobar = Infobar;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxgSp";
				
				appDB.AddCommandParameter(cmd, "SDepartment", _SDepartment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDepartment", _EDepartment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SEmployee", _SEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEmployee", _EEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIncPayFreq", _PIncPayFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobTrx", _PJobTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjTrx", _PProjTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTimeAttend", _PTimeAttend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSumAttend", _PSumAttend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmplType", _PEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrHrs", _PPrHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrComm", _PPrComm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrServiceHours", _PPrServiceHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrDelWhich", _PPrDelWhich, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
