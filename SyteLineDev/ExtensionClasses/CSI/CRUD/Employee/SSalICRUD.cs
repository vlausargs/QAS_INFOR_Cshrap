//PROJECT NAME: Employee
//CLASS NAME: SSalICRUD.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class SSalICRUD : ISSalICRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		
		public SSalICRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('SSalISp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('SSalISp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public string Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			return ALTGEN_SpName;
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public Guid? Sal_ChgLoad(string PReasonCode, Guid? SalChgRowPointer)
		{
			RowPointerType _SalChgRowPointer = DBNull.Value;
			
			var sal_chgLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_SalChgRowPointer,"sal_chg.RowPointer"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"sal_chg",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("sal_chg.reason_code = {0}",PReasonCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var sal_chgLoadResponse = this.appDB.Load(sal_chgLoadRequest);
			if(sal_chgLoadResponse.Items.Count > 0)
			{
				SalChgRowPointer = _SalChgRowPointer;
			}
			
			return SalChgRowPointer;
		}
		
		public (Guid? PrparmsRowPointer,
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
			int? PrparmsYrQuart)
		PrparmsLoad(Guid? PrparmsRowPointer,
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
			int? PrparmsYrQuart)
		{
			RowPointerType _PrparmsRowPointer = DBNull.Value;
			PrAmountType _PrparmsHrsWeek = DBNull.Value;
			PrAmountType _PrparmsHrsDay = DBNull.Value;
			PrAmountType _PrparmsHrsBiWeek = DBNull.Value;
			PrAmountType _PrparmsHrsSemiMo = DBNull.Value;
			PrAmountType _PrparmsHrsMo = DBNull.Value;
			PrAmountType _PrparmsHrsQuart = DBNull.Value;
			PayRateType _PrparmsOtFactor = DBNull.Value;
			PayRateType _PrparmsDtFactor = DBNull.Value;
			PrYearUnitsType _PrparmsYrDay = DBNull.Value;
			PrYearUnitsType _PrparmsYrWeek = DBNull.Value;
			PrYearUnitsType _PrparmsYrBiWeek = DBNull.Value;
			PrYearUnitsType _PrparmsYrSemiMo = DBNull.Value;
			PrYearUnitsType _PrparmsYrMo = DBNull.Value;
			PrYearUnitsType _PrparmsYrQuart = DBNull.Value;
			
			var prparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PrparmsRowPointer,"prparms.RowPointer"},
					{_PrparmsHrsWeek,"prparms.hrs_week"},
					{_PrparmsHrsDay,"prparms.hrs_day"},
					{_PrparmsHrsBiWeek,"prparms.hrs_bi_week"},
					{_PrparmsHrsSemiMo,"prparms.hrs_semi_mo"},
					{_PrparmsHrsMo,"prparms.hrs_mo"},
					{_PrparmsHrsQuart,"prparms.hrs_quart"},
					{_PrparmsOtFactor,"prparms.ot_factor"},
					{_PrparmsDtFactor,"prparms.dt_factor"},
					{_PrparmsYrDay,"prparms.yr_day"},
					{_PrparmsYrWeek,"prparms.yr_week"},
					{_PrparmsYrBiWeek,"prparms.yr_bi_week"},
					{_PrparmsYrSemiMo,"prparms.yr_semi_mo"},
					{_PrparmsYrMo,"prparms.yr_mo"},
					{_PrparmsYrQuart,"prparms.yr_quart"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"prparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prparmsLoadResponse = this.appDB.Load(prparmsLoadRequest);
			if(prparmsLoadResponse.Items.Count > 0)
			{
				PrparmsRowPointer = _PrparmsRowPointer;
				PrparmsHrsWeek = _PrparmsHrsWeek;
				PrparmsHrsDay = _PrparmsHrsDay;
				PrparmsHrsBiWeek = _PrparmsHrsBiWeek;
				PrparmsHrsSemiMo = _PrparmsHrsSemiMo;
				PrparmsHrsMo = _PrparmsHrsMo;
				PrparmsHrsQuart = _PrparmsHrsQuart;
				PrparmsOtFactor = _PrparmsOtFactor;
				PrparmsDtFactor = _PrparmsDtFactor;
				PrparmsYrDay = _PrparmsYrDay;
				PrparmsYrWeek = _PrparmsYrWeek;
				PrparmsYrBiWeek = _PrparmsYrBiWeek;
				PrparmsYrSemiMo = _PrparmsYrSemiMo;
				PrparmsYrMo = _PrparmsYrMo;
				PrparmsYrQuart = _PrparmsYrQuart;
			}
			
			return (PrparmsRowPointer, PrparmsHrsWeek, PrparmsHrsDay, PrparmsHrsBiWeek, PrparmsHrsSemiMo, PrparmsHrsMo, PrparmsHrsQuart, PrparmsOtFactor, PrparmsDtFactor, PrparmsYrDay, PrparmsYrWeek, PrparmsYrBiWeek, PrparmsYrSemiMo, PrparmsYrMo, PrparmsYrQuart);
		}
		
		public (Guid? EmpSalaryRowPointer, decimal? EmpSalarySalary, string EmpSalaryPayFreq) Emp_SalaryLoad(string PEmpNum, DateTime? PSalDate, Guid? EmpSalaryRowPointer, decimal? EmpSalarySalary, string EmpSalaryPayFreq)
		{
			RowPointerType _EmpSalaryRowPointer = DBNull.Value;
			PrAmountType _EmpSalarySalary = DBNull.Value;
			PrPayFreqType _EmpSalaryPayFreq = DBNull.Value;
			
			var emp_salaryLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_EmpSalaryRowPointer,"emp_salary.RowPointer"},
					{_EmpSalarySalary,"emp_salary.salary"},
					{_EmpSalaryPayFreq,"emp_salary.pay_freq"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"emp_salary",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("emp_salary.emp_num = {1} AND emp_salary.sal_date = {0}",PSalDate,PEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var emp_salaryLoadResponse = this.appDB.Load(emp_salaryLoadRequest);
			if(emp_salaryLoadResponse.Items.Count > 0)
			{
				EmpSalaryRowPointer = _EmpSalaryRowPointer;
				EmpSalarySalary = _EmpSalarySalary;
				EmpSalaryPayFreq = _EmpSalaryPayFreq;
			}
			
			return (EmpSalaryRowPointer, EmpSalarySalary, EmpSalaryPayFreq);
		}
		
		public (Guid? PrevSalRowPointer, decimal? PrevSalAnnual) Emp_Salary1Load(string PEmpNum, DateTime? PSalDate, Guid? PrevSalRowPointer, decimal? PrevSalAnnual)
		{
			RowPointerType _PrevSalRowPointer = DBNull.Value;
			AnnualSalaryType _PrevSalAnnual = DBNull.Value;
			
			var emp_salary1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PrevSalRowPointer,"emp_salary.RowPointer"},
					{_PrevSalAnnual,"emp_salary.annual"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"emp_salary",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("emp_salary.emp_num = {1} AND DATEDIFF(DAY, emp_salary.sal_date, {0}) > 0",PSalDate,PEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var emp_salary1LoadResponse = this.appDB.Load(emp_salary1LoadRequest);
			if(emp_salary1LoadResponse.Items.Count > 0)
			{
				PrevSalRowPointer = _PrevSalRowPointer;
				PrevSalAnnual = _PrevSalAnnual;
			}
			
			return (PrevSalRowPointer, PrevSalAnnual);
		}
		
		public (Guid? PostSalRowPointer, decimal? PostSalPctIncr, decimal? PostSalAnnual) Emp_Salary2Load(string PEmpNum, DateTime? PSalDate, Guid? PostSalRowPointer, decimal? PostSalAnnual, decimal? PostSalPctIncr)
		{
			RowPointerType _PostSalRowPointer = DBNull.Value;
			SalaryChangePercentType _PostSalPctIncr = DBNull.Value;
			AnnualSalaryType _PostSalAnnual = DBNull.Value;
			
			var emp_salary2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PostSalRowPointer,"emp_salary.RowPointer"},
					{_PostSalPctIncr,"emp_salary.pct_incr"},
					{_PostSalAnnual,"emp_salary.annual"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"emp_salary",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("emp_salary.emp_num = {1} AND DATEDIFF(DAY, {0}, emp_salary.sal_date) > 0",PSalDate,PEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var emp_salary2LoadResponse = this.appDB.Load(emp_salary2LoadRequest);
			if(emp_salary2LoadResponse.Items.Count > 0)
			{
				PostSalRowPointer = _PostSalRowPointer;
				PostSalPctIncr = _PostSalPctIncr;
				PostSalAnnual = _PostSalAnnual;
			}
			
			return (PostSalRowPointer, PostSalPctIncr, PostSalAnnual);
		}
		
		public (Guid? EmployeeRowPointer,
			string EmployeePayFreq,
			decimal? EmployeeSalary,
			string EmployeeEmpType,
			decimal? EmployeeRegRate,
			decimal? EmployeeOtRate,
			decimal? EmployeeDtRate,
			decimal? EmployeeMfgRegRate,
			decimal? EmployeeMfgOtRate,
			decimal? EmployeeMfgDtRate)
		EmployeeLoad(string PEmpNum,
			Guid? EmployeeRowPointer,
			string EmployeePayFreq,
			decimal? EmployeeSalary,
			string EmployeeEmpType,
			decimal? EmployeeRegRate,
			decimal? EmployeeOtRate,
			decimal? EmployeeDtRate,
			decimal? EmployeeMfgRegRate,
			decimal? EmployeeMfgOtRate,
			decimal? EmployeeMfgDtRate)
		{
			RowPointerType _EmployeeRowPointer = DBNull.Value;
			PrPayFreqType _EmployeePayFreq = DBNull.Value;
			PrAmountType _EmployeeSalary = DBNull.Value;
			EmpTypeType _EmployeeEmpType = DBNull.Value;
			PayRateType _EmployeeRegRate = DBNull.Value;
			PayRateType _EmployeeOtRate = DBNull.Value;
			PayRateType _EmployeeDtRate = DBNull.Value;
			PayRateType _EmployeeMfgRegRate = DBNull.Value;
			PayRateType _EmployeeMfgOtRate = DBNull.Value;
			PayRateType _EmployeeMfgDtRate = DBNull.Value;
			
			var employeeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_EmployeeRowPointer,"employee.RowPointer"},
					{_EmployeePayFreq,"employee.pay_freq"},
					{_EmployeeSalary,"employee.salary"},
					{_EmployeeEmpType,"employee.emp_type"},
					{_EmployeeRegRate,"employee.reg_rate"},
					{_EmployeeOtRate,"employee.ot_rate"},
					{_EmployeeDtRate,"employee.dt_rate"},
					{_EmployeeMfgRegRate,"employee.mfg_reg_rate"},
					{_EmployeeMfgOtRate,"employee.mfg_ot_rate"},
					{_EmployeeMfgDtRate,"employee.mfg_dt_rate"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"employee",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (UPDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("employee.emp_num = {0}",PEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var employeeLoadResponse = this.appDB.Load(employeeLoadRequest);
			if(employeeLoadResponse.Items.Count > 0)
			{
				EmployeeRowPointer = _EmployeeRowPointer;
				EmployeePayFreq = _EmployeePayFreq;
				EmployeeSalary = _EmployeeSalary;
				EmployeeEmpType = _EmployeeEmpType;
				EmployeeRegRate = _EmployeeRegRate;
				EmployeeOtRate = _EmployeeOtRate;
				EmployeeDtRate = _EmployeeDtRate;
				EmployeeMfgRegRate = _EmployeeMfgRegRate;
				EmployeeMfgOtRate = _EmployeeMfgOtRate;
				EmployeeMfgDtRate = _EmployeeMfgDtRate;
			}
			
			return (EmployeeRowPointer, EmployeePayFreq, EmployeeSalary, EmployeeEmpType, EmployeeRegRate, EmployeeOtRate, EmployeeDtRate, EmployeeMfgRegRate, EmployeeMfgOtRate, EmployeeMfgDtRate);
		}
		
		public ICollectionLoadResponse Employee1Select(string PEmpNum)
		{
			var employee1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"pay_freq","employee.pay_freq"},
					{"salary","employee.salary"},
					{"reg_rate","employee.reg_rate"},
					{"ot_rate","employee.ot_rate"},
					{"dt_rate","employee.dt_rate"},
					{"mfg_reg_rate","employee.mfg_reg_rate"},
					{"mfg_ot_rate","employee.mfg_ot_rate"},
					{"mfg_dt_rate","employee.mfg_dt_rate"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"employee",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("employee.emp_num = {0}",PEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(employee1LoadRequest);
		}
		
		public void Employee1Update(string EmployeePayFreq, decimal? EmployeeSalary, decimal? EmployeeRegRate, decimal? EmployeeOtRate, decimal? EmployeeDtRate, decimal? EmployeeMfgRegRate, decimal? EmployeeMfgOtRate, decimal? EmployeeMfgDtRate, ICollectionLoadResponse employee1LoadResponse)
		{
			foreach(var employee1Item in employee1LoadResponse.Items){
				employee1Item.SetValue<string>("pay_freq", EmployeePayFreq);
				employee1Item.SetValue<decimal?>("salary", EmployeeSalary);
				employee1Item.SetValue<decimal?>("reg_rate", EmployeeRegRate);
				employee1Item.SetValue<decimal?>("ot_rate", EmployeeOtRate);
				employee1Item.SetValue<decimal?>("dt_rate", EmployeeDtRate);
				employee1Item.SetValue<decimal?>("mfg_reg_rate", EmployeeMfgRegRate);
				employee1Item.SetValue<decimal?>("mfg_ot_rate", EmployeeMfgOtRate);
				employee1Item.SetValue<decimal?>("mfg_dt_rate", EmployeeMfgDtRate);
			};
			
			var employee1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "employee",
				items: employee1LoadResponse.Items);
			
			this.appDB.Update(employee1RequestUpdate);
		}
		
		public ICollectionLoadResponse EmpinsSelect(string PEmpNum)
		{
			var empins_CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"empins.RowPointer","empins.RowPointer"},
					{"empins.code","empins.code"},
					{"empins.covg_cls","empins.covg_cls"},
					{"empins.cost","empins.cost"},
					{"empins.comp_cntr","empins.comp_cntr"},
					{"empins.emp_num","empins.emp_num"},
					{"empins.amount","empins.amount"},
					{"empins.empl_cost","empins.empl_cost"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"empins",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (UPDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("empins.emp_num = {0}",PEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			return this.appDB.Load(empins_CrsLoadRequestForCursor);
		}
		public (Guid? InsuranceRowPointer, string InsuranceInsType) InsuranceLoad(string EmpinsCode, Guid? InsuranceRowPointer, string InsuranceInsType)
		{
			RowPointerType _InsuranceRowPointer = DBNull.Value;
			InsuranceTypeType _InsuranceInsType = DBNull.Value;
			
			var insuranceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InsuranceRowPointer,"insurance.RowPointer"},
					{_InsuranceInsType,"insurance.ins_type"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"insurance",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("insurance.code = {0}",EmpinsCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var insuranceLoadResponse = this.appDB.Load(insuranceLoadRequest);
			if(insuranceLoadResponse.Items.Count > 0)
			{
				InsuranceRowPointer = _InsuranceRowPointer;
				InsuranceInsType = _InsuranceInsType;
			}
			
			return (InsuranceRowPointer, InsuranceInsType);
		}
		
		public (Guid? InsHcRowPointer, decimal? InsHcPrice, decimal? InsHcCompCont) Ins_HcLoad(string EmpinsCode, string EmpinsCovgCls, Guid? InsHcRowPointer, decimal? InsHcPrice, decimal? InsHcCompCont)
		{
			RowPointerType _InsHcRowPointer = DBNull.Value;
			PrAmountType _InsHcPrice = DBNull.Value;
			PrAmountType _InsHcCompCont = DBNull.Value;
			
			var ins_hcLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InsHcRowPointer,"ins_hc.RowPointer"},
					{_InsHcPrice,"ins_hc.price"},
					{_InsHcCompCont,"ins_hc.comp_cont"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"ins_hc",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ins_hc.code = {1} AND ins_hc.covg_cls = {0}",EmpinsCovgCls,EmpinsCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var ins_hcLoadResponse = this.appDB.Load(ins_hcLoadRequest);
			if(ins_hcLoadResponse.Items.Count > 0)
			{
				InsHcRowPointer = _InsHcRowPointer;
				InsHcPrice = _InsHcPrice;
				InsHcCompCont = _InsHcCompCont;
			}
			
			return (InsHcRowPointer, InsHcPrice, InsHcCompCont);
		}
		
		public ICollectionLoadResponse Empins1Select(Guid? EmpinsRowPointer)
		{
			var empins1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"cost","empins.cost"},
					{"comp_cntr","empins.comp_cntr"},
					{"empl_cost","empins.empl_cost"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"empins",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("empins.RowPointer = {0}",EmpinsRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(empins1LoadRequest);
		}
		
		public void Empins1Update(decimal? EmpinsCost, decimal? EmpinsCompCntr, decimal? EmpinsEmplCost, ICollectionLoadResponse empins1LoadResponse)
		{
			foreach(var empins1Item in empins1LoadResponse.Items){
				empins1Item.SetValue<decimal?>("cost", EmpinsCost);
				empins1Item.SetValue<decimal?>("comp_cntr", EmpinsCompCntr);
				empins1Item.SetValue<decimal?>("empl_cost", EmpinsEmplCost);
			};
			
			var empins1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "empins",
				items: empins1LoadResponse.Items);
			
			this.appDB.Update(empins1RequestUpdate);
		}
		
		public ICollectionLoadResponse NontableSelect(string PEmpNum, DateTime? PSalDate, decimal? PSalary, decimal? EmpSalaryAnnual, string PSalaryPeriod, decimal? EmpSalaryHrlyRate, decimal? EmpSalaryPctIncr, string PReasonCode, string PPayFreq)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "emp_num", PEmpNum},
					{ "sal_date", PSalDate},
					{ "jobdate", PSalDate},
					{ "salary", PSalary},
					{ "annual", EmpSalaryAnnual},
					{ "sal_period", PSalaryPeriod},
					{ "hrly_rate", EmpSalaryHrlyRate},
					{ "pct_incr", EmpSalaryPctIncr},
					{ "reason_code", PReasonCode},
					{ "pay_freq", PPayFreq},
			});
			
			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "emp_salary",
				items: nonTableLoadResponse.Items);
			
			this.appDB.Insert(nonTableInsertRequest);
		}
		
		public ICollectionLoadResponse Emp_Salary3Select(Guid? EmpSalaryRowPointer)
		{
			var emp_salary3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"salary","emp_salary.salary"},
					{"annual","emp_salary.annual"},
					{"hrly_rate","emp_salary.hrly_rate"},
					{"pct_incr","emp_salary.pct_incr"},
					{"reason_code","emp_salary.reason_code"},
					{"pay_freq","emp_salary.pay_freq"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"emp_salary",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("emp_salary.RowPointer = {0}",EmpSalaryRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(emp_salary3LoadRequest);
		}
		
		public void Emp_Salary3Update(decimal? PSalary, string PReasonCode, string PPayFreq, decimal? EmpSalaryHrlyRate, decimal? EmpSalaryAnnual, decimal? EmpSalaryPctIncr, ICollectionLoadResponse emp_salary3LoadResponse)
		{
			foreach(var emp_salary3Item in emp_salary3LoadResponse.Items){
				emp_salary3Item.SetValue<decimal?>("salary", PSalary);
				emp_salary3Item.SetValue<decimal?>("annual", EmpSalaryAnnual);
				emp_salary3Item.SetValue<decimal?>("hrly_rate", EmpSalaryHrlyRate);
				emp_salary3Item.SetValue<decimal?>("pct_incr", EmpSalaryPctIncr);
				emp_salary3Item.SetValue<string>("reason_code", PReasonCode);
				emp_salary3Item.SetValue<string>("pay_freq", PPayFreq);
			};
			
			var emp_salary3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "emp_salary",
				items: emp_salary3LoadResponse.Items);
			
			this.appDB.Update(emp_salary3RequestUpdate);
		}
		
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_SSalISp(
			string AltExtGenSp,
			string PEmpNum,
			DateTime? PSalDate,
			DateTime? PJobDate,
			decimal? PSalary,
			string PSalaryPeriod,
			string PReasonCode,
			string PPayFreq,
			string Infobar,
			int? PFlageCheckReasonCode = 0)
		{
			EmpNumType _PEmpNum = PEmpNum;
			DateType _PSalDate = PSalDate;
			DateType _PJobDate = PJobDate;
			PrAmountType _PSalary = PSalary;
			SalPeriodType _PSalaryPeriod = PSalaryPeriod;
			ReasonCodeType _PReasonCode = PReasonCode;
			PrPayFreqType _PPayFreq = PPayFreq;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PFlageCheckReasonCode = PFlageCheckReasonCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalDate", _PSalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobDate", _PJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalary", _PSalary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalaryPeriod", _PSalaryPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayFreq", _PPayFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFlageCheckReasonCode", _PFlageCheckReasonCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
		
	}
}
