//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHVucherRecurrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHVucherRecurrs")]
    public class CHVucherRecurrs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSRecurrVoucherPreviewToGenSp(int? ID,
                                                  DateTime? TransDate,
                                                  string TypeCode,
                                                  string UserName,
                                                  ref string VoucherNumber,
                                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSRecurrVoucherPreviewToGenExt = new CHSRecurrVoucherPreviewToGenFactory().Create(appDb);

                GenericMedCodeType oVoucherNumber = VoucherNumber;
                InfobarType oInfobar = Infobar;

                int Severity = iCHSRecurrVoucherPreviewToGenExt.CHSRecurrVoucherPreviewToGenSp(ID,
                                                                                               TransDate,
                                                                                               TypeCode,
                                                                                               UserName,
                                                                                               ref oVoucherNumber,
                                                                                               ref oInfobar);

                VoucherNumber = oVoucherNumber;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}

