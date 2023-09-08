//PROJECT NAME: CodesExt
//CLASS NAME: SLWcompDCOs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLWcompDCOs")]
    public class SLWcompDCOs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetWcompIndustryClassificationSp(ref string WcompIndustryClassification,
                                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetWcompIndustryClassificationExt = new GetWcompIndustryClassificationFactory().Create(appDb);

                WorkersCompensationIndustryClassificationType oWcompIndustryClassification = WcompIndustryClassification;
                InfobarType oInfobar = Infobar;

                int Severity = iGetWcompIndustryClassificationExt.GetWcompIndustryClassificationSp(ref oWcompIndustryClassification,
                                                                                                   ref oInfobar);

                WcompIndustryClassification = oWcompIndustryClassification;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
