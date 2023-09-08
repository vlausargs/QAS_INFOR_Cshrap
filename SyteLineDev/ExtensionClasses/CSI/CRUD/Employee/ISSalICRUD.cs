//PROJECT NAME: Employee
//CLASS NAME: ISSalICRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ISSalICRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		Guid? Sal_ChgLoad(string PReasonCode, Guid? SalChgRowPointer);
		(Guid? PrparmsRowPointer,
			 decimal? PrparmsHrsWeek,
			 decimal? PrparmsHrsDay,
			 decimal? PrparmsHrsBiWeek,
			 decimal? PrparmsHrsSemiMo,
			 decimal? PrparmsHrsMo,
			 decimal? PrparmsHrsQuart,
			 decimal? PrparmsOtFactor,
			 decimal? PrparmsDtFactor,
			 int? PrparmsYrDay,
			 int? PrparmsYrWeek,
			 int? PrparmsYrBiWeek,
			 int? PrparmsYrSemiMo,
			 int? PrparmsYrMo,
			 int? PrparmsYrQuart) PrparmsLoad(Guid? PrparmsRowPointer, decimal? PrparmsHrsWeek, decimal? PrparmsHrsDay, decimal? PrparmsHrsBiWeek, decimal? PrparmsHrsSemiMo, decimal? PrparmsHrsMo, decimal? PrparmsHrsQuart, decimal? PrparmsOtFactor, decimal? PrparmsDtFactor, int? PrparmsYrDay, int? PrparmsYrWeek, int? PrparmsYrBiWeek, int? PrparmsYrSemiMo, int? PrparmsYrMo, int? PrparmsYrQuart);
		(Guid? EmpSalaryRowPointer, decimal? EmpSalarySalary, string EmpSalaryPayFreq) Emp_SalaryLoad(string PEmpNum, DateTime? PSalDate, Guid? EmpSalaryRowPointer, decimal? EmpSalarySalary, string EmpSalaryPayFreq);
		(Guid? PrevSalRowPointer, decimal? PrevSalAnnual) Emp_Salary1Load(string PEmpNum, DateTime? PSalDate, Guid? PrevSalRowPointer, decimal? PrevSalAnnual);
		(Guid? PostSalRowPointer, decimal? PostSalPctIncr, decimal? PostSalAnnual) Emp_Salary2Load(string PEmpNum, DateTime? PSalDate, Guid? PostSalRowPointer, decimal? PostSalAnnual, decimal? PostSalPctIncr);
		(Guid? EmployeeRowPointer,
			 string EmployeePayFreq,
			 decimal? EmployeeSalary,
			 string EmployeeEmpType,
			 decimal? EmployeeRegRate,
			 decimal? EmployeeOtRate,
			 decimal? EmployeeDtRate,
			 decimal? EmployeeMfgRegRate,
			 decimal? EmployeeMfgOtRate,
			 decimal? EmployeeMfgDtRate) EmployeeLoad(string PEmpNum, Guid? EmployeeRowPointer, string EmployeePayFreq, decimal? EmployeeSalary, string EmployeeEmpType, decimal? EmployeeRegRate, decimal? EmployeeOtRate, decimal? EmployeeDtRate, decimal? EmployeeMfgRegRate, decimal? EmployeeMfgOtRate, decimal? EmployeeMfgDtRate);
		ICollectionLoadResponse Employee1Select(string PEmpNum);
		void Employee1Update(string EmployeePayFreq, decimal? EmployeeSalary, decimal? EmployeeRegRate, decimal? EmployeeOtRate, decimal? EmployeeDtRate, decimal? EmployeeMfgRegRate, decimal? EmployeeMfgOtRate, decimal? EmployeeMfgDtRate, ICollectionLoadResponse employee1LoadResponse);
		ICollectionLoadResponse EmpinsSelect(string PEmpNum);
		(Guid? InsuranceRowPointer, string InsuranceInsType) InsuranceLoad(string EmpinsCode, Guid? InsuranceRowPointer, string InsuranceInsType);
		(Guid? InsHcRowPointer, decimal? InsHcPrice, decimal? InsHcCompCont) Ins_HcLoad(string EmpinsCode, string EmpinsCovgCls, Guid? InsHcRowPointer, decimal? InsHcPrice, decimal? InsHcCompCont);
		ICollectionLoadResponse Empins1Select(Guid? EmpinsRowPointer);
		void Empins1Update(decimal? EmpinsCost, decimal? EmpinsCompCntr, decimal? EmpinsEmplCost, ICollectionLoadResponse empins1LoadResponse);
		ICollectionLoadResponse NontableSelect(string PEmpNum, DateTime? PSalDate, decimal? PSalary, decimal? EmpSalaryAnnual, string PSalaryPeriod, decimal? EmpSalaryHrlyRate, decimal? EmpSalaryPctIncr, string PReasonCode, string PPayFreq);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse Emp_Salary3Select(Guid? EmpSalaryRowPointer);
		void Emp_Salary3Update(decimal? PSalary, string PReasonCode, string PPayFreq, decimal? EmpSalaryHrlyRate, decimal? EmpSalaryAnnual, decimal? EmpSalaryPctIncr, ICollectionLoadResponse emp_salary3LoadResponse);
		(int? ReturnCode, string Infobar) AltExtGen_SSalISp(string AltExtGenSp, string PEmpNum, DateTime? PSalDate, DateTime? PJobDate, decimal? PSalary, string PSalaryPeriod, string PReasonCode, string PPayFreq, string Infobar, int? PFlageCheckReasonCode);
	}
}

