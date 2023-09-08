//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUQAProcessPhases.cs

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
    [IDOExtensionClass("AUQAProcessPhases")]
    public class AUQAProcessPhases : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AU_CheckQAStartDateSp(string ProcessID,
                                         DateTime? StartDate,
                                         decimal? Sequence,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAU_CheckQAStartDateExt = new AU_CheckQAStartDateFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iAU_CheckQAStartDateExt.AU_CheckQAStartDateSp(ProcessID,
                                                                             StartDate,
                                                                             Sequence,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AU_QAProcessPhaseResequenceSp(string QAProcess)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAU_QAProcessPhaseResequenceSExt = new AU_QAProcessPhaseResequenceSFactory().Create(appDb);

                int Severity = iAU_QAProcessPhaseResequenceSExt.AU_QAProcessPhaseResequenceSp(QAProcess);

                return Severity;
            }
        }
    }
}

