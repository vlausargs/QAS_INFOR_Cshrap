//PROJECT NAME: MaterialExt
//CLASS NAME: SLRsvdInvs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLRsvdInvs")]
    public class SLRsvdInvs : CSIExtensionClassBase, IExtFTSLRsvdInvs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetCoItemDetailSp(string CoNum,
                                     short? CoLine,
                                     short? CoRelease,
                                     ref string CoCustNum,
                                     ref string CoCustName,
                                     ref string CoItem,
                                     ref string CoItemDesc,
                                     ref string CoStat,
                                     ref DateTime? CoDueDate,
                                     ref decimal? CoQtyOrderedConv,
                                     ref string CoUM,
                                     ref decimal? CoQtyResv,
                                     ref byte? CoLotTracked,
                                     ref byte? CoSNTracked,
                                     ref string CoWhse,
                                     ref string CoItemUM,
                                     ref byte? CoItemReservable,
                                     ref string Infobar,
                                     ref byte? CoTaxFreeMatl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetCoItemDetailExt = new GetCoItemDetailFactory().Create(appDb);

                CustNumType oCoCustNum = CoCustNum;
                NameType oCoCustName = CoCustName;
                ItemType oCoItem = CoItem;
                DescriptionType oCoItemDesc = CoItemDesc;
                CoitemStatusType oCoStat = CoStat;
                DateType oCoDueDate = CoDueDate;
                QtyUnitType oCoQtyOrderedConv = CoQtyOrderedConv;
                UMType oCoUM = CoUM;
                QtyUnitType oCoQtyResv = CoQtyResv;
                ListYesNoType oCoLotTracked = CoLotTracked;
                ListYesNoType oCoSNTracked = CoSNTracked;
                WhseType oCoWhse = CoWhse;
                UMType oCoItemUM = CoItemUM;
                ListYesNoType oCoItemReservable = CoItemReservable;
                Infobar oInfobar = Infobar;
                ListYesNoType oCoTaxFreeMatl = CoTaxFreeMatl;

                int Severity = iGetCoItemDetailExt.GetCoItemDetailSp(CoNum,
                                                                CoLine,
                                                                CoRelease,
                                                                ref oCoCustNum,
                                                                ref oCoCustName,
                                                                ref oCoItem,
                                                                ref oCoItemDesc,
                                                                ref oCoStat,
                                                                ref oCoDueDate,
                                                                ref oCoQtyOrderedConv,
                                                                ref oCoUM,
                                                                ref oCoQtyResv,
                                                                ref oCoLotTracked,
                                                                ref oCoSNTracked,
                                                                ref oCoWhse,
                                                                ref oCoItemUM,
                                                                ref oCoItemReservable,
                                                                ref oInfobar,
                                                                ref oCoTaxFreeMatl);

                CoCustNum = oCoCustNum;
                CoCustName = oCoCustName;
                CoItem = oCoItem;
                CoItemDesc = oCoItemDesc;
                CoStat = oCoStat;
                CoDueDate = oCoDueDate;
                CoQtyOrderedConv = oCoQtyOrderedConv;
                CoUM = oCoUM;
                CoQtyResv = oCoQtyResv;
                CoLotTracked = oCoLotTracked;
                CoSNTracked = oCoSNTracked;
                CoWhse = oCoWhse;
                CoItemUM = oCoItemUM;
                CoItemReservable = oCoItemReservable;
                Infobar = oInfobar;
                CoTaxFreeMatl = oCoTaxFreeMatl;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ResforOrderUpdateSp(string PCmd,
                                       ref decimal? RsvdNum,
                                       string Item,
                                       string Whse,
                                       string RefNum,
                                       short? RefLine,
                                       short? RefRelease,
                                       string CustNum,
                                       string Loc,
                                       string Lot,
                                       decimal? Qty,
                                       string UM,
                                       Guid? SessionID,
                                       ref string Infobar,
                                       string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iResforOrderUpdateExt = new ResforOrderUpdateFactory().Create(appDb);

                RsvdNumType oRsvdNum = RsvdNum;
                Infobar oInfobar = Infobar;

                int Severity = iResforOrderUpdateExt.ResforOrderUpdateSp(PCmd,
                                                                  ref oRsvdNum,
                                                                  Item,
                                                                  Whse,
                                                                  RefNum,
                                                                  RefLine,
                                                                  RefRelease,
                                                                  CustNum,
                                                                  Loc,
                                                                  Lot,
                                                                  Qty,
                                                                  UM,
                                                                  SessionID,
                                                                  ref oInfobar,
                                                                  ImportDocId);

                RsvdNum = oRsvdNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RsvdInvCheckLocValidSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          decimal? QtyRsvd,
                                          ref string Description,
                                          ref string Infobar,
                                          string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRsvdInvCheckLocValidExt = new RsvdInvCheckLocValidFactory().Create(appDb);

                DescriptionType oDescription = Description;
                Infobar oInfobar = Infobar;

                int Severity = iRsvdInvCheckLocValidExt.RsvdInvCheckLocValidSp(Item,
                                                                     Whse,
                                                                     Loc,
                                                                     Lot,
                                                                     QtyRsvd,
                                                                     ref oDescription,
                                                                     ref oInfobar,
                                                                     ImportDocId);

                Description = oDescription;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RsvdInvCheckLotValidSp(string Item,
                                           string Whse,
                                           string Loc,
                                           string Lot,
                                           decimal? QtyRsvd,
                                           ref string Infobar,
                                           string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRsvdInvCheckLotValidExt = new RsvdInvCheckLotValidFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iRsvdInvCheckLotValidExt.RsvdInvCheckLotValidSp(Item,
                                                                     Whse,
                                                                     Loc,
                                                                     Lot,
                                                                     QtyRsvd,
                                                                     ref oInfobar,
                                                                     ImportDocId);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RsvdInvCheckRsvdQtyValidSp(string Item,
                                                      string Whse,
                                                      string Loc,
                                                      string Lot,
                                                      decimal? QtyRsvd,
                                                      decimal? QtyRsvdOld,
                                                      ref string Infobar,
                                                      string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRsvdInvCheckRsvdQtyValidExt = new RsvdInvCheckRsvdQtyValidFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iRsvdInvCheckRsvdQtyValidExt.RsvdInvCheckRsvdQtyValidSp(Item,
                                                                         Whse,
                                                                         Loc,
                                                                         Lot,
                                                                         QtyRsvd,
                                                                         QtyRsvdOld,
                                                                         ref oInfobar,
                                                                         ImportDocId);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RsvdInvPostDeleteSp(decimal? RsvdNum,
                                               string Item,
                                               string Whse,
                                               string Loc,
                                               string Lot,
                                               decimal? QtyRsvd,
                                               string RefNum,
                                               short? RefLine,
                                               short? RefRelease,
                                               byte? ItLotTracked,
                                               byte? ItSerialTracked,
                                               string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRsvdInvPostDeleteExt = new RsvdInvPostDeleteFactory().Create(appDb);

                int Severity = iRsvdInvPostDeleteExt.RsvdInvPostDeleteSp(RsvdNum,
                                                                  Item,
                                                                  Whse,
                                                                  Loc,
                                                                  Lot,
                                                                  QtyRsvd,
                                                                  RefNum,
                                                                  RefLine,
                                                                  RefRelease,
                                                                  ItLotTracked,
                                                                  ItSerialTracked,
                                                                  ImportDocId);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RsvdInvPostSaveSp(string Item,
                                             string Whse,
                                             string Loc,
                                             string Lot,
                                             decimal? QtyRsvd,
                                             decimal? OldQtyRsvd,
                                             string RefNum,
                                             short? RefLine,
                                             short? RefRelease,
                                             byte? ItLotTracked,
                                             ref string Infobar,
                                             string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRsvdInvPostSaveExt = new RsvdInvPostSaveFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iRsvdInvPostSaveExt.RsvdInvPostSaveSp(Item,
                                                                Whse,
                                                                Loc,
                                                                Lot,
                                                                QtyRsvd,
                                                                OldQtyRsvd,
                                                                RefNum,
                                                                RefLine,
                                                                RefRelease,
                                                                ItLotTracked,
                                                                ref oInfobar,
                                                                ImportDocId);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateCoReservationSp(decimal? RsvdNum,
                                                   string CoNum,
                                                   short? CoLine,
                                                   short? CoRelease,
                                                   string CoItem,
                                                   string CoWhse,
                                                   string CoLoc,
                                                   byte? CoLotTracked,
                                                   string CoLot,
                                                   decimal? CoQty,
                                                   string CoUM,
                                                   string CoCustNum,
                                                   ref string Infobar,
                                                   string ImportDocId,
                                                   byte? TaxFreeMatl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateCoReservationExt = new ValidateCoReservationFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iValidateCoReservationExt.ValidateCoReservationSp(RsvdNum,
                                                                      CoNum,
                                                                      CoLine,
                                                                      CoRelease,
                                                                      CoItem,
                                                                      CoWhse,
                                                                      CoLoc,
                                                                      CoLotTracked,
                                                                      CoLot,
                                                                      CoQty,
                                                                      CoUM,
                                                                      CoCustNum,
                                                                      ref oInfobar,
                                                                      ImportDocId,
                                                                      TaxFreeMatl);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateCoRsvdQtySp(string PCoNum,
            int? PCoLine,
            int? PCoRelease,
            decimal? PQtyRsvd,
            decimal? PQtyRsvdOld,
            ref string PromptMsg,
            ref string PromptButtons,
            ref string Infobar)
        {
            var iValidateCoRsvdQtyExt = new ValidateCoRsvdQtyFactory().Create(this, true);

            var result = iValidateCoRsvdQtyExt.ValidateCoRsvdQtySp(PCoNum,
                PCoLine,
                PCoRelease,
                PQtyRsvd,
                PQtyRsvdOld,
                PromptMsg,
                PromptButtons,
                Infobar);

            PromptMsg = result.PromptMsg;
            PromptButtons = result.PromptButtons;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CoResValidateQtySp(string PItem,
            decimal? PQtyRsvd,
            [Optional, DefaultParameterValue(0)] decimal? PQtyRsvdOld,
            ref string PUM,
            string PCoNum,
            int? PLotTracked,
            string PCurWhse,
            string PLot,
            string PLoc,
            ref string Infobar,
            string PImportDocId,
            int? PTaxFreeMatl)
        {
            var iCoResValidateQtyExt = new CoResValidateQtyFactory().Create(this, true);

            var result = iCoResValidateQtyExt.CoResValidateQtySp(PItem,
                PQtyRsvd,
                PQtyRsvdOld,
                PUM,
                PCoNum,
                PLotTracked,
                PCurWhse,
                PLot,
                PLoc,
                Infobar,
                PImportDocId,
                PTaxFreeMatl);

            PUM = result.PUM;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }
    }
}
