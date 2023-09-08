//PROJECT NAME: EmployeeExt
//CLASS NAME: SLApplicants.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLApplicants")]
    public class SLApplicants : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PredisplayApplicantsSp(ref int? PCheckSsnEnabled)
        {
            var iPredisplayApplicantsExt = new PredisplayApplicantsFactory().Create(this, true);

            var result = iPredisplayApplicantsExt.PredisplayApplicantsSp(PCheckSsnEnabled);

            PCheckSsnEnabled = result.PCheckSsnEnabled;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetAccountsPayableParmsSp(ref string APCheckFormType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetAccountsPayableParmsExt = new GetAccountsPayableParmsFactory().Create(appDb);

                int Severity = iGetAccountsPayableParmsExt.GetAccountsPayableParmsSp(ref APCheckFormType);

                return Severity;
            }
        }
    }
}
