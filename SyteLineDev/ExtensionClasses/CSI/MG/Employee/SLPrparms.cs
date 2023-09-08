//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPrparms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLPrparms")]
    public class SLPrparms : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PayrollParamUpdatePrtrxSp(DateTime? CurStart,
                                             DateTime? CurEnd,
                                             decimal? HrsDay,
                                             decimal? HrsWeek,
                                             decimal? HrsBiWeek,
                                             decimal? HrsSemiMo,
                                             decimal? HrsMo,
                                             decimal? HrsQuart,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPayrollParamUpdatePrtrxExt = new PayrollParamUpdatePrtrxFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPayrollParamUpdatePrtrxExt.PayrollParamUpdatePrtrxSp(CurStart,
                                                                                     CurEnd,
                                                                                     HrsDay,
                                                                                     HrsWeek,
                                                                                     HrsBiWeek,
                                                                                     HrsSemiMo,
                                                                                     HrsMo,
                                                                                     HrsQuart,
                                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrParmsShiftSp(ref byte? Prompted,
                                  ref string PromptMsg,
                                  ref string PromptButtons,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrParmsShiftExt = new PrParmsShiftFactory().Create(appDb);

                ListYesNoType oPrompted = Prompted;
                InfobarType oPromptMsg = PromptMsg;
                Infobar oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iPrParmsShiftExt.PrParmsShiftSp(ref oPrompted,
                                                               ref oPromptMsg,
                                                               ref oPromptButtons,
                                                               ref oInfobar);

                Prompted = oPrompted;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPayrollParmsSp(ref DateTime? CurCheckDate,
		                             [Optional] ref string BankCode,
		                             [Optional] ref DateTime? PerStart,
		                             [Optional] ref DateTime? PerEnd,
		                             [Optional] ref string PayFreqs,
		                             [Optional] string EmpNum,
		                             [Optional] ref decimal? PrtrxRegHrs,
		                             [Optional] ref decimal? PrtrxWksWorked)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetPayrollParmsExt = new GetPayrollParmsFactory().Create(appDb);
				
				var result = iGetPayrollParmsExt.GetPayrollParmsSp(CurCheckDate,
				                                                   BankCode,
				                                                   PerStart,
				                                                   PerEnd,
				                                                   PayFreqs,
				                                                   EmpNum,
				                                                   PrtrxRegHrs,
				                                                   PrtrxWksWorked);
				
				int Severity = result.ReturnCode.Value;
				CurCheckDate = result.CurCheckDate;
				BankCode = result.BankCode;
				PerStart = result.PerStart;
				PerEnd = result.PerEnd;
				PayFreqs = result.PayFreqs;
				PrtrxRegHrs = result.PrtrxRegHrs;
				PrtrxWksWorked = result.PrtrxWksWorked;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PayrollPrintPostGetDefaultsSp([Optional] ref string rBankCode,
		                                         [Optional] ref DateTime? rCurCheckD)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPayrollPrintPostGetDefaultsExt = new PayrollPrintPostGetDefaultsFactory().Create(appDb);
				
				var result = iPayrollPrintPostGetDefaultsExt.PayrollPrintPostGetDefaultsSp(rBankCode,
				                                                                           rCurCheckD);
				
				int Severity = result.ReturnCode.Value;
				rBankCode = result.rBankCode;
				rCurCheckD = result.rCurCheckD;
				return Severity;
			}
		}
    }
}
