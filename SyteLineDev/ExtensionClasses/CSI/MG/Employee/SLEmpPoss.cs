//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpPoss.cs

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
    [IDOExtensionClass("SLEmpPoss")]
    public class SLEmpPoss : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpPositionUpdNewSp(string TEmpNum,
                                       string TJobId,
                                       DateTime? TJobdate,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpPositionUpdNewExt = new EmpPositionUpdNewFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iEmpPositionUpdNewExt.EmpPositionUpdNewSp(TEmpNum,
                                                                         TJobId,
                                                                         TJobdate,
                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpPositionVfyEmpNumSp(string PEmpNum,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpPositionVfyEmpNumExt = new EmpPositionVfyEmpNumFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iEmpPositionVfyEmpNumExt.EmpPositionVfyEmpNumSp(PEmpNum,
                                                                               ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpPositionVfyJobSp(string PJobId,
                                       int? PJobDetail,
                                       ref string TDept,
                                       ref string TDiv,
                                       ref string TCompNum,
                                       ref string TJobTitle,
                                       ref string TSuperNum,
                                       ref string TClass,
                                       ref string TJobGrade,
                                       ref string TEeoCls,
                                       ref byte? TExempt,
                                       ref string TWcClass,
                                       ref string TDeptDesc,
                                       ref string TDivName,
                                       ref string TCompName,
                                       ref string TSuperName,
                                       ref string TWcDescDesc,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpPositionVfyJobExt = new EmpPositionVfyJobFactory().Create(appDb);

                DeptType oTDept = TDept;
                DivNumType oTDiv = TDiv;
                CompNumType oTCompNum = TCompNum;
                JobTitleType oTJobTitle = TJobTitle;
                EmpNumType oTSuperNum = TSuperNum;
                PosClassType oTClass = TClass;
                JobGradeType oTJobGrade = TJobGrade;
                EEOClsType oTEeoCls = TEeoCls;
                ListYesNoType oTExempt = TExempt;
                DeCodeType oTWcClass = TWcClass;
                DescriptionType oTDeptDesc = TDeptDesc;
                NameType oTDivName = TDivName;
                NameType oTCompName = TCompName;
                NameType oTSuperName = TSuperName;
                DescriptionType oTWcDescDesc = TWcDescDesc;
                InfobarType oInfobar = Infobar;

                int Severity = iEmpPositionVfyJobExt.EmpPositionVfyJobSp(PJobId,
                                                                         PJobDetail,
                                                                         ref oTDept,
                                                                         ref oTDiv,
                                                                         ref oTCompNum,
                                                                         ref oTJobTitle,
                                                                         ref oTSuperNum,
                                                                         ref oTClass,
                                                                         ref oTJobGrade,
                                                                         ref oTEeoCls,
                                                                         ref oTExempt,
                                                                         ref oTWcClass,
                                                                         ref oTDeptDesc,
                                                                         ref oTDivName,
                                                                         ref oTCompName,
                                                                         ref oTSuperName,
                                                                         ref oTWcDescDesc,
                                                                         ref oInfobar);

                TDept = oTDept;
                TDiv = oTDiv;
                TCompNum = oTCompNum;
                TJobTitle = oTJobTitle;
                TSuperNum = oTSuperNum;
                TClass = oTClass;
                TJobGrade = oTJobGrade;
                TEeoCls = oTEeoCls;
                TExempt = oTExempt;
                TWcClass = oTWcClass;
                TDeptDesc = oTDeptDesc;
                TDivName = oTDivName;
                TCompName = oTCompName;
                TSuperName = oTSuperName;
                TWcDescDesc = oTWcDescDesc;
                Infobar = oInfobar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EmployeeShiftSetSp(string EmpNum,
		string Shift)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEmployeeShiftSetExt = new EmployeeShiftSetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEmployeeShiftSetExt.EmployeeShiftSetSp(EmpNum,
				Shift);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
