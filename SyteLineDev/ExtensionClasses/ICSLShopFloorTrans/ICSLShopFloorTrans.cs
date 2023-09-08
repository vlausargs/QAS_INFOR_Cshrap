//PROJECT NAME: WarehouseMobilityExt
//CLASS NAME: ICSLShopFloorTrans.cs

using System;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.WarehouseMobility;
using CSI.MG;

namespace CSI.IDOExtensions.WarehouseMobilityExt
{
    [IDOExtensionClass("ICSLShopFloorTrans")]
    public class ICSLShopFloorTrans : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTClearSessionTablesSp(Guid? SessionID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTClearSessionTablesExt = new FTTTClearSessionTablesFactory().Create(appDb);

                int Severity = iFTTTClearSessionTablesExt.FTTTClearSessionTablesSp(SessionID);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTGenerateOutputAndTidySp(Guid? SessionID,
                                               byte? PreserveSession,
                                               ref string OutputXmlString,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTGenerateOutputAndTidyExt = new FTTTGenerateOutputAndTidyFactory().Create(appDb);

                int Severity = iFTTTGenerateOutputAndTidyExt.FTTTGenerateOutputAndTidySp(SessionID,
                                                                                         PreserveSession,
                                                                                         ref OutputXmlString,
                                                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTInitializeSp(string ERPString,
                                    ref Guid? ReturnSessionID,
                                    ref int? ReturnHeaderRowCount,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTInitializeExt = new FTTTInitializeFactory().Create(appDb);

                int Severity = iFTTTInitializeExt.FTTTInitializeSp(ERPString,
                                                                   ref ReturnSessionID,
                                                                   ref ReturnHeaderRowCount,
                                                                   ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTInsertJobSp(Guid? SessionID,
                                   int? HeaderRow,
                                   ref string start_dateStr,
                                   ref string end_dateStr,
                                   ref string emp_num,
                                   ref int? NumOfRecords)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTInsertJobExt = new FTTTInsertJobFactory().Create(appDb);

                int Severity = iFTTTInsertJobExt.FTTTInsertJobSp(SessionID,
                                                                 HeaderRow,
                                                                 ref start_dateStr,
                                                                 ref end_dateStr,
                                                                 ref emp_num,
                                                                 ref NumOfRecords);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTProcessBadRecordSp(Guid? SessionID,
                                          decimal? TransNum,
                                          string ErrorMsg,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTProcessBadRecordExt = new FTTTProcessBadRecordFactory().Create(appDb);

                int Severity = iFTTTProcessBadRecordExt.FTTTProcessBadRecordSp(SessionID,
                                                                               TransNum,
                                                                               ErrorMsg,
                                                                               ref Infobar);

                return Severity;
            }
        }
    }
}
