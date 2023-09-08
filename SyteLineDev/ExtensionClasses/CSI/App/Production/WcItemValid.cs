//PROJECT NAME: CSIProduct
//CLASS NAME: WcItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IWcItemValid
    {
        int WcItemValidSp(ref string Item,
                          string Whse,
                          ref string TItemDesc,
                          ref byte? TSerTracked,
                          ref byte? TLotTracked,
                          ref string TLoc,
                          ref string TLot,
                          ref string TUM,
                          ref double? UomConvFactor,
                          ref byte? NonInvItem,
                          ref string PromptMsg,
                          ref string PromptButtons,
                          ref string Infobar,
                          ref decimal? MatlCost,
                          ref decimal? LbrCost,
                          ref decimal? FovhdCost,
                          ref decimal? VovhdCost,
                          ref decimal? OutCost,
                          ref byte? TrackPieces,
                          ref string DimensionGroup,
                          ref string TrxRestrictCode);
    }

    public class WcItemValid : IWcItemValid
    {
        readonly IApplicationDB appDB;

        public WcItemValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WcItemValidSp(ref string Item,
                                 string Whse,
                                 ref string TItemDesc,
                                 ref byte? TSerTracked,
                                 ref byte? TLotTracked,
                                 ref string TLoc,
                                 ref string TLot,
                                 ref string TUM,
                                 ref double? UomConvFactor,
                                 ref byte? NonInvItem,
                                 ref string PromptMsg,
                                 ref string PromptButtons,
                                 ref string Infobar,
                                 ref decimal? MatlCost,
                                 ref decimal? LbrCost,
                                 ref decimal? FovhdCost,
                                 ref decimal? VovhdCost,
                                 ref decimal? OutCost,
                                 ref byte? TrackPieces,
                                 ref string DimensionGroup,
                                 ref string TrxRestrictCode)
        {
            ItemType _Item = Item;
            WhseType _Whse = Whse;
            DescriptionType _TItemDesc = TItemDesc;
            ListYesNoType _TSerTracked = TSerTracked;
            ListYesNoType _TLotTracked = TLotTracked;
            LocType _TLoc = TLoc;
            LotType _TLot = TLot;
            UMType _TUM = TUM;
            UMConvFactorType _UomConvFactor = UomConvFactor;
            ListYesNoType _NonInvItem = NonInvItem;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;
            CostPrcType _MatlCost = MatlCost;
            CostPrcType _LbrCost = LbrCost;
            CostPrcType _FovhdCost = FovhdCost;
            CostPrcType _VovhdCost = VovhdCost;
            CostPrcType _OutCost = OutCost;
            ListYesNoType _TrackPieces = TrackPieces;
            AttributeGroupType _DimensionGroup = DimensionGroup;
            TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WcItemValidSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TItemDesc", _TItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TSerTracked", _TSerTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TLotTracked", _TLotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonInvItem", _NonInvItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TrackPieces", _TrackPieces, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DimensionGroup", _DimensionGroup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Item = _Item;
                TItemDesc = _TItemDesc;
                TSerTracked = _TSerTracked;
                TLotTracked = _TLotTracked;
                TLoc = _TLoc;
                TLot = _TLot;
                TUM = _TUM;
                UomConvFactor = _UomConvFactor;
                NonInvItem = _NonInvItem;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;
                MatlCost = _MatlCost;
                LbrCost = _LbrCost;
                FovhdCost = _FovhdCost;
                VovhdCost = _VovhdCost;
                OutCost = _OutCost;
                TrackPieces = _TrackPieces;
                DimensionGroup = _DimensionGroup;
                TrxRestrictCode = _TrxRestrictCode;

                return Severity;
            }
        }
    }
}
