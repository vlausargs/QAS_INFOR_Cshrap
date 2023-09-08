//PROJECT NAME: ProductExt
//CLASS NAME: SLJobRefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLJobRefs")]
    public class SLJobRefs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SaveTmpJobRefSp(byte? IsDelete,
                                   string PJobmatlJob,
                                   short? PJobmatlSuffix,
                                   int? PJobmatlOperNum,
                                   short? PJobmatlSequence,
                                   byte? IsClear)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSaveTmpJobRefExt = new SaveTmpJobRefFactory().Create(appDb);

                int Severity = iSaveTmpJobRefExt.SaveTmpJobRefSp(IsDelete,
                                                                 PJobmatlJob,
                                                                 PJobmatlSuffix,
                                                                 PJobmatlOperNum,
                                                                 PJobmatlSequence,
                                                                 IsClear);

                return Severity;
            }
        }
    }
}
