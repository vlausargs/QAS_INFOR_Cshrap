//PROJECT NAME: Employee
//CLASS NAME: SSalI.cs

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
using CSI.Material;

namespace CSI.Employee
{
	public class SSalI : ISSalI
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IHighDecimal iHighDecimal;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IStringUtil stringUtil;
		readonly IInsCalc iInsCalc;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ISSalICRUD iSSalICRUD;
		
		public SSalI(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IHighDecimal iHighDecimal,
			IDateTimeUtil dateTimeUtil,
			IGetSiteDate iGetSiteDate,
			IStringUtil stringUtil,
			IInsCalc iInsCalc,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ISSalICRUD iSSalICRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iHighDecimal = iHighDecimal;
			this.dateTimeUtil = dateTimeUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.stringUtil = stringUtil;
			this.iInsCalc = iInsCalc;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iSSalICRUD = iSSalICRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		SSalISp (
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
			
			PrAmountType _PSalary = PSalary;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			Guid? PrparmsRowPointer = null;
			decimal? PrparmsHrsWeek = null;
			decimal? PrparmsHrsDay = null;
			decimal? PrparmsHrsBiWeek = null;
			decimal? PrparmsHrsSemiMo = null;
			decimal? PrparmsHrsMo = null;
			decimal? PrparmsHrsQuart = null;
			decimal? PrparmsOtFactor = null;
			decimal? PrparmsDtFactor = null;
			int? PrparmsYrDay = null;
			int? PrparmsYrWeek = null;
			int? PrparmsYrBiWeek = null;
			int? PrparmsYrSemiMo = null;
			int? PrparmsYrMo = null;
			int? PrparmsYrQuart = null;
			Guid? SalChgRowPointer = null;
			Guid? EmpSalaryRowPointer = null;
			decimal? EmpSalarySalary = null;
			decimal? TEmpSalaryHrlyRate = null;
			decimal? EmpSalaryHrlyRate = null;
			decimal? EmpSalaryAnnual = null;
			decimal? EmpSalaryPctIncr = null;
			decimal? TmaxSalaryPctIncr = null;
			decimal? TEmpSalaryPctIncr = null;
			string EmpSalaryPayFreq = null;
			Guid? PrevSalRowPointer = null;
			decimal? PrevSalAnnual = null;
			Guid? PostSalRowPointer = null;
			decimal? PostSalAnnual = null;
			decimal? PostSalPctIncr = null;
			decimal? TmaxPostsalPctIncr = null;
			decimal? TPostSalPctIncr = null;
			Guid? EmployeeRowPointer = null;
			string EmployeePayFreq = null;
			decimal? EmployeeSalary = null;
			string EmployeeEmpType = null;
			decimal? EmployeeRegRate = null;
			decimal? EmployeeOtRate = null;
			decimal? EmployeeDtRate = null;
			decimal? EmployeeMfgRegRate = null;
			decimal? EmployeeMfgOtRate = null;
			decimal? EmployeeMfgDtRate = null;
			Guid? EmpinsRowPointer = null;
			string EmpinsCode = null;
			string EmpinsCovgCls = null;
			decimal? EmpinsCost = null;
			decimal? EmpinsCompCntr = null;
			string EmpinsEmpNum = null;
			decimal? EmpinsAmount = null;
			decimal? EmpinsEmplCost = null;
			Guid? InsuranceRowPointer = null;
			string InsuranceInsType = null;
			Guid? InsHcRowPointer = null;
			decimal? InsHcPrice = null;
			decimal? InsHcCompCont = null;
			decimal? TMaxEmpHrlyRate = null;
			ICollectionLoadResponse empins_CrsLoadResponseForCursor = null;
			int empins_Crs_CursorFetch_Status = -1;
			int empins_Crs_CursorCounter = -1;
			if (this.iSSalICRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iSSalICRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("SSalISp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iSSalICRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iSSalICRUD.Tv_ALTGENForExists())
				{
					ALTGEN_SpName = this.iSSalICRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iSSalICRUD.AltExtGen_SSalISp (ALTGEN_SpName,
						PEmpNum,
						PSalDate,
						PJobDate,
						PSalary,
						PSalaryPeriod,
						PReasonCode,
						PPayFreq,
						Infobar,
						PFlageCheckReasonCode);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iSSalICRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iSSalICRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSalISp") != null)
			{
				var EXTGEN = this.iSSalICRUD.AltExtGen_SSalISp("dbo.EXTGEN_SSalISp",
					PEmpNum,
					PSalDate,
					PJobDate,
					PSalary,
					PSalaryPeriod,
					PReasonCode,
					PPayFreq,
					Infobar,
					PFlageCheckReasonCode);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			if (PFlageCheckReasonCode== null)
			{
				PFlageCheckReasonCode = 0;
				
			}
			Severity = 0;
			TMaxEmpHrlyRate = convertToUtil.ToDecimal(this.iHighDecimal.HighDecimalFn("HourlyRateType"));
			TmaxSalaryPctIncr = convertToUtil.ToDecimal(this.iHighDecimal.HighDecimalFn("SalaryChangePercentType"));
			TmaxPostsalPctIncr = convertToUtil.ToDecimal(this.iHighDecimal.HighDecimalFn("SalaryChangePercentType"));
			SalChgRowPointer = null;
			SalChgRowPointer = this.iSSalICRUD.Sal_ChgLoad(PReasonCode, SalChgRowPointer);
			if (SalChgRowPointer== null && sQLUtil.SQLEqual(PFlageCheckReasonCode, 0) == true)
			{
				Infobar = null;
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist1",
					Parm1: "@sal_chg",
					Parm2: "@sal_chg.reason_code",
					Parm3: PReasonCode);
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;
				
				#endregion ExecuteMethodCall
				
				return (Severity, Infobar);
			}
			PrparmsRowPointer = null;
			PrparmsHrsWeek = 0;
			PrparmsHrsDay = 0;
			PrparmsHrsBiWeek = 0;
			PrparmsHrsSemiMo = 0;
			PrparmsHrsMo = 0;
			PrparmsHrsQuart = 0;
			PrparmsOtFactor = 0;
			PrparmsDtFactor = 0;
			PrparmsYrDay = 0;
			PrparmsYrWeek = 0;
			PrparmsYrBiWeek = 0;
			PrparmsYrSemiMo = 0;
			PrparmsYrMo = 0;
			PrparmsYrQuart = 0;
			(PrparmsRowPointer,
				 PrparmsHrsWeek,
				 PrparmsHrsDay,
				 PrparmsHrsBiWeek,
				 PrparmsHrsSemiMo,
				 PrparmsHrsMo,
				 PrparmsHrsQuart,
				 PrparmsOtFactor,
				 PrparmsDtFactor,
				 PrparmsYrDay,
				 PrparmsYrWeek,
				 PrparmsYrBiWeek,
				 PrparmsYrSemiMo,
				 PrparmsYrMo,
				 PrparmsYrQuart) = this.iSSalICRUD.PrparmsLoad(PrparmsRowPointer,
				 PrparmsHrsWeek,
				 PrparmsHrsDay,
				 PrparmsHrsBiWeek,
				 PrparmsHrsSemiMo,
				 PrparmsHrsMo,
				 PrparmsHrsQuart,
				 PrparmsOtFactor,
				 PrparmsDtFactor,
				 PrparmsYrDay,
				 PrparmsYrWeek,
				 PrparmsYrBiWeek,
				 PrparmsYrSemiMo,
				 PrparmsYrMo,
				 PrparmsYrQuart);
			PEmpNum = this.iExpandKyByType.ExpandKyByTypeFn(
				"EmpNumType",
				PEmpNum);
			PSalary = (decimal?)(stringUtil.IsNull<decimal?>(
				PSalary,
				0));
			(EmpSalaryRowPointer, EmpSalarySalary, EmpSalaryPayFreq) = this.iSSalICRUD.Emp_SalaryLoad(PEmpNum, PSalDate, EmpSalaryRowPointer, EmpSalarySalary, EmpSalaryPayFreq);
			if (EmpSalarySalary== null)
			{
				EmpSalarySalary = 0;
				
			}
			if (EmpSalaryPayFreq== null)
			{
				EmpSalaryPayFreq = "";
				
			}
			if (sQLUtil.SQLNotEqual(PSalary, EmpSalarySalary) == true || EmpSalaryRowPointer== null)
			{
				EmpSalaryAnnual = convertToUtil.ToDecimal(PSalary * ((sQLUtil.SQLEqual(PSalaryPeriod, "H") == true ? (PrparmsHrsWeek * 52M) :
				sQLUtil.SQLEqual(PSalaryPeriod, "W") == true ? 52 :
				sQLUtil.SQLEqual(PSalaryPeriod, "B") == true ? 26 :
				sQLUtil.SQLEqual(PSalaryPeriod, "S") == true ? 24 :
				sQLUtil.SQLEqual(PSalaryPeriod, "M") == true ? 12 : 1)));
				TEmpSalaryHrlyRate = (decimal?)(PSalary / ((sQLUtil.SQLEqual(PSalaryPeriod, "H") == true ? 1 :
				sQLUtil.SQLEqual(PSalaryPeriod, "W") == true ? PrparmsHrsWeek :
				sQLUtil.SQLEqual(PSalaryPeriod, "B") == true ? PrparmsHrsBiWeek :
				sQLUtil.SQLEqual(PSalaryPeriod, "S") == true ? PrparmsHrsSemiMo :
				sQLUtil.SQLEqual(PSalaryPeriod, "M") == true ? PrparmsHrsMo : (4M * PrparmsHrsQuart))));
				if (sQLUtil.SQLGreaterThan(TEmpSalaryHrlyRate, TMaxEmpHrlyRate) == true)
				{
					EmpSalaryHrlyRate = TMaxEmpHrlyRate;
					
				}
				else
				{
					EmpSalaryHrlyRate = TEmpSalaryHrlyRate;
					
				}
				PrevSalRowPointer = null;
				PrevSalAnnual = null;
				(PrevSalRowPointer, PrevSalAnnual) = this.iSSalICRUD.Emp_Salary1Load(PEmpNum, PSalDate, PrevSalRowPointer, PrevSalAnnual);
				if (PrevSalRowPointer!= null)
				{
					if (PrevSalAnnual== null)
					{
						PrevSalAnnual = 0;
						
					}
					if (sQLUtil.SQLEqual(PrevSalAnnual, 0) == true)
					{
						if (sQLUtil.SQLEqual(EmpSalaryAnnual, 0) == true)
						{
							EmpSalaryPctIncr = 0;
							
						}
						else
						{
							EmpSalaryPctIncr = 100M;
							
						}
						
					}
					else
					{
						TEmpSalaryPctIncr = (decimal?)(((EmpSalaryAnnual - PrevSalAnnual) / PrevSalAnnual) * 100M);
						
					}
					
				}
				
			}
			if (sQLUtil.SQLGreaterThan(TEmpSalaryPctIncr, TmaxSalaryPctIncr) == true)
			{
				EmpSalaryPctIncr = TmaxSalaryPctIncr;
				
			}
			else
			{
				EmpSalaryPctIncr = TEmpSalaryPctIncr;
				
			}
			PostSalRowPointer = null;
			PostSalPctIncr = null;
			PostSalAnnual = null;
			(PostSalRowPointer, PostSalPctIncr, PostSalAnnual) = this.iSSalICRUD.Emp_Salary2Load(PEmpNum, PSalDate, PostSalRowPointer, PostSalAnnual, PostSalPctIncr);
			if (PostSalRowPointer!= null && sQLUtil.SQLNotEqual(EmpSalarySalary, PSalary) == true)
			{
				if (PostSalAnnual== null)
				{
					PostSalAnnual = 0;
					
				}
				if (sQLUtil.SQLEqual(EmpSalaryAnnual, 0) == true)
				{
					if (sQLUtil.SQLEqual(PostSalAnnual, 0) == true)
					{
						PostSalPctIncr = 0;
						
					}
					else
					{
						PostSalPctIncr = 100M;
						
					}
					
				}
				else
				{
					TPostSalPctIncr = (decimal?)(((PostSalAnnual - EmpSalaryAnnual) / EmpSalaryAnnual) * 100M);
					if (sQLUtil.SQLGreaterThan(TPostSalPctIncr, TmaxPostsalPctIncr) == true)
					{
						PostSalPctIncr = TmaxPostsalPctIncr;
						
					}
					else
					{
						PostSalPctIncr = TPostSalPctIncr;
						
					}
					
				}
				
			}
			else
			{
				if (PostSalRowPointer== null && sQLUtil.SQLGreaterThanOrEqual(dateTimeUtil.DateDiff("Day",PSalDate,this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))), 0) == true && (sQLUtil.SQLNotEqual(EmpSalaryPayFreq, PPayFreq) == true || sQLUtil.SQLNotEqual(EmpSalarySalary, PSalary) == true || EmpSalaryRowPointer== null))
				{
					EmployeeRowPointer = null;
					EmployeePayFreq = null;
					EmployeeSalary = 0;
					EmployeeEmpType = null;
					EmployeeRegRate = 0;
					EmployeeOtRate = 0;
					EmployeeDtRate = 0;
					EmployeeMfgRegRate = 0;
					EmployeeMfgOtRate = 0;
					EmployeeMfgDtRate = 0;
					(EmployeeRowPointer,
						 EmployeePayFreq,
						 EmployeeSalary,
						 EmployeeEmpType,
						 EmployeeRegRate,
						 EmployeeOtRate,
						 EmployeeDtRate,
						 EmployeeMfgRegRate,
						 EmployeeMfgOtRate,
						 EmployeeMfgDtRate) = this.iSSalICRUD.EmployeeLoad(PEmpNum,
						 EmployeeRowPointer,
						 EmployeePayFreq,
						 EmployeeSalary,
						 EmployeeEmpType,
						 EmployeeRegRate,
						 EmployeeOtRate,
						 EmployeeDtRate,
						 EmployeeMfgRegRate,
						 EmployeeMfgOtRate,
						 EmployeeMfgDtRate);
					EmployeePayFreq = PPayFreq;
					if (sQLUtil.SQLEqual(EmployeeEmpType, "S") == true)
					{
						if (sQLUtil.SQLEqual(EmpSalaryPayFreq, PPayFreq) == true || sQLUtil.SQLEqual(stringUtil.IsNull(
								EmpSalaryPayFreq,
								""), "") == true)
						{
							EmployeeSalary = (decimal?)(EmpSalaryAnnual / (decimal?)(((sQLUtil.SQLEqual(PPayFreq, "D") == true ? PrparmsYrDay :
							sQLUtil.SQLEqual(PPayFreq, "W") == true ? PrparmsYrWeek :
							sQLUtil.SQLEqual(PPayFreq, "B") == true ? PrparmsYrBiWeek :
							sQLUtil.SQLEqual(PPayFreq, "S") == true ? PrparmsYrSemiMo :
							sQLUtil.SQLEqual(PPayFreq, "M") == true ? PrparmsYrMo : PrparmsYrQuart))));
							
						}
						else
						{
							EmployeeSalary = convertToUtil.ToDecimal((PSalary / ((sQLUtil.SQLEqual(PSalaryPeriod, "H") == true ? 1 :
							sQLUtil.SQLEqual(PSalaryPeriod, "W") == true ? PrparmsHrsWeek :
							sQLUtil.SQLEqual(PSalaryPeriod, "B") == true ? PrparmsHrsBiWeek :
							sQLUtil.SQLEqual(PSalaryPeriod, "S") == true ? PrparmsHrsSemiMo :
							sQLUtil.SQLEqual(PSalaryPeriod, "M") == true ? PrparmsHrsMo : (4M * PrparmsHrsQuart)))) * ((sQLUtil.SQLEqual(EmployeePayFreq, "D") == true ? PrparmsHrsDay :
							sQLUtil.SQLEqual(EmployeePayFreq, "W") == true ? PrparmsHrsWeek :
							sQLUtil.SQLEqual(EmployeePayFreq, "B") == true ? PrparmsHrsBiWeek :
							sQLUtil.SQLEqual(EmployeePayFreq, "S") == true ? PrparmsHrsSemiMo :
							sQLUtil.SQLEqual(EmployeePayFreq, "M") == true ? PrparmsHrsMo : PrparmsHrsQuart)));
							
						}
						
					}
					EmployeeRegRate = EmpSalaryHrlyRate;
					EmployeeOtRate = (decimal?)(EmpSalaryHrlyRate * PrparmsOtFactor);
					EmployeeDtRate = (decimal?)(EmpSalaryHrlyRate * PrparmsDtFactor);
					if (sQLUtil.SQLNotEqual(EmployeeEmpType, "H") == true)
					{
						EmployeeMfgRegRate = EmpSalaryHrlyRate;
						EmployeeMfgOtRate = EmployeeOtRate;
						EmployeeMfgDtRate = EmployeeDtRate;
						
					}
					var employee1LoadResponse = this.iSSalICRUD.Employee1Select(PEmpNum);
					this.iSSalICRUD.Employee1Update(EmployeePayFreq, EmployeeSalary, EmployeeRegRate, EmployeeOtRate, EmployeeDtRate, EmployeeMfgRegRate, EmployeeMfgOtRate, EmployeeMfgDtRate, employee1LoadResponse);
					
				}
				
			}
			if (sQLUtil.SQLNotEqual(EmpSalaryPayFreq, PPayFreq) == true)
			{
				EmpSalaryPayFreq = PPayFreq;
				#region Cursor Statement
				empins_CrsLoadResponseForCursor = this.iSSalICRUD.EmpinsSelect(PEmpNum);
				#endregion Cursor Statement
				empins_Crs_CursorFetch_Status = empins_CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				empins_Crs_CursorCounter = -1;
				
				while (sQLUtil.SQLEqual(Severity, 0) == true)
				{
					empins_Crs_CursorCounter++;
					if(empins_CrsLoadResponseForCursor.Items.Count > empins_Crs_CursorCounter)
					{
						EmpinsRowPointer = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<Guid?>(0);
						EmpinsCode = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<string>(1);
						EmpinsCovgCls = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<string>(2);
						EmpinsCost = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<decimal?>(3);
						EmpinsCompCntr = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<decimal?>(4);
						EmpinsEmpNum = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<string>(5);
						EmpinsAmount = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<decimal?>(6);
						EmpinsEmplCost = empins_CrsLoadResponseForCursor.Items[empins_Crs_CursorCounter].GetValue<decimal?>(7);
					}
					empins_Crs_CursorFetch_Status = (empins_Crs_CursorCounter == empins_CrsLoadResponseForCursor.Items.Count ? -1 : 0);
					
					if (sQLUtil.SQLEqual(empins_Crs_CursorFetch_Status, -1) == true)
					{
						
						break;
						
					}
					InsuranceRowPointer = null;
					InsuranceInsType = null;
					(InsuranceRowPointer, InsuranceInsType) = this.iSSalICRUD.InsuranceLoad(EmpinsCode, InsuranceRowPointer, InsuranceInsType);
					if (sQLUtil.SQLEqual(InsuranceInsType, "H") == true)
					{
						InsHcRowPointer = null;
						InsHcPrice = 0;
						InsHcCompCont = 0;
						(InsHcRowPointer, InsHcPrice, InsHcCompCont) = this.iSSalICRUD.Ins_HcLoad(EmpinsCode, EmpinsCovgCls, InsHcRowPointer, InsHcPrice, InsHcCompCont);
						EmpinsCost = (decimal?)(InsHcPrice / (decimal?)(((sQLUtil.SQLEqual(PPayFreq, "D") == true ? PrparmsYrDay :
						sQLUtil.SQLEqual(PPayFreq, "W") == true ? PrparmsYrWeek :
						sQLUtil.SQLEqual(PPayFreq, "B") == true ? PrparmsYrBiWeek :
						sQLUtil.SQLEqual(PPayFreq, "S") == true ? PrparmsYrSemiMo :
						sQLUtil.SQLEqual(PPayFreq, "M") == true ? PrparmsYrMo : PrparmsYrQuart))));
						EmpinsCompCntr = (decimal?)(InsHcCompCont / (decimal?)(((sQLUtil.SQLEqual(PPayFreq, "D") == true ? PrparmsYrDay :
						sQLUtil.SQLEqual(PPayFreq, "W") == true ? PrparmsYrWeek :
						sQLUtil.SQLEqual(PPayFreq, "B") == true ? PrparmsYrBiWeek :
						sQLUtil.SQLEqual(PPayFreq, "S") == true ? PrparmsYrSemiMo :
						sQLUtil.SQLEqual(PPayFreq, "M") == true ? PrparmsYrMo : PrparmsYrQuart))));
						
					}
					else
					{
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: InsCalcSp
						var InsCalc = this.iInsCalc.InsCalcSp(
							EmpinsEmpNum: EmpinsEmpNum,
							EmpinsAmount: EmpinsAmount,
							EmpinsCost: EmpinsCost,
							EmpinsCompCntr: EmpinsCompCntr,
							EmpinsCode: EmpinsCode,
							Infobar: Infobar);
						EmpinsCost = InsCalc.EmpinsCost;
						EmpinsCompCntr = InsCalc.EmpinsCompCntr;
						Infobar = InsCalc.Infobar;
						
						#endregion ExecuteMethodCall
						
					}
					EmpinsEmplCost = (decimal?)(EmpinsCost - EmpinsCompCntr);
					var empins1LoadResponse = this.iSSalICRUD.Empins1Select(EmpinsRowPointer);
					this.iSSalICRUD.Empins1Update(EmpinsCost, EmpinsCompCntr, EmpinsEmplCost, empins1LoadResponse);
					
				}
				//Deallocate Cursor empins_Crs
				
			}
			if (EmpSalaryRowPointer== null)
			{
				var nonTableLoadResponse = this.iSSalICRUD.NontableSelect(PEmpNum, PSalDate, PSalary, EmpSalaryAnnual, PSalaryPeriod, EmpSalaryHrlyRate, EmpSalaryPctIncr, PReasonCode, PPayFreq);
				this.iSSalICRUD.NontableInsert(nonTableLoadResponse);
				
			}
			else
			{
				var emp_salary3LoadResponse = this.iSSalICRUD.Emp_Salary3Select(EmpSalaryRowPointer);
				this.iSSalICRUD.Emp_Salary3Update(PSalary, PReasonCode, PPayFreq, EmpSalaryHrlyRate, EmpSalaryAnnual, EmpSalaryPctIncr, emp_salary3LoadResponse);
				
			}
			return (Severity, Infobar);
			
		}
		
	}
}
