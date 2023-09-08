//PROJECT NAME: EmployeeExt
//CLASS NAME: SLW2TaxConss.cs

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
    [IDOExtensionClass("SLW2TaxConss")]
    public class SLW2TaxConss : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckTaxCodeSp(string Code,
                                  string FromTo,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckTaxCodeExt = new CheckTaxCodeFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCheckTaxCodeExt.CheckTaxCodeSp(Code,
                                                               FromTo,
                                                               ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckW2TaxConsSp(ref string PromptMsg,
                                    ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckW2TaxConsExt = new CheckW2TaxConsFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;

                int Severity = iCheckW2TaxConsExt.CheckW2TaxConsSp(ref oPromptMsg,
                                                                   ref oPromptButtons);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;


                return Severity;
            }
        }
    }
}
