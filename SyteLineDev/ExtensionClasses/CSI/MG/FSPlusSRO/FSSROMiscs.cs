//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROMiscs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSROMiscs")]
    public class FSSROMiscs : CSIExtensionClassBase, IFSSROMiscs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSExpenseReconSp(string Mode,
                                       string PayType,
                                       decimal? MiscCharges,
                                       decimal? AmountDue,
                                       string VendNum,
                                       string InvNum,
                                       DateTime? InvDate,
                                       DateTime? DistDate,
                                       string BatchId,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSExpenseReconExt = new SSSFSExpenseReconFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSExpenseReconExt.SSSFSExpenseReconSp(Mode,
                                                                         PayType,
                                                                         MiscCharges,
                                                                         AmountDue,
                                                                         VendNum,
                                                                         InvNum,
                                                                         InvDate,
                                                                         DistDate,
                                                                         BatchId,
                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSPortalValidateSROMiscSp(string SroNum,
                                                int? SroLine,
                                                int? SroOper,
                                                string PartnerID,
                                                DateTime? TransDate,
                                                string CustNum,
                                                string CustSeq,
                                                string Username,
                                                string MiscCode,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSPortalValidateSROMiscExt = new SSSFSPortalValidateSROMiscFactory().Create(appDb);

                int Severity = iSSSFSPortalValidateSROMiscExt.SSSFSPortalValidateSROMiscSp(SroNum,
                                                                                           SroLine,
                                                                                           SroOper,
                                                                                           PartnerID,
                                                                                           TransDate,
                                                                                           CustNum,
                                                                                           CustSeq,
                                                                                           Username,
                                                                                           MiscCode,
                                                                                           ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSExpenseReconCleanupSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSExpenseReconCleanupExt = new SSSFSExpenseReconCleanupFactory().Create(appDb);

                int Severity = iSSSFSExpenseReconCleanupExt.SSSFSExpenseReconCleanupSp();

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSExpenseReconSaveSp(Guid? RowPointer,
                                           int? Selected)
        {
            var iSSSFSExpenseReconSaveExt = this.GetService<ISSSFSExpenseReconSave>();
            var result = iSSSFSExpenseReconSaveExt.SSSFSExpenseReconSaveSp(RowPointer,
                                                                             Selected);
            return result ?? 0;
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSroTransPostMiscSp(Guid? iRowPointer,
                                           string iMode,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSroTransPostMiscExt = new SSSFSSroTransPostMiscFactory().Create(appDb);

                int Severity = iSSSFSSroTransPostMiscExt.SSSFSSroTransPostMiscSp(iRowPointer,
                                                                                 iMode,
                                                                                 ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSPortalCreateSROMiscSp(string SroNum,
                                              int? SroLine,
                                              int? SroOper,
                                              string PartnerID,
                                              DateTime? TransDate,
                                              string CustNum,
                                              string CustSeq,
                                              string Username,
                                              string MiscCode,
                                              string MiscCodeDesc,
                                              decimal? QtyConv,
                                              decimal? CostConv,
                                              string NoteContent,
                                              [Optional, DefaultParameterValue((byte)0)] byte? Validate,
        ref Guid? RowPointer,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSPortalCreateSROMiscExt = new SSSFSPortalCreateSROMiscFactory().Create(appDb);

                var result = iSSSFSPortalCreateSROMiscExt.SSSFSPortalCreateSROMiscSp(SroNum,
                                                                                     SroLine,
                                                                                     SroOper,
                                                                                     PartnerID,
                                                                                     TransDate,
                                                                                     CustNum,
                                                                                     CustSeq,
                                                                                     Username,
                                                                                     MiscCode,
                                                                                     MiscCodeDesc,
                                                                                     QtyConv,
                                                                                     CostConv,
                                                                                     NoteContent,
                                                                                     Validate,
                                                                                     RowPointer,
                                                                                     Infobar);

                int Severity = result.ReturnCode.Value;
                RowPointer = result.RowPointer;
                Infobar = result.Infobar;
                return Severity;
            }
        }





        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSroMiscRateSp(string iTransType,
        string iSroNum,
        int? iSroLine,
        int? iSroOper,
        string iBillCode,
        DateTime? iTransDate,
        string iPartner,
        string iMiscCode,
        decimal? iUnitCost,
        decimal? iQty,
        ref decimal? oUnitPrice,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iSSSFSSroMiscRateExt = new SSSFSSroMiscRateFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iSSSFSSroMiscRateExt.SSSFSSroMiscRateSp(iTransType,
                iSroNum,
                iSroLine,
                iSroOper,
                iBillCode,
                iTransDate,
                iPartner,
                iMiscCode,
                iUnitCost,
                iQty,
                oUnitPrice,
                Infobar);

                int Severity = result.ReturnCode.Value;
                oUnitPrice = result.oUnitPrice;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSroPlanTransPostMiscSp(Guid? iRowPointer,
        string iMode,
        string iPartnerId,
        string iDept,
        string iWhse,
        DateTime? iTransDate,
        DateTime? iPostDate,
        decimal? iPstQty,
        decimal? iMatlCost,
        decimal? iLbrCost,
        decimal? iFovhdCost,
        decimal? iVovhdCost,
        decimal? iOutCost,
        string UpdateStatus,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iSSSFSSroPlanTransPostMiscExt = new SSSFSSroPlanTransPostMiscFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iSSSFSSroPlanTransPostMiscExt.SSSFSSroPlanTransPostMiscSp(iRowPointer,
                iMode,
                iPartnerId,
                iDept,
                iWhse,
                iTransDate,
                iPostDate,
                iPstQty,
                iMatlCost,
                iLbrCost,
                iFovhdCost,
                iVovhdCost,
                iOutCost,
                UpdateStatus,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROTransMiscCstPrcTaxSp(string SroNum,
        int? SroLine,
        int? SroOper,
        string MiscCode,
        string BillCode,
        DateTime? TransDate,
        string PartnerId,
        decimal? Qty,
        ref decimal? DefCost,
        ref decimal? DefPrice,
        ref string TaxCode1,
        ref string TaxCode2,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iSSSFSSROTransMiscCstPrcTaxExt = new SSSFSSROTransMiscCstPrcTaxFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iSSSFSSROTransMiscCstPrcTaxExt.SSSFSSROTransMiscCstPrcTaxSp(SroNum,
                SroLine,
                SroOper,
                MiscCode,
                BillCode,
                TransDate,
                PartnerId,
                Qty,
                DefCost,
                DefPrice,
                TaxCode1,
                TaxCode2,
                Infobar);

                int Severity = result.ReturnCode.Value;
                DefCost = result.DefCost;
                DefPrice = result.DefPrice;
                TaxCode1 = result.TaxCode1;
                TaxCode2 = result.TaxCode2;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROTransValidSROMiscSp(string Table,
        string Level,
        string SRONum,
        ref int? SROLine,
        ref int? SROOper,
        ref DateTime? TransDate,
        ref DateTime? PostDate,
        ref string PartnerID,
        ref string PartnerCurrCode,
        ref string Dept,
        ref string Whse,
        ref string BillCode,
        ref string MiscCode,
        ref string MiscCodeDesc,
        ref decimal? UnitCost,
        ref decimal? UnitPrice,
        ref string TaxCode1,
        ref string TaxCode2,
        ref string VatLabel,
        ref string PriceCurrCode,
        ref string Prompt,
        ref string PromptButtons,
        ref decimal? Disc,
        ref string Infobar,
        ref string CurAmtFormat,
        ref string CurCstPrcFormat,
        [Optional, DefaultParameterValue("A")] string Type,
        [Optional] ref string ReimbTaxCode1,
        [Optional] ref string ReimbTaxCode2,
        [Optional] ref string ReimbMethod)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iSSSFSSROTransValidSROMiscExt = new SSSFSSROTransValidSROMiscFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iSSSFSSROTransValidSROMiscExt.SSSFSSROTransValidSROMiscSp(Table,
                Level,
                SRONum,
                SROLine,
                SROOper,
                TransDate,
                PostDate,
                PartnerID,
                PartnerCurrCode,
                Dept,
                Whse,
                BillCode,
                MiscCode,
                MiscCodeDesc,
                UnitCost,
                UnitPrice,
                TaxCode1,
                TaxCode2,
                VatLabel,
                PriceCurrCode,
                Prompt,
                PromptButtons,
                Disc,
                Infobar,
                CurAmtFormat,
                CurCstPrcFormat,
                Type,
                ReimbTaxCode1,
                ReimbTaxCode2,
                ReimbMethod);

                int Severity = result.ReturnCode.Value;
                SROLine = result.SROLine;
                SROOper = result.SROOper;
                TransDate = result.TransDate;
                PostDate = result.PostDate;
                PartnerID = result.PartnerID;
                PartnerCurrCode = result.PartnerCurrCode;
                Dept = result.Dept;
                Whse = result.Whse;
                BillCode = result.BillCode;
                MiscCode = result.MiscCode;
                MiscCodeDesc = result.MiscCodeDesc;
                UnitCost = result.UnitCost;
                UnitPrice = result.UnitPrice;
                TaxCode1 = result.TaxCode1;
                TaxCode2 = result.TaxCode2;
                VatLabel = result.VatLabel;
                PriceCurrCode = result.PriceCurrCode;
                Prompt = result.Prompt;
                PromptButtons = result.PromptButtons;
                Disc = result.Disc;
                Infobar = result.Infobar;
                CurAmtFormat = result.CurAmtFormat;
                CurCstPrcFormat = result.CurCstPrcFormat;
                ReimbTaxCode1 = result.ReimbTaxCode1;
                ReimbTaxCode2 = result.ReimbTaxCode2;
                ReimbMethod = result.ReimbMethod;
                return Severity;
            }
        }
    }
}
