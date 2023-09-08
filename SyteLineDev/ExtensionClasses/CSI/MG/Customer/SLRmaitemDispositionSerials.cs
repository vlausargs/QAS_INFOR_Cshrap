//PROJECT NAME: CustomerExt
//CLASS NAME: SLRmaitemDispositionSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLRmaitemDispositionSerials")]
    public class SLRmaitemDispositionSerials : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXSerialCheckSp(string SerNum,
                                       ref string Prompt,
                                       ref string Infobar,
                                       string Item)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXSerialCheckExt = new SSSRMXSerialCheckFactory().Create(appDb);

                int Severity = iSSSRMXSerialCheckExt.SSSRMXSerialCheckSp(SerNum,
                                                                         ref Prompt,
                                                                         ref Infobar,
                                                                         Item);

                return Severity;
            }
        }
    }
}
