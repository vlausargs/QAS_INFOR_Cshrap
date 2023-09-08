//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPrtrxds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLPrtrxds")]
    public class SLPrtrxds : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PrtrxdValidateIsExtSp(string EmpNum,
                                         short? Seq,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPrtrxdValidateIsExtExt = new PrtrxdValidateIsExtFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPrtrxdValidateIsExtExt.PrtrxdValidateIsExtSp(EmpNum,
                                                                             Seq,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PayDistGetPaySp([Optional] string pPtrxEmpNum,
		                           short? pPtrxSeq,
		                           ref string rEmpNum,
		                           ref short? rSeq,
		                           ref string rEmpName,
		                           ref string rEmpPayFreq,
		                           ref decimal? rEmpSalary,
		                           ref string rEmpType,
		                           ref string rEmpWcClass,
		                           ref string rPrtrxBankCode,
		                           ref string rPrtrxDept,
		                           ref decimal? rPrtrxDtHrs,
		                           ref decimal? rPrtrxHolHrs,
		                           ref decimal? rPrtrxOthHrs,
		                           ref decimal? rPrtrxOtHrs,
		                           ref string rPrtrxPayFreq,
		                           ref string rPrtrxPayFreqs,
		                           ref byte? rPrtrxPaySalary,
		                           ref decimal? rPrtrxRegHrs,
		                           ref decimal? rPrtrxSickhrs,
		                           ref decimal? rPrtrxSupplEarn,
		                           ref string rPrtrxType,
		                           ref decimal? rPrtrxVacHrs,
		                           ref decimal? rPrtrxWksWorked,
		                           ref decimal? rPrtrxWorkUnits,
		                           ref string rDerPrdecdWUnitDesc,
		                           ref string rDerEmpDeptUnit,
		                           ref string rDerEmpWageAcct,
		                           ref string rDerEmpWageAcctUnit1,
		                           ref string rDerEmpWageAcctUnit2,
		                           ref string rDerEmpWageAcctUnit3,
		                           ref string rDerEmpWageAcctUnit4,
		                           ref decimal? rDerEmpRegRate,
		                           ref decimal? rDerEmpOtRate,
		                           ref decimal? rDerEmpDtRate,
		                           ref decimal? rHrs,
		                           ref string rType,
		                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPayDistGetPayExt = new PayDistGetPayFactory().Create(appDb);
				
				var result = iPayDistGetPayExt.PayDistGetPaySp(pPtrxEmpNum,
				                                               pPtrxSeq,
				                                               rEmpNum,
				                                               rSeq,
				                                               rEmpName,
				                                               rEmpPayFreq,
				                                               rEmpSalary,
				                                               rEmpType,
				                                               rEmpWcClass,
				                                               rPrtrxBankCode,
				                                               rPrtrxDept,
				                                               rPrtrxDtHrs,
				                                               rPrtrxHolHrs,
				                                               rPrtrxOthHrs,
				                                               rPrtrxOtHrs,
				                                               rPrtrxPayFreq,
				                                               rPrtrxPayFreqs,
				                                               rPrtrxPaySalary,
				                                               rPrtrxRegHrs,
				                                               rPrtrxSickhrs,
				                                               rPrtrxSupplEarn,
				                                               rPrtrxType,
				                                               rPrtrxVacHrs,
				                                               rPrtrxWksWorked,
				                                               rPrtrxWorkUnits,
				                                               rDerPrdecdWUnitDesc,
				                                               rDerEmpDeptUnit,
				                                               rDerEmpWageAcct,
				                                               rDerEmpWageAcctUnit1,
				                                               rDerEmpWageAcctUnit2,
				                                               rDerEmpWageAcctUnit3,
				                                               rDerEmpWageAcctUnit4,
				                                               rDerEmpRegRate,
				                                               rDerEmpOtRate,
				                                               rDerEmpDtRate,
				                                               rHrs,
				                                               rType,
				                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				rEmpNum = result.rEmpNum;
				rSeq = result.rSeq;
				rEmpName = result.rEmpName;
				rEmpPayFreq = result.rEmpPayFreq;
				rEmpSalary = result.rEmpSalary;
				rEmpType = result.rEmpType;
				rEmpWcClass = result.rEmpWcClass;
				rPrtrxBankCode = result.rPrtrxBankCode;
				rPrtrxDept = result.rPrtrxDept;
				rPrtrxDtHrs = result.rPrtrxDtHrs;
				rPrtrxHolHrs = result.rPrtrxHolHrs;
				rPrtrxOthHrs = result.rPrtrxOthHrs;
				rPrtrxOtHrs = result.rPrtrxOtHrs;
				rPrtrxPayFreq = result.rPrtrxPayFreq;
				rPrtrxPayFreqs = result.rPrtrxPayFreqs;
				rPrtrxPaySalary = result.rPrtrxPaySalary;
				rPrtrxRegHrs = result.rPrtrxRegHrs;
				rPrtrxSickhrs = result.rPrtrxSickhrs;
				rPrtrxSupplEarn = result.rPrtrxSupplEarn;
				rPrtrxType = result.rPrtrxType;
				rPrtrxVacHrs = result.rPrtrxVacHrs;
				rPrtrxWksWorked = result.rPrtrxWksWorked;
				rPrtrxWorkUnits = result.rPrtrxWorkUnits;
				rDerPrdecdWUnitDesc = result.rDerPrdecdWUnitDesc;
				rDerEmpDeptUnit = result.rDerEmpDeptUnit;
				rDerEmpWageAcct = result.rDerEmpWageAcct;
				rDerEmpWageAcctUnit1 = result.rDerEmpWageAcctUnit1;
				rDerEmpWageAcctUnit2 = result.rDerEmpWageAcctUnit2;
				rDerEmpWageAcctUnit3 = result.rDerEmpWageAcctUnit3;
				rDerEmpWageAcctUnit4 = result.rDerEmpWageAcctUnit4;
				rDerEmpRegRate = result.rDerEmpRegRate;
				rDerEmpOtRate = result.rDerEmpOtRate;
				rDerEmpDtRate = result.rDerEmpDtRate;
				rHrs = result.rHrs;
				rType = result.rType;
				Infobar = result.Infobar;
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetChartInfoSp(string pChartAcct,
		ref string rChartType,
		ref string rAccessUnit1,
		ref string rAccessUnit2,
		ref string rAccessUnit3,
		ref string rAccessUnit4,
		ref string rDescription,
		ref string Infobar,
		[Optional] string Site,
		ref int? rIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetChartInfoExt = new GetChartInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetChartInfoExt.GetChartInfoSp(pChartAcct,
				rChartType,
				rAccessUnit1,
				rAccessUnit2,
				rAccessUnit3,
				rAccessUnit4,
				rDescription,
				Infobar,
				Site,
				rIsControl);
				
				int Severity = result.ReturnCode.Value;
				rChartType = result.rChartType;
				rAccessUnit1 = result.rAccessUnit1;
				rAccessUnit2 = result.rAccessUnit2;
				rAccessUnit3 = result.rAccessUnit3;
				rAccessUnit4 = result.rAccessUnit4;
				rDescription = result.rDescription;
				Infobar = result.Infobar;
				rIsControl = result.rIsControl;
				return Severity;
			}
		}
    }
}
