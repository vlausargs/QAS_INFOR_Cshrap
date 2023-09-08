//PROJECT NAME: FinanceExt
//CLASS NAME: SLLedgers.cs

using System;
using System.Data;
using CSI.Data.SQL.UDDT;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Codes;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLLedgers")]
    public class SLLedgers : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GlCmprPInitializeSp(ref DateTime? RPeriodsPerStart,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLLedgersExt = new GlCmprPInitializeFactory().Create(appDb);

                DateType oRPeriodsPerStart = RPeriodsPerStart;
                InfobarType oInfobar = Infobar;

                int Severity = iSLLedgersExt.GlCmprPInitializeSp(ref oRPeriodsPerStart,
                                                                 ref oInfobar);

                RPeriodsPerStart = oRPeriodsPerStart;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GlCmprPLastTranSp(decimal? PUserID,
                                     byte? PLock,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGlCmprPLastTranExt = new GlCmprPLastTranFactory().Create(appDb);

                int Severity = iGlCmprPLastTranExt.GlCmprPLastTranSp(PUserID,
                                                                     PLock,
                                                                     ref Infobar);

                return Severity;
            }
        }








        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_JournalDetailTranSp([Optional, DefaultParameterValue("E")] string Type,
            [Optional] string JournalId,
            [Optional] string ControlPrefix,
            [Optional] string ControlSite,
            [Optional] short? ControlYear,
            [Optional] byte? ControlPeriod,
            [Optional] decimal? ControlNumber)
        {
            var iCLM_JournalDetailTranExt = new CLM_JournalDetailTranFactory().Create(this, true);

            var result = iCLM_JournalDetailTranExt.CLM_JournalDetailTranSp(Type,
                JournalId,
                ControlPrefix,
                ControlSite,
                ControlYear,
                ControlPeriod,
                ControlNumber);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_LoadDimAttributeOverrideSp([Optional] string Acct,
                    string SubscriberObjectName,
                    Guid? SubscriberObjectRowPointer)
        {
            var iCLM_LoadDimAttributeOverrideExt = this.GetService<ICLM_LoadDimAttributeOverride>();

            var result = iCLM_LoadDimAttributeOverrideExt.CLM_LoadDimAttributeOverrideSp(Acct,
                SubscriberObjectName,
                SubscriberObjectRowPointer);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EXTCHSGetCHGLInfoSp(decimal? TransNum,
        ref string CHVounum,
        ref int? LineNum,
        ref int? Rubric)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iEXTCHSGetCHGLInfoExt = new EXTCHSGetCHGLInfoFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iEXTCHSGetCHGLInfoExt.EXTCHSGetCHGLInfoSp(TransNum,
                CHVounum,
                LineNum,
                Rubric);

                int Severity = result.ReturnCode.Value;
                CHVounum = result.CHVounum;
                LineNum = result.LineNum;
                Rubric = result.Rubric;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GlCmprPDoProcessBkSp(string CompressBy,
        string CompressionLevel,
        int? AnalyticalLedger,
        DateTime? PerStart,
        DateTime? PerEnd,
        string AcctStart,
        string AcctEnd,
        string Site,
        decimal? UserId,
        string CurrentCultureName,
        decimal? BGTaskId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iGlCmprPDoProcessBkExt = new GlCmprPDoProcessBkFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGlCmprPDoProcessBkExt.GlCmprPDoProcessBkSp(CompressBy,
                CompressionLevel,
                AnalyticalLedger,
                PerStart,
                PerEnd,
                AcctStart,
                AcctEnd,
                Site,
                UserId,
                CurrentCultureName,
                BGTaskId);

                int Severity = result.Value;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GlCmprPDoProcessSp(Guid? ProcessId,
        string PCompressBy,
        string PCompressionLevel,
        int? PAnalyticalLedger,
        ref int? RACompressed,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iGlCmprPDoProcessExt = new GlCmprPDoProcessFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGlCmprPDoProcessExt.GlCmprPDoProcessSp(ProcessId,
                PCompressBy,
                PCompressionLevel,
                PAnalyticalLedger,
                RACompressed,
                Infobar);

                int Severity = result.ReturnCode.Value;
                RACompressed = result.RACompressed;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LedgerCompressPostCompleteSp(string PLedgerTable,
        Guid? ProcessId,
        ref string Infobar,
        [Optional, DefaultParameterValue(0)] int? Override,
        [Optional, DefaultParameterValue(0)] int? IsFromFsb)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iLedgerCompressPostCompleteExt = new LedgerCompressPostCompleteFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iLedgerCompressPostCompleteExt.LedgerCompressPostCompleteSp(PLedgerTable,
                ProcessId,
                Infobar,
                Override,
                IsFromFsb);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LedgerCompressSnapshotSp(Guid? ProcessId,
        DateTime? PTransDateStart,
        DateTime? PTransDateEnd,
        string PAcctStart,
        string PAcctEnd,
        int? PAnalyticalLedger,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iLedgerCompressSnapshotExt = new LedgerCompressSnapshotFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iLedgerCompressSnapshotExt.LedgerCompressSnapshotSp(ProcessId,
                PTransDateStart,
                PTransDateEnd,
                PAcctStart,
                PAcctEnd,
                PAnalyticalLedger,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LedgerDimAttributesOverrideUpdateSp(Guid? SubscriberObjectRowpointer,
        string AnalysisAttributeValue01,
        string AnalysisAttributeValue02,
        string AnalysisAttributeValue03,
        string AnalysisAttributeValue04,
        string AnalysisAttributeValue05,
        string AnalysisAttributeValue06,
        string AnalysisAttributeValue07,
        string AnalysisAttributeValue08,
        string AnalysisAttributeValue09,
        string AnalysisAttributeValue10,
        string AnalysisAttributeValue11,
        string AnalysisAttributeValue12,
        string AnalysisAttributeValue13,
        string AnalysisAttributeValue14,
        string AnalysisAttributeValue15)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iLedgerDimAttributesOverrideUpdateExt = new LedgerDimAttributesOverrideUpdateFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iLedgerDimAttributesOverrideUpdateExt.LedgerDimAttributesOverrideUpdateSp(SubscriberObjectRowpointer,
                AnalysisAttributeValue01,
                AnalysisAttributeValue02,
                AnalysisAttributeValue03,
                AnalysisAttributeValue04,
                AnalysisAttributeValue05,
                AnalysisAttributeValue06,
                AnalysisAttributeValue07,
                AnalysisAttributeValue08,
                AnalysisAttributeValue09,
                AnalysisAttributeValue10,
                AnalysisAttributeValue11,
                AnalysisAttributeValue12,
                AnalysisAttributeValue13,
                AnalysisAttributeValue14,
                AnalysisAttributeValue15);

                int Severity = result.Value;
                return Severity;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable FRCLM_FecExportSp(int? PYear,
        int? PPeriod,
        string PSAcct,
        string PEAcct)
        {
            var iFRCLM_FecExportExt = new FRCLM_FecExportFactory().Create(this, true);

            var result = iFRCLM_FecExportExt.FRCLM_FecExportSp(PYear,
            PPeriod,
            PSAcct,
            PEAcct);

            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

            DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
            return dt;
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FRFecGetPathSp(ref string PPath,
        ref string PFedId,
        ref string Infobar)
        {
            var iFRFecGetPathExt = new FRFecGetPathFactory().Create(this, true);

            var result = iFRFecGetPathExt.FRFecGetPathSp(PPath,
            PFedId,
            Infobar);

            int Severity = result.ReturnCode.Value;
            PPath = result.PPath;
            PFedId = result.PFedId;
            Infobar = result.Infobar;
            return Severity;
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FRFecValidateParmsSp(int? PYear,
        ref int? PPrintFinal,
        ref DateTime? PEndDate,
        ref int? PPeriod,
        ref int? PPromptFlag,
        ref string Infobar)
        {
            var iFRFecValidateParmsExt = new FRFecValidateParmsFactory().Create(this, true);

            var result = iFRFecValidateParmsExt.FRFecValidateParmsSp(PYear,
            PPrintFinal,
            PEndDate,
            PPeriod,
            PPromptFlag,
            Infobar);

            int Severity = result.ReturnCode.Value;
            PPrintFinal = result.PPrintFinal;
            PEndDate = result.PEndDate;
            PPeriod = result.PPeriod;
            PPromptFlag = result.PPromptFlag;
            Infobar = result.Infobar;
            return Severity;
        }
    }
}
