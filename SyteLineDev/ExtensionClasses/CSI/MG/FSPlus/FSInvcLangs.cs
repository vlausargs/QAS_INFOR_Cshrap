//PROJECT NAME: FSPlusExt
//CLASS NAME: FSInvcLangs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlus
{
    [IDOExtensionClass("FSInvcLangs")]
    public class FSInvcLangs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSGetMultiLingServiceTextSp(ref string IncText1,
                                                  ref string IncText2,
                                                  ref string IncText3,
                                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSGetMultiLingServiceTextExt = new SSSFSGetMultiLingServiceTextFactory().Create(appDb);

                ReportTxtType oIncText1 = IncText1;
                ReportTxtType oIncText2 = IncText2;
                ReportTxtType oIncText3 = IncText3;
                Infobar oInfobar = Infobar;

                int Severity = iSSSFSGetMultiLingServiceTextExt.SSSFSGetMultiLingServiceTextSp(ref oIncText1,
                                                                                               ref oIncText2,
                                                                                               ref oIncText3,
                                                                                               ref oInfobar);

                IncText1 = oIncText1;
                IncText2 = oIncText2;
                IncText3 = oIncText3;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
