//PROJECT NAME: AdminExt
//CLASS NAME: SLExtPRInterfaces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLExtPRInterfaces")]
    public class SLExtPRInterfaces : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetAdpParmInfoSp(decimal? UserId,
                                    ref string OutFile,
                                    ref string OutProg,
                                    ref string CompanyCode,
                                    ref string InPath,
                                    ref string InFile,
                                    ref string LogDir,
                                    ref string InterfaceVersion,
                                    ref byte? AppendSiteOntoInFile,
                                    ref string ErrorLogFile,
                                    ref string BalanceAcct,
                                    ref string BalanceAcctUnit1,
                                    ref string BalanceAcctUnit2,
                                    ref string BalanceAcctUnit3,
                                    ref string BalanceAcctUnit4,
                                    ref string InterfaceVersionDesc,
                                    ref string BalanceAcctDesc,
                                    ref string Site,
                                    ref byte? CurPer)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetAdpParmInfoExt = new GetAdpParmInfoFactory().Create(appDb);

                OSLocationType oOutFile = OutFile;
                OSLocationType oOutProg = OutProg;
                AdpCompanyCodeType oCompanyCode = CompanyCode;
                OSLocationType oInPath = InPath;
                OSLocationType oInFile = InFile;
                OSLocationType oLogDir = LogDir;
                AdpVersionType oInterfaceVersion = InterfaceVersion;
                ListYesNoType oAppendSiteOntoInFile = AppendSiteOntoInFile;
                OSLocationType oErrorLogFile = ErrorLogFile;
                AcctType oBalanceAcct = BalanceAcct;
                UnitCode1Type oBalanceAcctUnit1 = BalanceAcctUnit1;
                UnitCode2Type oBalanceAcctUnit2 = BalanceAcctUnit2;
                UnitCode3Type oBalanceAcctUnit3 = BalanceAcctUnit3;
                UnitCode4Type oBalanceAcctUnit4 = BalanceAcctUnit4;
                DescriptionType oInterfaceVersionDesc = InterfaceVersionDesc;
                DescriptionType oBalanceAcctDesc = BalanceAcctDesc;
                SiteType oSite = Site;
                FinPeriodType oCurPer = CurPer;

                int Severity = iGetAdpParmInfoExt.GetAdpParmInfoSp(UserId,
                                                                   ref oOutFile,
                                                                   ref oOutProg,
                                                                   ref oCompanyCode,
                                                                   ref oInPath,
                                                                   ref oInFile,
                                                                   ref oLogDir,
                                                                   ref oInterfaceVersion,
                                                                   ref oAppendSiteOntoInFile,
                                                                   ref oErrorLogFile,
                                                                   ref oBalanceAcct,
                                                                   ref oBalanceAcctUnit1,
                                                                   ref oBalanceAcctUnit2,
                                                                   ref oBalanceAcctUnit3,
                                                                   ref oBalanceAcctUnit4,
                                                                   ref oInterfaceVersionDesc,
                                                                   ref oBalanceAcctDesc,
                                                                   ref oSite,
                                                                   ref oCurPer);

                OutFile = oOutFile;
                OutProg = oOutProg;
                CompanyCode = oCompanyCode;
                InPath = oInPath;
                InFile = oInFile;
                LogDir = oLogDir;
                InterfaceVersion = oInterfaceVersion;
                AppendSiteOntoInFile = oAppendSiteOntoInFile;
                ErrorLogFile = oErrorLogFile;
                BalanceAcct = oBalanceAcct;
                BalanceAcctUnit1 = oBalanceAcctUnit1;
                BalanceAcctUnit2 = oBalanceAcctUnit2;
                BalanceAcctUnit3 = oBalanceAcctUnit3;
                BalanceAcctUnit4 = oBalanceAcctUnit4;
                InterfaceVersionDesc = oInterfaceVersionDesc;
                BalanceAcctDesc = oBalanceAcctDesc;
                Site = oSite;
                CurPer = oCurPer;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JourpostISp(string id,
		[Optional, DefaultParameterValue(0)] decimal? trans_num,
		DateTime? trans_date,
		string acct,
		[Optional] string acct_unit1,
		[Optional] string acct_unit2,
		[Optional] string acct_unit3,
		[Optional] string acct_unit4,
		decimal? amount,
		[Optional] string Ref,
		[Optional] string vend_num,
		[Optional] string inv_num,
		[Optional, DefaultParameterValue("0")] string voucher,
		[Optional, DefaultParameterValue(0)] int? check_num,
		[Optional] DateTime? check_date,
		[Optional] string from_site,
		[Optional] string ref_type,
		[Optional] string ref_num,
		[Optional, DefaultParameterValue((short)0)] short? ref_line_suf,
		[Optional, DefaultParameterValue((short)0)] short? ref_release,
		[Optional, DefaultParameterValue(0)] int? vouch_seq,
		[Optional] string bank_code,
		[Optional] string curr_code,
		decimal? for_amount,
		[Optional, DefaultParameterValue(1)] decimal? exch_rate,
		[Optional, DefaultParameterValue((byte)0)] byte? reverse,
		[Optional] string ControlPrefix,
		[Optional] string ControlSite,
		[Optional] short? ControlYear,
		[Optional] byte? ControlPeriod,
		[Optional] decimal? ControlNumber,
		[Optional] ref int? last_seq,
		ref string Infobar,
		[Optional] Guid? BufferJournal,
		[Optional] string DomCurrCode,
		[Optional] byte? DomCurrPlaces,
		[Optional] decimal? proj_trans_num,
		[Optional, DefaultParameterValue((byte)0)] byte? Cancellation,
		[Optional] string comp_level,
		[Optional] byte? compress,
		[Optional] byte? InvNumLength)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iJourpostExt = new JourpostFactory().Create(appDb);
				
				var result = iJourpostExt.JourpostSp(id,
				trans_num,
				trans_date,
				acct,
				acct_unit1,
				acct_unit2,
				acct_unit3,
				acct_unit4,
				amount,
                Ref,
				vend_num,
				inv_num,
				voucher,
				check_num,
				check_date,
				from_site,
				ref_type,
				ref_num,
				ref_line_suf,
				ref_release,
				vouch_seq,
				bank_code,
				curr_code,
				for_amount,
				exch_rate,
				reverse,
				ControlPrefix,
				ControlSite,
				ControlYear,
				ControlPeriod,
				ControlNumber,
				last_seq,
				Infobar,
				BufferJournal,
				DomCurrCode,
				DomCurrPlaces,
				proj_trans_num,
				Cancellation,
				comp_level,
				compress,
				InvNumLength);
				
				int Severity = result.ReturnCode.Value;
				last_seq = result.last_seq;
				Infobar = result.Infobar;
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateDeptSp(string Dept,
		string EmpNum,
		ref string DeptUnit,
		ref string DlAcct,
		ref string DlAcctUnit2,
		ref string DlAcctUnit3,
		ref string DlAcctUnit4,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateDeptExt = new ValidateDeptFactory().Create(appDb);
				
				var result = iValidateDeptExt.ValidateDeptSp(Dept,
				EmpNum,
				DeptUnit,
				DlAcct,
				DlAcctUnit2,
				DlAcctUnit3,
				DlAcctUnit4,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DeptUnit = result.DeptUnit;
				DlAcct = result.DlAcct;
				DlAcctUnit2 = result.DlAcctUnit2;
				DlAcctUnit3 = result.DlAcctUnit3;
				DlAcctUnit4 = result.DlAcctUnit4;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkAcctSp(string acct,
		DateTime? date,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iChkAcctExt = new ChkAcctFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iChkAcctExt.ChkAcctSp(acct,
				date,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkUnitSp(string acct,
		[Optional] string p_unit1,
		[Optional] string p_unit2,
		[Optional] string p_unit3,
		[Optional] string p_unit4,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iChkUnitExt = new ChkUnitFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iChkUnitExt.ChkUnitSp(acct,
				p_unit1,
				p_unit2,
				p_unit3,
				p_unit4,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAdpParmSp(ref string InPath,
		ref string CompanyCode,
		ref string InFile,
		ref int? Prenote,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetAdpParmExt = new GetAdpParmFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetAdpParmExt.GetAdpParmSp(InPath,
				CompanyCode,
				InFile,
				Prenote,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				InPath = result.InPath;
				CompanyCode = result.CompanyCode;
				InFile = result.InFile;
				Prenote = result.Prenote;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextControlNumberSp([Optional] string SubKey,
		[Optional] string JournalId,
		[Optional, DefaultParameterValue(0)] int? UpdatePeriodsSeqOnly,
		[Optional] ref string ControlPrefix,
		[Optional] ref string ControlSite,
		[Optional] DateTime? TransDate,
		[Optional] ref int? ControlYear,
		[Optional] ref int? ControlPeriod,
		[Optional] string SequenceBy,
		ref decimal? ControlNumber,
		ref string Infobar,
		[Optional] ref decimal? OldControlNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextControlNumberExt = new NextControlNumberFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextControlNumberExt.NextControlNumberSp(SubKey,
				JournalId,
				UpdatePeriodsSeqOnly,
				ControlPrefix,
				ControlSite,
				TransDate,
				ControlYear,
				ControlPeriod,
				SequenceBy,
				ControlNumber,
				Infobar,
				OldControlNumber);
				
				int Severity = result.ReturnCode.Value;
				ControlPrefix = result.ControlPrefix;
				ControlSite = result.ControlSite;
				ControlYear = result.ControlYear;
				ControlPeriod = result.ControlPeriod;
				ControlNumber = result.ControlNumber;
				Infobar = result.Infobar;
				OldControlNumber = result.OldControlNumber;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PerGetSp(DateTime? Date,
		[Optional] ref int? CurrentPeriod,
		[Optional] ref Guid? PeriodsRowPointer,
		ref string Infobar,
		[Optional] string Site,
		[Optional] ref int? PeriodsFiscalYear,
		[Optional] ref string CurPeriodStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPerGetExt = new PerGetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPerGetExt.PerGetSp(Date,
				CurrentPeriod,
				PeriodsRowPointer,
				Infobar,
				Site,
				PeriodsFiscalYear,
				CurPeriodStatus);
				
				int Severity = result.ReturnCode.Value;
				CurrentPeriod = result.CurrentPeriod;
				PeriodsRowPointer = result.PeriodsRowPointer;
				Infobar = result.Infobar;
				PeriodsFiscalYear = result.PeriodsFiscalYear;
				CurPeriodStatus = result.CurPeriodStatus;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcessEmployeeSp(string EmpNum,
		string Dept,
		string DlAcct,
		string DeptAcctUnit1,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		int? UpdateDept,
		string Name,
		string LastName,
		string FirstName,
		string Mi,
		string Addr1,
		string Addr2,
		string City,
		string State,
		string Zip,
		string Ssn,
		string Phone,
		string PayFreq,
		decimal? Rate,
		string Marital,
		decimal? YtdGrs,
		decimal? YtdFwt,
		decimal? YtdFica,
		decimal? YtdMed,
		decimal? YtdSwt,
		decimal? YtdOst,
		decimal? YtdCwt,
		int? Prenote,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProcessEmployeeExt = new ProcessEmployeeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProcessEmployeeExt.ProcessEmployeeSp(EmpNum,
				Dept,
				DlAcct,
				DeptAcctUnit1,
				DlAcctUnit2,
				DlAcctUnit3,
				DlAcctUnit4,
				UpdateDept,
				Name,
				LastName,
				FirstName,
				Mi,
				Addr1,
				Addr2,
				City,
				State,
				Zip,
				Ssn,
				Phone,
				PayFreq,
				Rate,
				Marital,
				YtdGrs,
				YtdFwt,
				YtdFica,
				YtdMed,
				YtdSwt,
				YtdOst,
				YtdCwt,
				Prenote,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
