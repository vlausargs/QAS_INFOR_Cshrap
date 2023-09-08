//PROJECT NAME: EmployeeExt
//CLASS NAME: SLHrparms.cs

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
    [IDOExtensionClass("SLHrparms")]
    public class SLHrparms : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpSelfServContactHRInfoSp(ref string EmpEmail,
                                              ref string EmpUserName,
                                              ref string HREmail,
                                              ref string HRUserName,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpSelfServContactHRInfoExt = new EmpSelfServContactHRInfoFactory().Create(appDb);

                EmailType oEmpEmail = EmpEmail;
                UsernameType oEmpUserName = EmpUserName;
                EmailType oHREmail = HREmail;
                UsernameType oHRUserName = HRUserName;
                InfobarType oInfobar = Infobar;

                int Severity = iEmpSelfServContactHRInfoExt.EmpSelfServContactHRInfoSp(ref oEmpEmail,
                                                                                       ref oEmpUserName,
                                                                                       ref oHREmail,
                                                                                       ref oHRUserName,
                                                                                       ref oInfobar);

                EmpEmail = oEmpEmail;
                EmpUserName = oEmpUserName;
                HREmail = oHREmail;
                HRUserName = oHRUserName;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetEmpSelfServInfoSp(ref string EmpNum,
                                        ref DateTime? Today,
                                        ref DateTime? FirstDayOfCurrentYear)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetEmpSelfServInfoExt = new GetEmpSelfServInfoFactory().Create(appDb);

                EmpNumType oEmpNum = EmpNum;
                DateType oToday = Today;
                DateType oFirstDayOfCurrentYear = FirstDayOfCurrentYear;

                int Severity = iGetEmpSelfServInfoExt.GetEmpSelfServInfoSp(ref oEmpNum,
                                                                           ref oToday,
                                                                           ref oFirstDayOfCurrentYear);

                EmpNum = oEmpNum;
                Today = oToday;
                FirstDayOfCurrentYear = oFirstDayOfCurrentYear;


                return Severity;
            }
        }
    }
}
