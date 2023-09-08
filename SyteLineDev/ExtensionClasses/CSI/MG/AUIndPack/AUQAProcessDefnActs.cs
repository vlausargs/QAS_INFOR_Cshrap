//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUQAProcessDefnActs.cs

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
    [IDOExtensionClass("AUQAProcessDefnActs")]
    public class AUQAProcessDefnActs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AU_QAProcessDefnPhaseActivityResequenceSp(string QAProcess,
                                                             decimal? Sequence)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAU_QAProcessDefnPhaseActivityResequenceExt = new AU_QAProcessDefnPhaseActivityResequenceFactory().Create(appDb);

                int Severity = iAU_QAProcessDefnPhaseActivityResequenceExt.AU_QAProcessDefnPhaseActivityResequenceSp(QAProcess,
                                                                                                                     Sequence);

                return Severity;
            }
        }
    }
}
