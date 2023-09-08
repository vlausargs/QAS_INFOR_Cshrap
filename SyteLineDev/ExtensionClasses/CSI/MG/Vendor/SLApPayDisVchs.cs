//PROJECT NAME: VendorExt
//CLASS NAME: SLApPayDisVchs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLApPayDisVchs")]
    public class SLApPayDisVchs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ARAPOffsetCreateAPPaymentSp(string VendNum,
                                               decimal? ExchRate,
                                               byte? FixedRate,
                                               int? Voucher,
                                               decimal? OffsetAmt,
                                               string PoNum,
                                               string Site,
                                               string OffsetAcct,
                                               string OffsetAcctUnit1,
                                               string OffsetAcctUnit2,
                                               string OffsetAcctUnit3,
                                               string OffsetAcctUnit4,
                                               byte? CreateAppmt,
                                               string THPaymentNumberPrefix,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iARAPOffsetCreateAPPaymentExt = new ARAPOffsetCreateAPPaymentFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iARAPOffsetCreateAPPaymentExt.ARAPOffsetCreateAPPaymentSp(VendNum,
                                                                                         ExchRate,
                                                                                         FixedRate,
                                                                                         Voucher,
                                                                                         OffsetAmt,
                                                                                         PoNum,
                                                                                         Site,
                                                                                         OffsetAcct,
                                                                                         OffsetAcctUnit1,
                                                                                         OffsetAcctUnit2,
                                                                                         OffsetAcctUnit3,
                                                                                         OffsetAcctUnit4,
                                                                                         CreateAppmt,
                                                                                         THPaymentNumberPrefix,
                                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
