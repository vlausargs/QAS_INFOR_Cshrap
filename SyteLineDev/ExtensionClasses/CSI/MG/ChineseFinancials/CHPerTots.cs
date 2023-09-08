//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHPerTots.cs

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
    [IDOExtensionClass("CHPerTots")]
    public class CHPerTots : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CHSCLM_PostedVchTrnxSummarySp(short? FiscalYear,
                                                       byte? Period,
                                                       byte? DisplayAll,
                                                       byte? SortMethod,
                                                       string AcctFrom,
                                                       string Unit1From,
                                                       string Unit2From,
                                                       string Unit3From,
                                                       string Unit4From,
                                                       string AcctTo,
                                                       string Unit1To,
                                                       string Unit2To,
                                                       string Unit3To,
                                                       string Unit4To,
                                                       Guid? SessionId,
                                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCHSCLM_PostedVchTrnxSummaryExt = new CHSCLM_PostedVchTrnxSummaryFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCHSCLM_PostedVchTrnxSummaryExt.CHSCLM_PostedVchTrnxSummarySp(FiscalYear,
                                                                                             Period,
                                                                                             DisplayAll,
                                                                                             SortMethod,
                                                                                             AcctFrom,
                                                                                             Unit1From,
                                                                                             Unit2From,
                                                                                             Unit3From,
                                                                                             Unit4From,
                                                                                             AcctTo,
                                                                                             Unit1To,
                                                                                             Unit2To,
                                                                                             Unit3To,
                                                                                             Unit4To,
                                                                                             SessionId,
                                                                                             ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }
    }
}
