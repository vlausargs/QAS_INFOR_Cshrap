//PROJECT NAME: FinanceExt
//CLASS NAME: SLGLVoucherTemplates.cs

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
    [IDOExtensionClass("SLGLVoucherTemplates")]
    public class SLGLVoucherTemplates : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CopyTemplateToGLVoucherSp(string FromTemplate,
        string ToGLVoucher,
        ref string Infobar,
        [Optional] DateTime? TranDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCopyTemplateToGLVoucherExt = new CopyTemplateToGLVoucherFactory().Create(appDb);

                var result = iCopyTemplateToGLVoucherExt.CopyTemplateToGLVoucherSp(FromTemplate,
                ToGLVoucher,
                Infobar,
                TranDate);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }

        }
    }
}
