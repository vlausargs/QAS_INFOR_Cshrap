//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbChartOfAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFsbChartOfAccts")]
    public class SLFsbChartOfAccts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBConfirmMapSp(string Name,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbChartOfAcctsExt = new MultiFSBConfirmMapFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbChartOfAcctsExt.MultiFSBConfirmMapSp(Name,
                                                                          ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
