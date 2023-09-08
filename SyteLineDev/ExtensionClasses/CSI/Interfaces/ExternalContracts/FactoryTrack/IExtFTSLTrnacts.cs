
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLTrnacts
    {

        int CombineXferUMValidSp(string UM,
                string TrnNum,
                short? TrnLine,
                ref double? UomConvFactor,
                ref decimal? TQtyShipped,
                ref string Infobar); 

        int GetItemSerialPrefixSp(string pItem,
                string pSite,
                ref string pItemSerialPrefix,
                ref string rInfobar); 

        int GetItemTransitInfoSp(string TrnNum,
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
                ref int? TrackPieces); 

        int ItemFlSp(string PSite,
                string PWhse,
                string PItem,
                string PTrnLoc,
                string PTrnNum,
                int? PTrnLine,
                ref string PTrnLot,
                ref decimal? PUomConvFactor,
                ref decimal? PQty,
                ref string Infobar); 

        int RvallocSp(string Site,
                string Whse,
                string Item,
                string Loc,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar); 

        int SvallotSp(string Whse,
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
                [Optional] ref string TrxRestrictCode); 

        int TlocChkPostSp(string Site,
                string Whse,
                string Item,
                string Loc,
                ref string Infobar); 

        int TlocChkSp(string Site,
                string Whse,
                string Item,
                string Loc,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar); 

        int TrcombSerErrorSp(string Site,
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
                ref string Infobar); 

        int TrnShipLocChangeSp(string TrnNum,
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
                string ImportDocId); 

        int TrnShipLocValidSp(string Item,
                string Whse,
                string Site,
                ref string Loc,
                ref byte? ItemLocQuestionAsked,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar); 

        int TrnShipQtyValidSp(string TrnNum,
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
                [Optional] ref DateTime? RecordDate); 

        int TrnShipTrnNumValidSp(ref string TrnNum,
                ref string FromSite,
                ref string ToSite,
                ref string FromWhse,
                ref string ToWhse,
                ref string FobSite,
                ref string Infobar,
                ref string TransferExportType,
                ref byte? CtrlbyExtWMS); 

        int TrrcvQtyValidSp(string TrnNum,
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
                [Optional] ref DateTime? RecordDate); 

        int TrrcvSerErrorSp(string Site,
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
                decimal? QtyReceived); 

        int TrrcvTrnLineValidSp(string TrnNum,
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
                ref string ToLotAttributeGroup); 

        int TrrcvTrnNumValidSp(ref string TrnNum,
                ref string FromSite,
                ref string ToSite,
                ref string FobSite,
                ref string FromWhse,
                ref string ToWhse,
                ref string Stat,
                ref string Site,
                ref string Whse,
                ref string Infobar); 

    }
}
    
