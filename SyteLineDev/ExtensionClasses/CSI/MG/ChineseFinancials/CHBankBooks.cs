//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHBankBooks.cs

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
    [IDOExtensionClass("CHBankBooks")]
    public class CHBankBooks : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSLoadBankBookSp(string PBankCode,
                                     DateTime? PDateFrom,
                                     DateTime? PDateTo,
                                     ref int? PReadCount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSLoadBankBookExt = new CHSLoadBankBookFactory().Create(appDb);

                GenericIntType oPReadCount = PReadCount;

                int Severity = iCHSLoadBankBookExt.CHSLoadBankBookSp(PBankCode,
                                                                     PDateFrom,
                                                                     PDateTo,
                                                                     ref oPReadCount);

                PReadCount = oPReadCount;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CHSCLM_LoadBankBookSp(string PBankCode,
                                               DateTime? PDateFrom,
                                               DateTime? PDateTo)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCHSCLM_LoadBankBookExt = new CHSCLM_LoadBankBookFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCHSCLM_LoadBankBookExt.CHSCLM_LoadBankBookSp(PBankCode,
                                                                             PDateFrom,
                                                                             PDateTo);

                return dt;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSAutoMatchingSp(ref int? PMatchCount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSAutoMatchingExt = new CHSAutoMatchingFactory().Create(appDb);

                GenericIntType oPMatchCount = PMatchCount;

                int Severity = iCHSAutoMatchingExt.CHSAutoMatchingSp(ref oPMatchCount);

                PMatchCount = oPMatchCount;


                return Severity;
            }
        }
    }
}

