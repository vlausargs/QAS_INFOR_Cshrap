//PROJECT NAME: TaxInterfaceExt
//CLASS NAME: TaxInvHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.TaxInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.TaxInterface
{
    [IDOExtensionClass("TaxInvHdrs")]
    public class TaxInvHdrs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSVTXAvaTaxExemptProcessWrapperSp(string pInvNum,
                                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSVTXAvaTaxExemptProcessWrapperExt = new SSSVTXAvaTaxExemptProcessWrapperFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSSSVTXAvaTaxExemptProcessWrapperExt.SSSVTXAvaTaxExemptProcessWrapperSp(pInvNum,
                                                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSVTXAvaTaxExemptCheckWrapperSp(string pInvNum,
                                                    ref byte? oCanReverse,
                                                    ref decimal? oAvalaraTax,
                                                    ref decimal? oAvalaraTax2,
                                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSVTXAvaTaxExemptCheckWrapperExt = new SSSVTXAvaTaxExemptCheckWrapperFactory().Create(appDb);

                ListYesNoType ooCanReverse = oCanReverse;
                AmountType ooAvalaraTax = oAvalaraTax;
                AmountType ooAvalaraTax2 = oAvalaraTax2;
                InfobarType oInfobar = Infobar;

                int Severity = iSSSVTXAvaTaxExemptCheckWrapperExt.SSSVTXAvaTaxExemptCheckWrapperSp(pInvNum,
                                                                                                   ref ooCanReverse,
                                                                                                   ref ooAvalaraTax,
                                                                                                   ref ooAvalaraTax2,
                                                                                                   ref oInfobar);

                oCanReverse = ooCanReverse;
                oAvalaraTax = ooAvalaraTax;
                oAvalaraTax2 = ooAvalaraTax2;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}

