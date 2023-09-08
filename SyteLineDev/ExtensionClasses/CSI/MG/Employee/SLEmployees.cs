//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmployees.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLEmployees")]
    public class SLEmployees : ExtensionClassBase
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GenerateEmploymentPeriodsSp(string EmpNum,
                                               DateTime? HireDate,
                                               byte? UseinAdjustedHireDateCalc,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGenerateEmploymentPeriodsExt = new GenerateEmploymentPeriodsFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iGenerateEmploymentPeriodsExt.GenerateEmploymentPeriodsSp(EmpNum,
                                                                                         HireDate,
                                                                                         UseinAdjustedHireDateCalc,
                                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }





        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrEndSp(string EmpNumStart,
                       string EmpNumEnd,
                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrEndExt = new PrEndFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPrEndExt.PrEndSp(EmpNumStart,
                                                 EmpNumEnd,
                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateEmployeeUsernameSp(string EmpNum,
                                              string Username,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateEmployeeUsernameExt = new ValidateEmployeeUsernameFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iValidateEmployeeUsernameExt.ValidateEmployeeUsernameSp(EmpNum,
                                                                                       Username,
                                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HRCalcRvwSp(string PEmpNum,
		                       DateTime? PAnniv,
		                       DateTime? PRvwDate,
		                       ref DateTime? PNewDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHRCalcRvwExt = new HRCalcRvwFactory().Create(appDb);
				
				int Severity = iHRCalcRvwExt.HRCalcRvwSp(PEmpNum,
				                                         PAnniv,
				                                         PRvwDate,
				                                         ref PNewDate);
				
				return Severity;
			}
		}













		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetExportEmpSp(string StartingDept,
		                                    string EndingDept,
		                                    string StartingEmpNum,
		                                    string EndingEmpNum,
		                                    [Optional, DefaultParameterValue((byte)0)] byte? IsExportChangedOnly,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetExportEmpExt = new CLM_GetExportEmpFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_GetExportEmpExt.CLM_GetExportEmpSp(StartingDept,
				                                                     EndingDept,
				                                                     StartingEmpNum,
				                                                     EndingEmpNum,
				                                                     IsExportChangedOnly,
				                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}













		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteExportEmpLogDataSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeleteExportEmpLogDataExt = new DeleteExportEmpLogDataFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeleteExportEmpLogDataExt.DeleteExportEmpLogDataSp(StartingDept,
				EndingDept,
				StartingEmpNum,
				EndingEmpNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EmployeesPostQuerySP(Guid? EmployeesRowPointer,
		ref decimal? Salary,
		ref decimal? RegRate,
		ref decimal? OtRate,
		ref decimal? DtRate,
		ref decimal? MfgRegRate,
		ref decimal? MfgOtRate,
		ref decimal? MfgDtRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEmployeesPostQueryExt = new EmployeesPostQueryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEmployeesPostQueryExt.EmployeesPostQuerySP(EmployeesRowPointer,
				Salary,
				RegRate,
				OtRate,
				DtRate,
				MfgRegRate,
				MfgOtRate,
				MfgDtRate);
				
				int Severity = result.ReturnCode.Value;
				Salary = result.Salary;
				RegRate = result.RegRate;
				OtRate = result.OtRate;
				DtRate = result.DtRate;
				MfgRegRate = result.MfgRegRate;
				MfgOtRate = result.MfgOtRate;
				MfgDtRate = result.MfgDtRate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EmpRetPlanEligibleSp(string PDeCode,
		string PEmpType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEmpRetPlanEligibleExt = new EmpRetPlanEligibleFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEmpRetPlanEligibleExt.EmpRetPlanEligibleSp(PDeCode,
				PEmpType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EmpSalaryCalcSp(string PayFreq,
		decimal? Salary,
		ref decimal? RegRate,
		ref decimal? OtRate,
		ref decimal? DtRate,
		ref decimal? MfgRegRate,
		ref decimal? MfgOtRate,
		ref decimal? MfgdtRate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEmpSalaryCalcExt = new EmpSalaryCalcFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEmpSalaryCalcExt.EmpSalaryCalcSp(PayFreq,
				Salary,
				RegRate,
				OtRate,
				DtRate,
				MfgRegRate,
				MfgOtRate,
				MfgdtRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RegRate = result.RegRate;
				OtRate = result.OtRate;
				DtRate = result.DtRate;
				MfgRegRate = result.MfgRegRate;
				MfgOtRate = result.MfgOtRate;
				MfgdtRate = result.MfgdtRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EmptyPayrollLogTableSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEmptyPayrollLogTableExt = new EmptyPayrollLogTableFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEmptyPayrollLogTableExt.EmptyPayrollLogTableSp();
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GenerateExportEmpMasterDataSp([Optional] string StartingDept,
		[Optional] string EndingDept,
		[Optional] string StartingEmpNum,
		[Optional] string EndingEmpNum,
		[Optional, DefaultParameterValue(0)] int? IsExportChangedOnly,
		[Optional, DefaultParameterValue(0)] int? UseEffectiveDateOverride,
		[Optional] DateTime? EffectiveDateOverride,
		[Optional] int? EffectiveDateOverrideOffSet,
		[Optional, DefaultParameterValue(0)] int? UseEndDateOverride,
		[Optional] DateTime? EndDateOverride,
		[Optional] int? EndDateOverrideOffSet,
		[Optional] decimal? UserId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateExportEmpMasterDataExt = new GenerateExportEmpMasterDataFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateExportEmpMasterDataExt.GenerateExportEmpMasterDataSp(StartingDept,
				EndingDept,
				StartingEmpNum,
				EndingEmpNum,
				IsExportChangedOnly,
				UseEffectiveDateOverride,
				EffectiveDateOverride,
				EffectiveDateOverrideOffSet,
				UseEndDateOverride,
				EndDateOverride,
				EndDateOverrideOffSet,
				UserId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetApplicantDataSp(string AppNum,
		ref string app_num,
		ref string lname,
		ref string fname,
		ref string mi,
		ref string sname,
		ref string addr_1,
		ref string addr_2,
		ref string addr_3,
		ref string addr_4,
		ref string city,
		ref string state,
		ref string zip,
		ref string phone,
		ref string marital_stat,
		ref string sex,
		ref DateTime? birth_date,
		ref string ssn,
		ref string ethnic_id,
		ref int? citizen,
		ref int? handicap,
		ref string nationality,
		ref string work_stat,
		ref string military,
		ref DateTime? HireDate,
		ref DateTime? ADate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetApplicantDataExt = new GetApplicantDataFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetApplicantDataExt.GetApplicantDataSp(AppNum,
				app_num,
				lname,
				fname,
				mi,
				sname,
				addr_1,
				addr_2,
				addr_3,
				addr_4,
				city,
				state,
				zip,
				phone,
				marital_stat,
				sex,
				birth_date,
				ssn,
				ethnic_id,
				citizen,
				handicap,
				nationality,
				work_stat,
				military,
				HireDate,
				ADate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				app_num = result.app_num;
				lname = result.lname;
				fname = result.fname;
				mi = result.mi;
				sname = result.sname;
				addr_1 = result.addr_1;
				addr_2 = result.addr_2;
				addr_3 = result.addr_3;
				addr_4 = result.addr_4;
				city = result.city;
				state = result.state;
				zip = result.zip;
				phone = result.phone;
				marital_stat = result.marital_stat;
				sex = result.sex;
				birth_date = result.birth_date;
				ssn = result.ssn;
				ethnic_id = result.ethnic_id;
				citizen = result.citizen;
				handicap = result.handicap;
				nationality = result.nationality;
				work_stat = result.work_stat;
				military = result.military;
				HireDate = result.HireDate;
				ADate = result.ADate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrvacDoProcessSp(string pBegEmpNum,
		string pEndEmpNum,
		[Optional, DefaultParameterValue("F")] string DateMethod,
		[Optional] DateTime? FixedDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iHrvacDoProcessExt = new HrvacDoProcessFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iHrvacDoProcessExt.HrvacDoProcessSp(pBegEmpNum,
				pEndEmpNum,
				DateMethod,
				FixedDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrYearEndSp([Optional] string StartingEmpNum,
		[Optional] string EndingEmpNum,
		[Optional, DefaultParameterValue("F")] string DateMethod,
		[Optional] DateTime? FixedDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iHrYearEndExt = new HrYearEndFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iHrYearEndExt.HrYearEndSp(StartingEmpNum,
				EndingEmpNum,
				DateMethod,
				FixedDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PredisplayEmployeesSp(ref int? PHourlyPerm,
		ref int? PSalaryPerm,
		ref int? PCheckSsnEnabled,
		[Optional, DefaultParameterValue(1)] ref int? Prenote)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPredisplayEmployeesExt = new PredisplayEmployeesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPredisplayEmployeesExt.PredisplayEmployeesSp(PHourlyPerm,
				PSalaryPerm,
				PCheckSsnEnabled,
				Prenote);
				
				int Severity = result.ReturnCode.Value;
				PHourlyPerm = result.PHourlyPerm;
				PSalaryPerm = result.PSalaryPerm;
				PCheckSsnEnabled = result.PCheckSsnEnabled;
				Prenote = result.Prenote;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProcessMgrAssignToSp([Optional] string JobId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProcessMgrAssignToExt = new ProcessMgrAssignToFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProcessMgrAssignToExt.ProcessMgrAssignToSp(JobId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ExEmployeeOutstandingLoansSp([Optional] string EmployeeStarting,
		[Optional] string EmployeeEnding,
		[Optional] DateTime? HireDateStarting,
		[Optional] DateTime? HireDateEnding,
		[Optional] DateTime? TermDateStarting,
		[Optional] DateTime? TermDateEnding,
		[Optional] int? HireDateStartingOffset,
		[Optional] int? HireDateEndingOffset,
		[Optional] int? TermDateStartingOffset,
		[Optional] int? TermDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ExEmployeeOutstandingLoansExt = new Rpt_ExEmployeeOutstandingLoansFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ExEmployeeOutstandingLoansExt.Rpt_ExEmployeeOutstandingLoansSp(EmployeeStarting,
				EmployeeEnding,
				HireDateStarting,
				HireDateEnding,
				TermDateStarting,
				TermDateEnding,
				HireDateStartingOffset,
				HireDateEndingOffset,
				TermDateStartingOffset,
				TermDateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_NumberofEmployeesbyDeptSp([Optional] string StartingDept,
		[Optional] string EndingDept,
		[Optional] string EmpStatus,
		[Optional] int? DisplayHeader,
		[Optional] Guid? BGSessionID,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_NumberofEmployeesbyDeptExt = new Rpt_NumberofEmployeesbyDeptFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_NumberofEmployeesbyDeptExt.Rpt_NumberofEmployeesbyDeptSp(StartingDept,
				EndingDept,
				EmpStatus,
				DisplayHeader,
				BGSessionID,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalariesbyDepartmentSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PDepartmentStarting,
		string PDepartmentEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEEOClassStarting,
		string PEEOClassEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalariesbyDepartmentExt = new Rpt_SalariesbyDepartmentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalariesbyDepartmentExt.Rpt_SalariesbyDepartmentSp(PEmployeeStarting,
				PEmployeeEnding,
				PDepartmentStarting,
				PDepartmentEnding,
				PHireDateStarting,
				PHireDateEnding,
				PEEOClassStarting,
				PEEOClassEnding,
				PEmploymentStatus,
				PEmployeeTypes,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalariesByEEOClassSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEEOClassStarting,
		string PEEOClassEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalariesByEEOClassExt = new Rpt_SalariesByEEOClassFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalariesByEEOClassExt.Rpt_SalariesByEEOClassSp(PEmployeeStarting,
				PEmployeeEnding,
				PEmpCategoryStarting,
				PEmpCategoryEnding,
				PHireDateStarting,
				PHireDateEnding,
				PEEOClassStarting,
				PEEOClassEnding,
				PEmploymentStatus,
				PEmployeeTypes,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalariesByGenderSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalariesByGenderExt = new Rpt_SalariesByGenderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalariesByGenderExt.Rpt_SalariesByGenderSp(PEmployeeStarting,
				PEmployeeEnding,
				PEmpCategoryStarting,
				PEmpCategoryEnding,
				PHireDateStarting,
				PHireDateEnding,
				PEmploymentStatus,
				PEmployeeTypes,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalariesByPositionClassSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		string PClassificationStarting,
		string PClassificationEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalariesByPositionClassExt = new Rpt_SalariesByPositionClassFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalariesByPositionClassExt.Rpt_SalariesByPositionClassSp(PEmployeeStarting,
				PEmployeeEnding,
				PEmpCategoryStarting,
				PEmpCategoryEnding,
				PClassificationStarting,
				PClassificationEnding,
				PHireDateStarting,
				PHireDateEnding,
				PEmploymentStatus,
				PEmployeeTypes,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
