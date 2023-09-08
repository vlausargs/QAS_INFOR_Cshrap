//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUQAProcessPhasesDefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Automotive;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.AUIndPack
{
    [IDOExtensionClass("AUQAProcessPhasesDefs")]
    public class AUQAProcessPhasesDefs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AU_QAProcessDefnPhaseResequenceSp(string QAProcess)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAU_QAProcessDefnPhaseResequenceExt = new AU_QAProcessDefnPhaseResequenceFactory().Create(appDb);

                int Severity = iAU_QAProcessDefnPhaseResequenceExt.AU_QAProcessDefnPhaseResequenceSp(QAProcess);

                return Severity;
            }
        }
    }
}
