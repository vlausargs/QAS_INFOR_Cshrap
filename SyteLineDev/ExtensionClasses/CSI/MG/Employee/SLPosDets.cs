//PROJECT NAME: EmployeeExt
//CLASS NAME: SLPosDets.cs

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
    [IDOExtensionClass("SLPosDets")]
    public class SLPosDets : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpPositionMoveToHistPreSp(string PEmpNum,
                                              ref string PromptMsg,
                                              ref string PromptButtons,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpPositionMoveToHistPreExt = new EmpPositionMoveToHistPreFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                Infobar oPromptButtons = PromptButtons;
                Infobar oInfobar = Infobar;

                int Severity = iEmpPositionMoveToHistPreExt.EmpPositionMoveToHistPreSp(PEmpNum,
                                                                                       ref oPromptMsg,
                                                                                       ref oPromptButtons,
                                                                                       ref oInfobar);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpPositionMoveToHistSp(string PEmpNum,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpPositionMoveToHistExt = new EmpPositionMoveToHistFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iEmpPositionMoveToHistExt.EmpPositionMoveToHistSp(PEmpNum,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetNextJobDetailSp(string JobId,
                                      ref int? JobDetail,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetNextJobDetailExt = new GetNextJobDetailFactory().Create(appDb);

                JobDetailType oJobDetail = JobDetail;
                InfobarType oInfobar = Infobar;

                int Severity = iGetNextJobDetailExt.GetNextJobDetailSp(JobId,
                                                                       ref oJobDetail,
                                                                       ref oInfobar);

                JobDetail = oJobDetail;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
