//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvTrnLineValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrrcvTrnLineValid
    {
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
    }

    public class TrrcvTrnLineValid : ITrrcvTrnLineValid
    {
        readonly IApplicationDB appDB;

        public TrrcvTrnLineValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

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
            TrnNumType _TrnNum = TrnNum;
            TrnLineType _TrnLine = TrnLine;
            SiteType _FromSite = FromSite;
            WhseType _FromWhse = FromWhse;
            SiteType _ToSite = ToSite;
            WhseType _ToWhse = ToWhse;
            ItemType _Item = Item;
            DescriptionType _ItemDescription = ItemDescription;
            UMType _UM = UM;
            QtyUnitType _PQty = PQty;
            QtyUnitType _QtyReq = QtyReq;
            QtyUnitType _QtyReqConv = QtyReqConv;
            QtyUnitType _QtyShipped = QtyShipped;
            QtyUnitType _QtyShippedConv = QtyShippedConv;
            QtyUnitType _QtyReceived = QtyReceived;
            QtyUnitType _QtyReceivedConv = QtyReceivedConv;
            UMConvFactorType _ConvFactor = ConvFactor;
            LocType _FromLoc = FromLoc;
            LotType _FromLot = FromLot;
            ListYesNoType _ToLotTracked = ToLotTracked;
            ListYesNoType _ToSerialTracked = ToSerialTracked;
            ListYesNoType _FromLotTracked = FromLotTracked;
            ListYesNoType _FromSerialTracked = FromSerialTracked;
            ListYesNoType _UseExistingSerials = UseExistingSerials;
            SerialPrefixType _SerialPrefix = SerialPrefix;
            ListYesNoType _ExpandSerial = ExpandSerial;
            LocType _ToLoc = ToLoc;
            LotType _ToLot = ToLot;
            CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
            CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
            CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
            CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
            CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
            DateType _RcvDate = RcvDate;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;
            ImportDocIdType _ImportDocId = ImportDocId;
            ListYesNoType _TaxFreeMatl = TaxFreeMatl;
            AttributeGroupType _FromLotAttributeGroup = FromLotAttributeGroup;
            AttributeGroupType _ToLotAttributeGroup = ToLotAttributeGroup;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrrcvTrnLineValidSp";

                appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReqConv", _QtyReqConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReceivedConv", _QtyReceivedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToLotTracked", _ToLotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSerialTracked", _ToSerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromLotTracked", _FromLotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromSerialTracked", _FromSerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExpandSerial", _ExpandSerial, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RcvDate", _RcvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromLotAttributeGroup", _FromLotAttributeGroup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToLotAttributeGroup", _ToLotAttributeGroup, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Item = _Item;
                ItemDescription = _ItemDescription;
                UM = _UM;
                PQty = _PQty;
                QtyReq = _QtyReq;
                QtyReqConv = _QtyReqConv;
                QtyShipped = _QtyShipped;
                QtyShippedConv = _QtyShippedConv;
                QtyReceived = _QtyReceived;
                QtyReceivedConv = _QtyReceivedConv;
                ConvFactor = _ConvFactor;
                FromLoc = _FromLoc;
                FromLot = _FromLot;
                ToLotTracked = _ToLotTracked;
                ToSerialTracked = _ToSerialTracked;
                FromLotTracked = _FromLotTracked;
                FromSerialTracked = _FromSerialTracked;
                UseExistingSerials = _UseExistingSerials;
                SerialPrefix = _SerialPrefix;
                ExpandSerial = _ExpandSerial;
                ToLoc = _ToLoc;
                ToLot = _ToLot;
                UnitFreightCostConv = _UnitFreightCostConv;
                UnitDutyCostConv = _UnitDutyCostConv;
                UnitBrokerageCostConv = _UnitBrokerageCostConv;
                UnitInsuranceCostConv = _UnitInsuranceCostConv;
                UnitLocFrtCostConv = _UnitLocFrtCostConv;
                RcvDate = _RcvDate;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;
                ImportDocId = _ImportDocId;
                TaxFreeMatl = _TaxFreeMatl;
                FromLotAttributeGroup = _FromLotAttributeGroup;
                ToLotAttributeGroup = _ToLotAttributeGroup;

                return Severity;
            }
        }
    }
}
