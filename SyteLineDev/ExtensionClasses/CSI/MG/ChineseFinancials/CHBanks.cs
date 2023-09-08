//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHBanks.cs

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
    [IDOExtensionClass("CHBanks")]
    public class CHBanks : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSMatchingSp(string PBankBookSeq,
                                 string PBankBookRecSeq)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSMatchingExt = new CHSMatchingFactory().Create(appDb);

                int Severity = iCHSMatchingExt.CHSMatchingSp(PBankBookSeq,
                                                             PBankBookRecSeq);

                return Severity;
            }
        }
    }
}

