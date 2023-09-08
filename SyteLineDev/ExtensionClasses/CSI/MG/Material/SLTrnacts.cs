//PROJECT NAME: MaterialExt
//CLASS NAME: SLTrnacts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTrnacts")]
    public class SLTrnacts : ExtensionClassBase, IExtFTSLTrnacts
    {


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CombinedXferTrnNumValidSp(string TrnNum,
                                                     ref short? TrnLine,
                                                     ref string FromSite,
                                                     ref string FromWhse,
                                                     ref string ToSite,
                                                     ref string ToWhse,
                                                     ref string Infobar,
                                                     ref string TransferExportType,
                                                     ref byte? UseExistingSerials,
                                                     ref string FobSite)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCombinedXferTrnNumValidExt = new CombinedXferTrnNumValidFactory().Create(appDb);

                TrnLineType oTrnLine = TrnLine;
                SiteType oFromSite = FromSite;
                WhseType oFromWhse = FromWhse;
                SiteType oToSite = ToSite;
                WhseType oToWhse = ToWhse;
                InfobarType oInfobar = Infobar;
                ListDirectIndirectNonExportType oTransferExportType = TransferExportType;
                ListYesNoType oUseExistingSerials = UseExistingSerials;
                SiteType oFobSite = FobSite;

                int Severity = iCombinedXferTrnNumValidExt.CombinedXferTrnNumValidSp(TrnNum,
                                                                       ref oTrnLine,
                                                                       ref oFromSite,
                                                                       ref oFromWhse,
                                                                       ref oToSite,
                                                                       ref oToWhse,
                                                                       ref oInfobar,
                                                                       ref oTransferExportType,
                                                                       ref oUseExistingSerials,
                                                                       ref oFobSite);

                TrnLine = oTrnLine;
                FromSite = oFromSite;
                FromWhse = oFromWhse;
                ToSite = oToSite;
                ToWhse = oToWhse;
                Infobar = oInfobar;
                TransferExportType = oTransferExportType;
                UseExistingSerials = oUseExistingSerials;
                FobSite = oFobSite;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CombineXferUMValidSp(string UM,
                                                string TrnNum,
                                                short? TrnLine,
                                                ref double? UomConvFactor,
                                                ref decimal? TQtyShipped,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCombineXferUMValidExt = new CombineXferUMValidFactory().Create(appDb);

                UMConvFactorType oUomConvFactor = UomConvFactor;
                QtyUnitType oTQtyShipped = TQtyShipped;
                InfobarType oInfobar = Infobar;

                int Severity = iCombineXferUMValidExt.CombineXferUMValidSp(UM,
                                                                  TrnNum,
                                                                  TrnLine,
                                                                  ref oUomConvFactor,
                                                                  ref oTQtyShipped,
                                                                  ref oInfobar);

                UomConvFactor = oUomConvFactor;
                TQtyShipped = oTQtyShipped;
                Infobar = oInfobar;


                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_CheckVendorSp(string ToNum,
                                      short? ToLine,
                                      short? ToRelease,
                                      string Item,
                                      string VendNum,
                                      decimal? QtyToShip,
                                      string ToitemUM,
                                      ref byte? NeedsQC,
                                      ref byte? HoldCertificateRequired,
                                      ref string Messages,
                                      ref byte? Status,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_CheckVendorExt = new RSQC_CheckVendorFactory().Create(appDb);

                ListYesNoType oNeedsQC = NeedsQC;
                ListYesNoType oHoldCertificateRequired = HoldCertificateRequired;
                InfobarType oMessages = Messages;
                ListYesNoType oStatus = Status;
                InfobarType oInfobar = Infobar;

                int Severity = iRSQC_CheckVendorExt.RSQC_CheckVendorSp(ToNum,
                                                                       ToLine,
                                                                       ToRelease,
                                                                       Item,
                                                                       VendNum,
                                                                       QtyToShip,
                                                                       ToitemUM,
                                                                       ref oNeedsQC,
                                                                       ref oHoldCertificateRequired,
                                                                       ref oMessages,
                                                                       ref oStatus,
                                                                       ref oInfobar);

                NeedsQC = oNeedsQC;
                HoldCertificateRequired = oHoldCertificateRequired;
                Messages = oMessages;
                Status = oStatus;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_QCCheckTO2Sp(string i_ToNum,
                                     short? i_ToLine,
                                     string i_ToRelease,
                                     decimal? i_Qty,
                                     string i_Loc,
                                     string i_Lot,
                                     int? i_Seq,
                                     string i_Whse,
                                     string i_Site,
                                     ref string o_Loc,
                                     ref int? o_IsQC,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_QCCheckTO2Ext = new RSQC_QCCheckTO2Factory().Create(appDb);

                LocType oo_Loc = o_Loc;
                IntType oo_IsQC = o_IsQC;
                InfobarType oInfobar = Infobar;

                int Severity = iRSQC_QCCheckTO2Ext.RSQC_QCCheckTO2Sp(i_ToNum,
                                                                     i_ToLine,
                                                                     i_ToRelease,
                                                                     i_Qty,
                                                                     i_Loc,
                                                                     i_Lot,
                                                                     i_Seq,
                                                                     i_Whse,
                                                                     i_Site,
                                                                     ref oo_Loc,
                                                                     ref oo_IsQC,
                                                                     ref oInfobar);

                o_Loc = oo_Loc;
                o_IsQC = oo_IsQC;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_QCCheckTOSp(string i_ToNum,
                                    short? i_ToLine,
                                    string i_ToRelease,
                                    decimal? i_Qty,
                                    string i_Loc,
                                    string i_Lot,
                                    int? i_Seq,
                                    string i_Whse,
                                    string i_Site,
                                    ref string o_Loc,
                                    ref int? o_IsQC,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_QCCheckTOExt = new RSQC_QCCheckTOFactory().Create(appDb);

                LocType oo_Loc = o_Loc;
                IntType oo_IsQC = o_IsQC;
                InfobarType oInfobar = Infobar;

                int Severity = iRSQC_QCCheckTOExt.RSQC_QCCheckTOSp(i_ToNum,
                                                                   i_ToLine,
                                                                   i_ToRelease,
                                                                   i_Qty,
                                                                   i_Loc,
                                                                   i_Lot,
                                                                   i_Seq,
                                                                   i_Whse,
                                                                   i_Site,
                                                                   ref oo_Loc,
                                                                   ref oo_IsQC,
                                                                   ref oInfobar);

                o_Loc = oo_Loc;
                o_IsQC = oo_IsQC;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_ShipUpdateCOC2Sp(string CoNum,
                                         short? CoLine,
                                         short? CoRelease,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_ShipUpdateCOC2Ext = new RSQC_ShipUpdateCOC2Factory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iRSQC_ShipUpdateCOC2Ext.RSQC_ShipUpdateCOC2Sp(CoNum,
                                                                             CoLine,
                                                                             CoRelease,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ShipTransferProcessASNSp(string TrnNum,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iShipTransferProcessASNExt = new ShipTransferProcessASNFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iShipTransferProcessASNExt.ShipTransferProcessASNSp(TrnNum,
                                                                                   ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SloclotSp(string Site,
                             string Item,
                             string Whse,
                             string Loc,
                             byte? LotTracked,
                             string RefNum,
                             short? RefLine,
                             short? RefRelease,
                             string RefType,
                             ref string Lot,
                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSloclotExt = new SloclotFactory().Create(appDb);

                LotType oLot = Lot;
                InfobarType oInfobar = Infobar;

                int Severity = iSloclotExt.SloclotSp(Site,
                                                     Item,
                                                     Whse,
                                                     Loc,
                                                     LotTracked,
                                                     RefNum,
                                                     RefLine,
                                                     RefRelease,
                                                     RefType,
                                                     ref oLot,
                                                     ref oInfobar);

                Lot = oLot;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TlocChkPostSp(string Site,
                                 string Whse,
                                 string Item,
                                 string Loc,
                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTlocChkPostExt = new TlocChkPostFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iTlocChkPostExt.TlocChkPostSp(Site,
                                                             Whse,
                                                             Item,
                                                             Loc,
                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TlocChkSp(string Site,
                             string Whse,
                             string Item,
                             string Loc,
                             ref string PromptMsg,
                             ref string PromptButtons,
                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTlocChkExt = new TlocChkFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iTlocChkExt.TlocChkSp(Site,
                                                     Whse,
                                                     Item,
                                                     Loc,
                                                     ref oPromptMsg,
                                                     ref oPromptButtons,
                                                     ref oInfobar);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TransferDateChkSp(string TSite,
                                     DateTime? TDate,
                                     ref string PromptMsg1,
                                     ref string PromptButtons1,
                                     ref string PromptMsg2,
                                     ref string PromptButtons2,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTransferDateChkExt = new TransferDateChkFactory().Create(appDb);

                InfobarType oPromptMsg1 = PromptMsg1;
                InfobarType oPromptButtons1 = PromptButtons1;
                InfobarType oPromptMsg2 = PromptMsg2;
                InfobarType oPromptButtons2 = PromptButtons2;
                InfobarType oInfobar = Infobar;

                int Severity = iTransferDateChkExt.TransferDateChkSp(TSite,
                                                                     TDate,
                                                                     ref oPromptMsg1,
                                                                     ref oPromptButtons1,
                                                                     ref oPromptMsg2,
                                                                     ref oPromptButtons2,
                                                                     ref oInfobar);

                PromptMsg1 = oPromptMsg1;
                PromptButtons1 = oPromptButtons1;
                PromptMsg2 = oPromptMsg2;
                PromptButtons2 = oPromptButtons2;
                Infobar = oInfobar;


                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrnShipLocChangeSp(string TrnNum,
                                      short? TrnLine,
                                      string Item,
                                      string Whse,
                                      string Loc,
                                      double? UmConvFactor,
                                      ref string Lot,
                                      ref decimal? QtyToShip,
                                      ref decimal? QtyOnHandConv,
                                      ref decimal? QtyOnHand,
                                      ref string Infobar,
                                      string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrnShipLocChangeExt = new TrnShipLocChangeFactory().Create(appDb);

                LotType oLot = Lot;
                QtyUnitType oQtyToShip = QtyToShip;
                QtyUnitType oQtyOnHandConv = QtyOnHandConv;
                QtyUnitType oQtyOnHand = QtyOnHand;
                InfobarType oInfobar = Infobar;

                int Severity = iTrnShipLocChangeExt.TrnShipLocChangeSp(TrnNum,
                                                                       TrnLine,
                                                                       Item,
                                                                       Whse,
                                                                       Loc,
                                                                       UmConvFactor,
                                                                       ref oLot,
                                                                       ref oQtyToShip,
                                                                       ref oQtyOnHandConv,
                                                                       ref oQtyOnHand,
                                                                       ref oInfobar,
                                                                       ImportDocId);

                Lot = oLot;
                QtyToShip = oQtyToShip;
                QtyOnHandConv = oQtyOnHandConv;
                QtyOnHand = oQtyOnHand;
                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrnShipTrnNumValidSp(ref string TrnNum,
                                        ref string FromSite,
                                        ref string ToSite,
                                        ref string FromWhse,
                                        ref string ToWhse,
                                        ref string FobSite,
                                        ref string Infobar,
                                        ref string TransferExportType,
                                        ref byte? CtrlbyExtWMS)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrnShipTrnNumValidExt = new TrnShipTrnNumValidFactory().Create(appDb);

                TrnNumType oTrnNum = TrnNum;
                SiteType oFromSite = FromSite;
                SiteType oToSite = ToSite;
                WhseType oFromWhse = FromWhse;
                WhseType oToWhse = ToWhse;
                SiteType oFobSite = FobSite;
                InfobarType oInfobar = Infobar;
                ListDirectIndirectNonExportType oTransferExportType = TransferExportType;
                ListYesNoType oCtrlbyExtWMS = CtrlbyExtWMS;

                int Severity = iTrnShipTrnNumValidExt.TrnShipTrnNumValidSp(ref oTrnNum,
                                                                           ref oFromSite,
                                                                           ref oToSite,
                                                                           ref oFromWhse,
                                                                           ref oToWhse,
                                                                           ref oFobSite,
                                                                           ref oInfobar,
                                                                           ref oTransferExportType,
                                                                           ref oCtrlbyExtWMS);

                TrnNum = oTrnNum;
                FromSite = oFromSite;
                ToSite = oToSite;
                FromWhse = oFromWhse;
                ToWhse = oToWhse;
                FobSite = oFobSite;
                Infobar = oInfobar;
                TransferExportType = oTransferExportType;
                CtrlbyExtWMS = oCtrlbyExtWMS;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrrcvFromLotValidSp(string PSite,
                                       string PWhse,
                                       string PItem,
                                       string PTrnLoc,
                                       string PTrnLot,
                                       string PTrnNum,
                                       short? PTrnLine,
                                       byte? PReturn,
                                       double? PUomConvFactor,
                                       ref string ToLot,
                                       ref decimal? PQty,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrrcvFromLotValidExt = new TrrcvFromLotValidFactory().Create(appDb);

                LotType oToLot = ToLot;
                QtyUnitType oPQty = PQty;
                InfobarType oInfobar = Infobar;

                int Severity = iTrrcvFromLotValidExt.TrrcvFromLotValidSp(PSite,
                                                                         PWhse,
                                                                         PItem,
                                                                         PTrnLoc,
                                                                         PTrnLot,
                                                                         PTrnNum,
                                                                         PTrnLine,
                                                                         PReturn,
                                                                         PUomConvFactor,
                                                                         ref oToLot,
                                                                         ref oPQty,
                                                                         ref oInfobar);

                ToLot = oToLot;
                PQty = oPQty;
                Infobar = oInfobar;


                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrrcvTrnRptLstValidSp(string TrnNum,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrrcvTrnRptLstValidExt = new TrrcvTrnRptLstValidFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iTrrcvTrnRptLstValidExt.TrrcvTrnRptLstValidSp(TrnNum,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }




        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RvallocSp(string Site,
                             string Whse,
                             string Item,
                             string Loc,
                             ref string PromptMsg,
                             ref string PromptButtons,
                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRvallocExt = new RvallocFactory().Create(appDb);

                int Severity = iRvallocExt.RvallocSp(Site,
                                                     Whse,
                                                     Item,
                                                     Loc,
                                                     ref PromptMsg,
                                                     ref PromptButtons,
                                                     ref Infobar);

                return Severity;
            }
        }




        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrnShipLocValidSp(string Item,
                                     string Whse,
                                     string Site,
                                     ref string Loc,
                                     ref byte? ItemLocQuestionAsked,
                                     ref string PromptMsg,
                                     ref string PromptButtons,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrnShipLocValidExt = new TrnShipLocValidFactory().Create(appDb);

                int Severity = iTrnShipLocValidExt.TrnShipLocValidSp(Item,
                                                                     Whse,
                                                                     Site,
                                                                     ref Loc,
                                                                     ref ItemLocQuestionAsked,
                                                                     ref PromptMsg,
                                                                     ref PromptButtons,
                                                                     ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrrcvTrnLineValidSp(string TrnNum,
                                       short? TrnLine,
                                       string FromSite,
                                       string FromWhse,
                                       string ToSite,
                                       string ToWhse,
                                       ref string Item,
                                       ref string ItemDescription,
                                       ref string UM,
                                       ref decimal? PQty,
                                       ref decimal? QtyReq,
                                       ref decimal? QtyReqConv,
                                       ref decimal? QtyShipped,
                                       ref decimal? QtyShippedConv,
                                       ref decimal? QtyReceived,
                                       ref decimal? QtyReceivedConv,
                                       ref double? ConvFactor,
                                       ref string FromLoc,
                                       ref string FromLot,
                                       ref byte? ToLotTracked,
                                       ref byte? ToSerialTracked,
                                       ref byte? FromLotTracked,
                                       ref byte? FromSerialTracked,
                                       ref byte? UseExistingSerials,
                                       ref string SerialPrefix,
                                       ref byte? ExpandSerial,
                                       ref string ToLoc,
                                       ref string ToLot,
                                       ref decimal? UnitFreightCostConv,
                                       ref decimal? UnitDutyCostConv,
                                       ref decimal? UnitBrokerageCostConv,
                                       ref decimal? UnitInsuranceCostConv,
                                       ref decimal? UnitLocFrtCostConv,
                                       ref DateTime? RcvDate,
                                       ref string PromptMsg,
                                       ref string PromptButtons,
                                       ref string Infobar,
                                       ref string ImportDocId,
                                       ref byte? TaxFreeMatl,
                                       ref string FromLotAttributeGroup,
                                       ref string ToLotAttributeGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrrcvTrnLineValidExt = new TrrcvTrnLineValidFactory().Create(appDb);

                int Severity = iTrrcvTrnLineValidExt.TrrcvTrnLineValidSp(TrnNum,
                                                                         TrnLine,
                                                                         FromSite,
                                                                         FromWhse,
                                                                         ToSite,
                                                                         ToWhse,
                                                                         ref Item,
                                                                         ref ItemDescription,
                                                                         ref UM,
                                                                         ref PQty,
                                                                         ref QtyReq,
                                                                         ref QtyReqConv,
                                                                         ref QtyShipped,
                                                                         ref QtyShippedConv,
                                                                         ref QtyReceived,
                                                                         ref QtyReceivedConv,
                                                                         ref ConvFactor,
                                                                         ref FromLoc,
                                                                         ref FromLot,
                                                                         ref ToLotTracked,
                                                                         ref ToSerialTracked,
                                                                         ref FromLotTracked,
                                                                         ref FromSerialTracked,
                                                                         ref UseExistingSerials,
                                                                         ref SerialPrefix,
                                                                         ref ExpandSerial,
                                                                         ref ToLoc,
                                                                         ref ToLot,
                                                                         ref UnitFreightCostConv,
                                                                         ref UnitDutyCostConv,
                                                                         ref UnitBrokerageCostConv,
                                                                         ref UnitInsuranceCostConv,
                                                                         ref UnitLocFrtCostConv,
                                                                         ref RcvDate,
                                                                         ref PromptMsg,
                                                                         ref PromptButtons,
                                                                         ref Infobar,
                                                                         ref ImportDocId,
                                                                         ref TaxFreeMatl,
                                                                         ref FromLotAttributeGroup,
                                                                         ref ToLotAttributeGroup);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TrrcvTrnNumValidSp(ref string TrnNum,
                                      ref string FromSite,
                                      ref string ToSite,
                                      ref string FobSite,
                                      ref string FromWhse,
                                      ref string ToWhse,
                                      ref string Stat,
                                      ref string Site,
                                      ref string Whse,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTrrcvTrnNumValidExt = new TrrcvTrnNumValidFactory().Create(appDb);

                int Severity = iTrrcvTrnNumValidExt.TrrcvTrnNumValidSp(ref TrnNum,
                                                                       ref FromSite,
                                                                       ref ToSite,
                                                                       ref FobSite,
                                                                       ref FromWhse,
                                                                       ref ToWhse,
                                                                       ref Stat,
                                                                       ref Site,
                                                                       ref Whse,
                                                                       ref Infobar);

                return Severity;
            }
        }













		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TransferOrderShpRcvSp(string TrnNum,
		                                           [Optional, DefaultParameterValue("T")] string TOLineItemStatus,
		DateTime? SchedShipDateStarting,
		DateTime? SchedShipDateEnding,
		DateTime? SchedRcvdDateStarting,
		DateTime? SchedRcvdDateEnding,
		string CallType,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_TransferOrderShpRcvExt = new CLM_TransferOrderShpRcvFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_TransferOrderShpRcvExt.CLM_TransferOrderShpRcvSp(TrnNum,
				                                                                   TOLineItemStatus,
				                                                                   SchedShipDateStarting,
				                                                                   SchedShipDateEnding,
				                                                                   SchedRcvdDateStarting,
				                                                                   SchedRcvdDateEnding,
				                                                                   CallType,
				                                                                   FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferQtyValidSp(decimal? TQtyShipped,
		                                 string TUM,
		                                 byte? ItemSerialTracked,
		                                 string TrnNum,
		                                 short? TrnLine,
		                                 string FromSite,
		                                 string ToSite,
		                                 string FromWhse,
		                                 string ToWhse,
		                                 string FromLoc,
		                                 string ToLoc,
		                                 string FromLot,
		                                 string ToLot,
		                                 string Item,
		                                 ref string QtyGtPromptMsg,
		                                 ref string QtyGtPromptButtons,
		                                 ref string DetailPromptMsg,
		                                 ref string DetailPromptButtons,
		                                 ref string Detail2PromptMsg,
		                                 ref string Detail2PromptButtons,
		                                 ref string Infobar,
		                                 string ImportDocId,
		                                 ref byte? CallForm,
		                                 [Optional] ref DateTime? RecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCombineXferQtyValidExt = new CombineXferQtyValidFactory().Create(appDb);
				
				var result = iCombineXferQtyValidExt.CombineXferQtyValidSp(TQtyShipped,
				                                                           TUM,
				                                                           ItemSerialTracked,
				                                                           TrnNum,
				                                                           TrnLine,
				                                                           FromSite,
				                                                           ToSite,
				                                                           FromWhse,
				                                                           ToWhse,
				                                                           FromLoc,
				                                                           ToLoc,
				                                                           FromLot,
				                                                           ToLot,
				                                                           Item,
				                                                           QtyGtPromptMsg,
				                                                           QtyGtPromptButtons,
				                                                           DetailPromptMsg,
				                                                           DetailPromptButtons,
				                                                           Detail2PromptMsg,
				                                                           Detail2PromptButtons,
				                                                           Infobar,
				                                                           ImportDocId,
				                                                           CallForm,
				                                                           RecordDate);
				
				int Severity = result.ReturnCode.Value;
				QtyGtPromptMsg = result.QtyGtPromptMsg;
				QtyGtPromptButtons = result.QtyGtPromptButtons;
				DetailPromptMsg = result.DetailPromptMsg;
				DetailPromptButtons = result.DetailPromptButtons;
				Detail2PromptMsg = result.Detail2PromptMsg;
				Detail2PromptButtons = result.Detail2PromptButtons;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferShipReceiveSetVarsSp(string SET,
		                                           string TrnNum,
		                                           short? TrnLine,
		                                           string Item,
		                                           string FromSite,
		                                           string FromWhse,
		                                           string FromLoc,
		                                           string FromLot,
		                                           string ToSite,
		                                           string ToWhse,
		                                           string ToLoc,
		                                           string ToLot,
		                                           decimal? TQtyShipped,
		                                           string TUM,
		                                           DateTime? TShipDate,
		                                           string Title,
		                                           string RemoteSiteLotProcess,
		                                           byte? UseExistingSerials,
		                                           string SerialPrefix,
		                                           ref string Infobar,
		                                           string ImportDocId,
		                                           string ExportDocId,
		                                           string ReasonCode,
		                                           [Optional] byte? MoveZeroCostItem,
		                                           [Optional] DateTime? RecordDate,
		                                           [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCombineXferShipReceiveSetVarsExt = new CombineXferShipReceiveSetVarsFactory().Create(appDb);
				
				var result = iCombineXferShipReceiveSetVarsExt.CombineXferShipReceiveSetVarsSp(SET,
				                                                                               TrnNum,
				                                                                               TrnLine,
				                                                                               Item,
				                                                                               FromSite,
				                                                                               FromWhse,
				                                                                               FromLoc,
				                                                                               FromLot,
				                                                                               ToSite,
				                                                                               ToWhse,
				                                                                               ToLoc,
				                                                                               ToLot,
				                                                                               TQtyShipped,
				                                                                               TUM,
				                                                                               TShipDate,
				                                                                               Title,
				                                                                               RemoteSiteLotProcess,
				                                                                               UseExistingSerials,
				                                                                               SerialPrefix,
				                                                                               Infobar,
				                                                                               ImportDocId,
				                                                                               ExportDocId,
				                                                                               ReasonCode,
				                                                                               MoveZeroCostItem,
				                                                                               RecordDate,
				                                                                               DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LotAddPreSp(string Item,
		                       string Lot,
		                       ref string PromptMsg,
		                       ref string PromptButtons,
		                       [Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLotAddPreExt = new LotAddPreFactory().Create(appDb);
				
				var result = iLotAddPreExt.LotAddPreSp(Item,
				                                       Lot,
				                                       PromptMsg,
				                                       PromptButtons,
				                                       Site);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RloclotSp(string Site,
		                     string Item,
		                     string Whse,
		                     string Loc,
		                     string RefNum,
		                     short? RefLine,
		                     short? RefRelease,
		                     string RefType,
		                     byte? LotTracked,
		                     ref string Lot,
		                     ref string Infobar,
		                     [Optional] string Acct)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRloclotExt = new RloclotFactory().Create(appDb);
				
				var result = iRloclotExt.RloclotSp(Site,
				                                   Item,
				                                   Whse,
				                                   Loc,
				                                   RefNum,
				                                   RefLine,
				                                   RefRelease,
				                                   RefType,
				                                   LotTracked,
				                                   Lot,
				                                   Infobar,
				                                   Acct);
				
				int Severity = result.ReturnCode.Value;
				Lot = result.Lot;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SvallotSp(string Whse,
		                     string Item,
		                     string Loc,
		                     string Lot,
		                     string Action,
		                     [Optional, DefaultParameterValue((byte)0)] byte? NoPerm,
		[Optional] string Title,
		ref string PromptAddMsg,
		ref string PromptAddButtons,
		ref string PromptExpLotMsg,
		ref string PromptExpLotButtons,
		ref string Infobar,
		[Optional] byte? JobPreassignLots,
		[Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSvallotExt = new SvallotFactory().Create(appDb);
				
				var result = iSvallotExt.SvallotSp(Whse,
				                                   Item,
				                                   Loc,
				                                   Lot,
				                                   Action,
				                                   NoPerm,
				                                   Title,
				                                   PromptAddMsg,
				                                   PromptAddButtons,
				                                   PromptExpLotMsg,
				                                   PromptExpLotButtons,
				                                   Infobar,
				                                   JobPreassignLots,
				                                   TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				PromptAddMsg = result.PromptAddMsg;
				PromptAddButtons = result.PromptAddButtons;
				PromptExpLotMsg = result.PromptExpLotMsg;
				PromptExpLotButtons = result.PromptExpLotButtons;
				Infobar = result.Infobar;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferOrderShipSetVarsSp(string SET,
		                                      string TrnNum,
		                                      string TransferFromSite,
		                                      string TransferToSite,
		                                      string TransferFobSite,
		                                      string TransferFromWhse,
		                                      string TransferToWhse,
		                                      short? TrnLine,
		                                      decimal? TQtyShipped,
		                                      string TUM,
		                                      DateTime? TShipDate,
		                                      string TFromLoc,
		                                      string TFromLot,
		                                      string TToLot,
		                                      string Title,
		                                      string RemoteSiteLotProcess,
		                                      byte? UseExistingSerials,
		                                      string SerialPrefix,
		                                      string PReasonCode,
		                                      ref string Infobar,
		                                      string TImportDocId,
		                                      string ExportDocId,
		                                      [Optional] byte? MoveZeroCostItem,
		                                      [Optional] DateTime? RecordDate,
		                                      [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTransferOrderShipSetVarsExt = new TransferOrderShipSetVarsFactory().Create(appDb);
				
				var result = iTransferOrderShipSetVarsExt.TransferOrderShipSetVarsSp(SET,
				                                                                     TrnNum,
				                                                                     TransferFromSite,
				                                                                     TransferToSite,
				                                                                     TransferFobSite,
				                                                                     TransferFromWhse,
				                                                                     TransferToWhse,
				                                                                     TrnLine,
				                                                                     TQtyShipped,
				                                                                     TUM,
				                                                                     TShipDate,
				                                                                     TFromLoc,
				                                                                     TFromLot,
				                                                                     TToLot,
				                                                                     Title,
				                                                                     RemoteSiteLotProcess,
				                                                                     UseExistingSerials,
				                                                                     SerialPrefix,
				                                                                     PReasonCode,
				                                                                     Infobar,
				                                                                     TImportDocId,
				                                                                     ExportDocId,
				                                                                     MoveZeroCostItem,
				                                                                     RecordDate,
				                                                                     DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrnLossQtyValidSp(string TrnNum,
		                             short? TrnLine,
		                             double? UmConvFactor,
		                             decimal? QtyToLoss,
		                             string FromLoc,
		                             string FromLot,
		                             string ToLot,
		                             ref string PromptButtons1,
		                             ref string PromptMsg1,
		                             ref string PromptButtons2,
		                             ref string PromptMsg2,
		                             ref string PromptButtons3,
		                             ref string PromptMsg3,
		                             ref string Infobar,
		                             string ImportDocId,
		                             ref byte? CallForm,
		                             [Optional] ref DateTime? RecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrnLossQtyValidExt = new TrnLossQtyValidFactory().Create(appDb);
				
				var result = iTrnLossQtyValidExt.TrnLossQtyValidSp(TrnNum,
				                                                   TrnLine,
				                                                   UmConvFactor,
				                                                   QtyToLoss,
				                                                   FromLoc,
				                                                   FromLot,
				                                                   ToLot,
				                                                   PromptButtons1,
				                                                   PromptMsg1,
				                                                   PromptButtons2,
				                                                   PromptMsg2,
				                                                   PromptButtons3,
				                                                   PromptMsg3,
				                                                   Infobar,
				                                                   ImportDocId,
				                                                   CallForm,
				                                                   RecordDate);
				
				int Severity = result.ReturnCode.Value;
				PromptButtons1 = result.PromptButtons1;
				PromptMsg1 = result.PromptMsg1;
				PromptButtons2 = result.PromptButtons2;
				PromptMsg2 = result.PromptMsg2;
				PromptButtons3 = result.PromptButtons3;
				PromptMsg3 = result.PromptMsg3;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrnShipQtyValidSp(string TrnNum,
		                             short? TrnLine,
		                             double? UmConvFactor,
		                             decimal? QtyToShip,
		                             string FromLoc,
		                             string FromLot,
		                             string ToLot,
		                             ref string PromptButtons1,
		                             ref string PromptMsg1,
		                             ref string PromptButtons2,
		                             ref string PromptMsg2,
		                             ref string PromptButtons3,
		                             ref string PromptMsg3,
		                             ref string Infobar,
		                             string ImportDocId,
		                             ref byte? CallForm,
		                             [Optional] ref DateTime? RecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrnShipQtyValidExt = new TrnShipQtyValidFactory().Create(appDb);
				
				var result = iTrnShipQtyValidExt.TrnShipQtyValidSp(TrnNum,
				                                                   TrnLine,
				                                                   UmConvFactor,
				                                                   QtyToShip,
				                                                   FromLoc,
				                                                   FromLot,
				                                                   ToLot,
				                                                   PromptButtons1,
				                                                   PromptMsg1,
				                                                   PromptButtons2,
				                                                   PromptMsg2,
				                                                   PromptButtons3,
				                                                   PromptMsg3,
				                                                   Infobar,
				                                                   ImportDocId,
				                                                   CallForm,
				                                                   RecordDate);
				
				int Severity = result.ReturnCode.Value;
				PromptButtons1 = result.PromptButtons1;
				PromptMsg1 = result.PromptMsg1;
				PromptButtons2 = result.PromptButtons2;
				PromptMsg2 = result.PromptMsg2;
				PromptButtons3 = result.PromptButtons3;
				PromptMsg3 = result.PromptMsg3;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrrcvQtyValidSp(string TrnNum,
		                           short? TrnLine,
		                           string FromSite,
		                           string ToSite,
		                           string FromWhse,
		                           string ToWhse,
		                           double? UmConvFactor,
		                           decimal? QtyReceived,
		                           string TrnLoc,
		                           string FromLot,
		                           string ToLoc,
		                           string ToLot,
		                           string Item,
		                           ref string PromptMsg1,
		                           ref string PromptButtons1,
		                           ref string PromptMsg2,
		                           ref string PromptButtons2,
		                           ref string PromptMsg3,
		                           ref string PromptButtons3,
		                           ref string Infobar,
		                           string ImportDocId,
		                           ref byte? CallForm,
		                           [Optional] ref DateTime? RecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrrcvQtyValidExt = new TrrcvQtyValidFactory().Create(appDb);
				
				var result = iTrrcvQtyValidExt.TrrcvQtyValidSp(TrnNum,
				                                               TrnLine,
				                                               FromSite,
				                                               ToSite,
				                                               FromWhse,
				                                               ToWhse,
				                                               UmConvFactor,
				                                               QtyReceived,
				                                               TrnLoc,
				                                               FromLot,
				                                               ToLoc,
				                                               ToLot,
				                                               Item,
				                                               PromptMsg1,
				                                               PromptButtons1,
				                                               PromptMsg2,
				                                               PromptButtons2,
				                                               PromptMsg3,
				                                               PromptButtons3,
				                                               Infobar,
				                                               ImportDocId,
				                                               CallForm,
				                                               RecordDate);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg1 = result.PromptMsg1;
				PromptButtons1 = result.PromptButtons1;
				PromptMsg2 = result.PromptMsg2;
				PromptButtons2 = result.PromptButtons2;
				PromptMsg3 = result.PromptMsg3;
				PromptButtons3 = result.PromptButtons3;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcTrnShipQtySp(string TrnNum,
		int? TrnLine,
		string Item,
		string Whse,
		string Lot,
		string Loc,
		decimal? UmConvFactor,
		ref decimal? QtyToShip,
		ref decimal? QtyOnHandConv,
		ref decimal? QtyOnHand,
		ref string Infobar,
		string ImportDocId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalcTrnShipQtyExt = new CalcTrnShipQtyFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalcTrnShipQtyExt.CalcTrnShipQtySp(TrnNum,
				TrnLine,
				Item,
				Whse,
				Lot,
				Loc,
				UmConvFactor,
				QtyToShip,
				QtyOnHandConv,
				QtyOnHand,
				Infobar,
				ImportDocId);
				
				int Severity = result.ReturnCode.Value;
				QtyToShip = result.QtyToShip;
				QtyOnHandConv = result.QtyOnHandConv;
				QtyOnHand = result.QtyOnHand;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferLocValidSp(string Whse,
		string Item,
		string Loc,
		string TrnNum,
		int? TrnLine,
		decimal? UomConvFactor,
		ref decimal? TQtyShipped,
		ref decimal? TQtyOnhand,
		ref string Lot,
		ref string Infobar,
		ref string ImportDocId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCombineXferLocValidExt = new CombineXferLocValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCombineXferLocValidExt.CombineXferLocValidSp(Whse,
				Item,
				Loc,
				TrnNum,
				TrnLine,
				UomConvFactor,
				TQtyShipped,
				TQtyOnhand,
				Lot,
				Infobar,
				ImportDocId);
				
				int Severity = result.ReturnCode.Value;
				TQtyShipped = result.TQtyShipped;
				TQtyOnhand = result.TQtyOnhand;
				Lot = result.Lot;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferLotValidSp(string Whse,
		string Item,
		string Loc,
		string TrnNum,
		int? TrnLine,
		decimal? UomConvFactor,
		string Lot,
		ref decimal? TQtyShipped,
		ref decimal? TQtyOnhand,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCombineXferLotValidExt = new CombineXferLotValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCombineXferLotValidExt.CombineXferLotValidSp(Whse,
				Item,
				Loc,
				TrnNum,
				TrnLine,
				UomConvFactor,
				Lot,
				TQtyShipped,
				TQtyOnhand,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TQtyShipped = result.TQtyShipped;
				TQtyOnhand = result.TQtyOnhand;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferTrnLineValidSp(string TrnNum,
		int? TrnLine,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		ref string Item,
		ref string ItemDescription,
		ref string UM,
		ref decimal? QtyReqConv,
		ref decimal? QtyShippedConv,
		ref decimal? ConvFactor,
		ref string FromLoc,
		ref string FromLot,
		ref int? LotTracked,
		ref int? RemoteLotTracked,
		ref string RemoteSiteLotProcess,
		ref int? SerialTracked,
		ref int? RemoteSerialTracked,
		ref int? UseExistingSerials,
		ref string RemoteSerialPrefix,
		ref int? RemoteExpandSerial,
		ref string ToLoc,
		ref decimal? UnitCost,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		ref string ImportDocId,
		ref int? TaxFreeMatl,
		[Optional] ref int? TrackPieces,
		[Optional] ref string DimensionGroup,
		[Optional] ref int? UbToTrackPieces,
		[Optional] ref string UbToDimentionGroup,
		[Optional] ref string UbFromLotAttributeGroup,
		[Optional] ref string UbToLotAttributeGroup,
		[Optional] ref string RemoteLotPrefix,
		[Optional] ref int? PreassignLots,
		[Optional] ref int? PreassignSerials,
		[Optional] ref decimal? UbQtyOnHandConv)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCombineXferTrnLineValidExt = new CombineXferTrnLineValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCombineXferTrnLineValidExt.CombineXferTrnLineValidSp(TrnNum,
				TrnLine,
				FromSite,
				FromWhse,
				ToSite,
				ToWhse,
				Item,
				ItemDescription,
				UM,
				QtyReqConv,
				QtyShippedConv,
				ConvFactor,
				FromLoc,
				FromLot,
				LotTracked,
				RemoteLotTracked,
				RemoteSiteLotProcess,
				SerialTracked,
				RemoteSerialTracked,
				UseExistingSerials,
				RemoteSerialPrefix,
				RemoteExpandSerial,
				ToLoc,
				UnitCost,
				PromptMsg,
				PromptButtons,
				Infobar,
				ImportDocId,
				TaxFreeMatl,
				TrackPieces,
				DimensionGroup,
				UbToTrackPieces,
				UbToDimentionGroup,
				UbFromLotAttributeGroup,
				UbToLotAttributeGroup,
				RemoteLotPrefix,
				PreassignLots,
				PreassignSerials,
				UbQtyOnHandConv);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				ItemDescription = result.ItemDescription;
				UM = result.UM;
				QtyReqConv = result.QtyReqConv;
				QtyShippedConv = result.QtyShippedConv;
				ConvFactor = result.ConvFactor;
				FromLoc = result.FromLoc;
				FromLot = result.FromLot;
				LotTracked = result.LotTracked;
				RemoteLotTracked = result.RemoteLotTracked;
				RemoteSiteLotProcess = result.RemoteSiteLotProcess;
				SerialTracked = result.SerialTracked;
				RemoteSerialTracked = result.RemoteSerialTracked;
				UseExistingSerials = result.UseExistingSerials;
				RemoteSerialPrefix = result.RemoteSerialPrefix;
				RemoteExpandSerial = result.RemoteExpandSerial;
				ToLoc = result.ToLoc;
				UnitCost = result.UnitCost;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				TaxFreeMatl = result.TaxFreeMatl;
				TrackPieces = result.TrackPieces;
				DimensionGroup = result.DimensionGroup;
				UbToTrackPieces = result.UbToTrackPieces;
				UbToDimentionGroup = result.UbToDimentionGroup;
				UbFromLotAttributeGroup = result.UbFromLotAttributeGroup;
				UbToLotAttributeGroup = result.UbToLotAttributeGroup;
				RemoteLotPrefix = result.RemoteLotPrefix;
				PreassignLots = result.PreassignLots;
				PreassignSerials = result.PreassignSerials;
				UbQtyOnHandConv = result.UbQtyOnHandConv;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetMaxSerialNumSiteSp(string SerNumPrefix,
		[Optional] string Site,
		ref string SerNum,
		string Item)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetMaxSerialNumSiteExt = new GetMaxSerialNumSiteFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetMaxSerialNumSiteExt.GetMaxSerialNumSiteSp(SerNumPrefix,
				Site,
				SerNum,
				Item);
				
				int Severity = result.ReturnCode.Value;
				SerNum = result.SerNum;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextTrnShipLineSp(string TrnNum,
		ref int? TrnLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextTrnShipLineExt = new GetNextTrnShipLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextTrnShipLineExt.GetNextTrnShipLineSp(TrnNum,
				TrnLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TrnLine = result.TrnLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextTrrcvLineSp(string TrnNum,
		ref int? TrnLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextTrrcvLineExt = new GetNextTrrcvLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextTrrcvLineExt.GetNextTrrcvLineSp(TrnNum,
				TrnLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TrnLine = result.TrnLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemFlSp(string PSite,
		string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnNum,
		int? PTrnLine,
		ref string PTrnLot,
		ref decimal? PUomConvFactor,
		ref decimal? PQty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemFlExt = new ItemFlFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemFlExt.ItemFlSp(PSite,
				PWhse,
				PItem,
				PTrnLoc,
				PTrnNum,
				PTrnLine,
				PTrnLot,
				PUomConvFactor,
				PQty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PTrnLot = result.PTrnLot;
				PUomConvFactor = result.PUomConvFactor;
				PQty = result.PQty;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemVlSp(string PSite,
		string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnLot,
		int? PReturn,
		ref decimal? PQty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemVlExt = new ItemVlFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemVlExt.ItemVlSp(PSite,
				PWhse,
				PItem,
				PTrnLoc,
				PTrnLot,
				PReturn,
				PQty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PQty = result.PQty;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferOrderReceiveSetVarsSp(string SET,
		string TrnNum,
		int? TrnLine,
		string Item,
		string FromSite,
		string FromWhse,
		string TrnLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string FobSite,
		string ToLoc,
		string ToLot,
		decimal? TQtyReceived,
		string TUM,
		DateTime? TTransDate,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		string Title,
		int? UseExistingSerials,
		string SerialPrefix,
		string PReasonCode,
		ref string Infobar,
		[Optional] string ImportDocId,
		[Optional] int? MoveZeroCostItem,
		[Optional] DateTime? RecordDate,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTransferOrderReceiveSetVarsExt = new TransferOrderReceiveSetVarsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTransferOrderReceiveSetVarsExt.TransferOrderReceiveSetVarsSp(SET,
				TrnNum,
				TrnLine,
				Item,
				FromSite,
				FromWhse,
				TrnLoc,
				FromLot,
				ToSite,
				ToWhse,
				FobSite,
				ToLoc,
				ToLot,
				TQtyReceived,
				TUM,
				TTransDate,
				UnitFreightCostConv,
				UnitDutyCostConv,
				UnitBrokerageCostConv,
				UnitInsuranceCostConv,
				UnitLocFrtCostConv,
				Title,
				UseExistingSerials,
				SerialPrefix,
				PReasonCode,
				Infobar,
				ImportDocId,
				MoveZeroCostItem,
				RecordDate,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferOrderReceiveSp(string TrnNum,
		int? TrnLine,
		string Item,
		string FromSite,
		string FromWhse,
		string TrnLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string FobSite,
		string ToLoc,
		string ToLot,
		decimal? TQtyReceived,
		string TUM,
		DateTime? TTransDate,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		string Title,
		int? UseExistingSerials,
		string SerialPrefix,
		string PReasonCode,
		ref string Infobar,
		[Optional] string ImportDocId,
		[Optional] int? MoveZeroCostItem,
		[Optional] string EmpNum,
		[Optional] DateTime? RecordDate,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTransferOrderReceiveExt = new TransferOrderReceiveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTransferOrderReceiveExt.TransferOrderReceiveSp(TrnNum,
				TrnLine,
				Item,
				FromSite,
				FromWhse,
				TrnLoc,
				FromLot,
				ToSite,
				ToWhse,
				FobSite,
				ToLoc,
				ToLot,
				TQtyReceived,
				TUM,
				TTransDate,
				UnitFreightCostConv,
				UnitDutyCostConv,
				UnitBrokerageCostConv,
				UnitInsuranceCostConv,
				UnitLocFrtCostConv,
				Title,
				UseExistingSerials,
				SerialPrefix,
				PReasonCode,
				Infobar,
				ImportDocId,
				MoveZeroCostItem,
				EmpNum,
				RecordDate,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransferOrderShipSp(string TrnNum,
		string TransferFromSite,
		string TransferToSite,
		string TransferFobSite,
		string TransferFromWhse,
		string TransferToWhse,
		int? TrnLine,
		decimal? TQtyShipped,
		string TUM,
		DateTime? TShipDate,
		string TFromLoc,
		string TFromLot,
		string TToLot,
		string Title,
		string RemoteSiteLotProcess,
		int? UseExistingSerials,
		string SerialPrefix,
		string PReasonCode,
		ref string Infobar,
		string TImportDocId,
		string ExportDocId,
		[Optional] int? MoveZeroCostItem,
		[Optional] string EmpNum,
		[Optional] DateTime? RecordDate,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTransferOrderShipExt = new TransferOrderShipFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTransferOrderShipExt.TransferOrderShipSp(TrnNum,
				TransferFromSite,
				TransferToSite,
				TransferFobSite,
				TransferFromWhse,
				TransferToWhse,
				TrnLine,
				TQtyShipped,
				TUM,
				TShipDate,
				TFromLoc,
				TFromLot,
				TToLot,
				Title,
				RemoteSiteLotProcess,
				UseExistingSerials,
				SerialPrefix,
				PReasonCode,
				Infobar,
				TImportDocId,
				ExportDocId,
				MoveZeroCostItem,
				EmpNum,
				RecordDate,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrcombSerErrorSp(string Site,
                string Item,
                string SerNum,
                byte? UseExisting,
                [Optional, DefaultParameterValue((byte)1)] byte? SelectFlag,
                string FromSite,
                string ToSite,
                byte? FromSerialTracked,
                byte? ToSerialTracked,
                decimal? QtyShip,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTrcombSerErrorExt = new TrcombSerErrorFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTrcombSerErrorExt.TrcombSerErrorSp(Site,
				Item,
				SerNum,
				UseExisting,
				SelectFlag,
				FromSite,
				ToSite,
				FromSerialTracked,
				ToSerialTracked,
				QtyShip,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrrcvSerErrorSp(string Site,
                string Item,
                string SerNum,
                byte? UseExisting,
                [Optional, DefaultParameterValue((byte)1)] byte? SelectFlag,
                string FromSite,
                string ToSite,
                string FobSite,
                byte? FromSerialTracked,
                byte? ToSerialTracked,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar,
                decimal? QtyReceived)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTrrcvSerErrorExt = new TrrcvSerErrorFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTrrcvSerErrorExt.TrrcvSerErrorSp(Site,
				Item,
				SerNum,
				UseExisting,
				SelectFlag,
				FromSite,
				ToSite,
				FobSite,
				FromSerialTracked,
				ToSerialTracked,
				PromptMsg,
				PromptButtons,
				Infobar,
				QtyReceived);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AvailTrnLineSp(string TrnNum,
		ref int? TrnLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAvailTrnLineExt = new AvailTrnLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAvailTrnLineExt.AvailTrnLineSp(TrnNum,
				TrnLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TrnLine = result.TrnLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferDateValidSp(string FromSite,
		string ToSite,
		DateTime? InDate,
		ref string Infobar,
		ref string PromptMsg1,
		ref string PromptButtons1,
		ref string PromptMsg2,
		ref string PromptButtons2)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCombineXferDateValidExt = new CombineXferDateValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCombineXferDateValidExt.CombineXferDateValidSp(FromSite,
				ToSite,
				InDate,
				Infobar,
				PromptMsg1,
				PromptButtons1,
				PromptMsg2,
				PromptButtons2);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg1 = result.PromptMsg1;
				PromptButtons1 = result.PromptButtons1;
				PromptMsg2 = result.PromptMsg2;
				PromptButtons2 = result.PromptButtons2;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CombineXferShipReceiveSp(string TrnNum,
		int? TrnLine,
		string Item,
		string FromSite,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string ToLoc,
		string ToLot,
		decimal? TQtyShipped,
		string TUM,
		DateTime? TShipDate,
		string Title,
		string RemoteSiteLotProcess,
		int? UseExistingSerials,
		string SerialPrefix,
		ref string Infobar,
		string ImportDocId,
		string ExportDocId,
		string ReasonCode,
		[Optional] int? MoveZeroCostItem,
		[Optional] DateTime? RecordDate,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCombineXferShipReceiveExt = new CombineXferShipReceiveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCombineXferShipReceiveExt.CombineXferShipReceiveSp(TrnNum,
				TrnLine,
				Item,
				FromSite,
				FromWhse,
				FromLoc,
				FromLot,
				ToSite,
				ToWhse,
				ToLoc,
				ToLot,
				TQtyShipped,
				TUM,
				TShipDate,
				Title,
				RemoteSiteLotProcess,
				UseExistingSerials,
				SerialPrefix,
				Infobar,
				ImportDocId,
				ExportDocId,
				ReasonCode,
				MoveZeroCostItem,
				RecordDate,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemSerialPrefixSp(string pItem,
		string pSite,
		ref string pItemSerialPrefix,
		ref string rInfobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemSerialPrefixExt = new GetItemSerialPrefixFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemSerialPrefixExt.GetItemSerialPrefixSp(pItem,
				pSite,
				pItemSerialPrefix,
				rInfobar);
				
				int Severity = result.ReturnCode.Value;
				pItemSerialPrefix = result.pItemSerialPrefix;
				rInfobar = result.rInfobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemTransitInfoSp(string TrnNum,
		int? TrnLine,
		ref string Site,
		ref string Whse,
		ref string Item,
		ref string ItemDescription,
		ref string UM,
		ref decimal? UmConvFactor,
		ref string FromLoc,
		ref string FromLot,
		ref string TrnLoc,
		ref string ToLot,
		ref int? FromLotTracked,
		ref int? ToLotTracked,
		ref string RemoteSiteLotProcess,
		ref int? FromSerialTracked,
		ref int? ToSerialTracked,
		ref int? UseExistingSerials,
		ref string RemoteSerialPrefix,
		ref int? RemoteExpandSerial,
		ref decimal? QtyToShip,
		ref decimal? QtyOnHand,
		ref decimal? QtyOnHandConv,
		ref decimal? QtyReq,
		ref decimal? QtyReqConv,
		ref decimal? QtyShipped,
		ref decimal? QtyShippedConv,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		ref string ImportDocId,
		ref int? TaxFreeMatl,
		[Optional] ref DateTime? RecordDate,
		ref int? TrackPieces)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemTransitInfoExt = new GetItemTransitInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemTransitInfoExt.GetItemTransitInfoSp(TrnNum,
				TrnLine,
				Site,
				Whse,
				Item,
				ItemDescription,
				UM,
				UmConvFactor,
				FromLoc,
				FromLot,
				TrnLoc,
				ToLot,
				FromLotTracked,
				ToLotTracked,
				RemoteSiteLotProcess,
				FromSerialTracked,
				ToSerialTracked,
				UseExistingSerials,
				RemoteSerialPrefix,
				RemoteExpandSerial,
				QtyToShip,
				QtyOnHand,
				QtyOnHandConv,
				QtyReq,
				QtyReqConv,
				QtyShipped,
				QtyShippedConv,
				PromptMsg,
				PromptButtons,
				Infobar,
				ImportDocId,
				TaxFreeMatl,
				RecordDate,
				TrackPieces);
				
				int Severity = result.ReturnCode.Value;
				Site = result.Site;
				Whse = result.Whse;
				Item = result.Item;
				ItemDescription = result.ItemDescription;
				UM = result.UM;
				UmConvFactor = result.UmConvFactor;
				FromLoc = result.FromLoc;
				FromLot = result.FromLot;
				TrnLoc = result.TrnLoc;
				ToLot = result.ToLot;
				FromLotTracked = result.FromLotTracked;
				ToLotTracked = result.ToLotTracked;
				RemoteSiteLotProcess = result.RemoteSiteLotProcess;
				FromSerialTracked = result.FromSerialTracked;
				ToSerialTracked = result.ToSerialTracked;
				UseExistingSerials = result.UseExistingSerials;
				RemoteSerialPrefix = result.RemoteSerialPrefix;
				RemoteExpandSerial = result.RemoteExpandSerial;
				QtyToShip = result.QtyToShip;
				QtyOnHand = result.QtyOnHand;
				QtyOnHandConv = result.QtyOnHandConv;
				QtyReq = result.QtyReq;
				QtyReqConv = result.QtyReqConv;
				QtyShipped = result.QtyShipped;
				QtyShippedConv = result.QtyShippedConv;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				TaxFreeMatl = result.TaxFreeMatl;
				RecordDate = result.RecordDate;
				TrackPieces = result.TrackPieces;
				return Severity;
			}
		}
    }
}
