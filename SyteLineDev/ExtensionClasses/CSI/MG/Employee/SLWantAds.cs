//PROJECT NAME: EmployeeExt
//CLASS NAME: SLWantAds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLWantAds")]
    public class SLWantAds : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetPosJobtitleSp(string pJobId,
                                    ref string pJobTitle)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetPosJobtitleExt = new GetPosJobtitleFactory().Create(appDb);

                JobTitleType opJobTitle = pJobTitle;

                int Severity = iGetPosJobtitleExt.GetPosJobtitleSp(pJobId,
                                                                   ref opJobTitle);

                pJobTitle = opJobTitle;


                return Severity;
            }
        }
    }
}
