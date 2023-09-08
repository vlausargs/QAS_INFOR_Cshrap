using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLItems
    {
        int FetchNextLotSp(string Item, string Prefix, ref string Infobar, ref string Key,  string Site);
        int MisReceiptItemWhseGetCostValuesSp(string CurWhse, string Item, ref decimal? MatlCost, ref decimal? LbrCost, ref decimal? FovhdCost, ref decimal? VovhdCost, ref decimal? OutCost, ref decimal? UnitCost, ref string Infobar,  string UM,  ref decimal? MatlCostConv,  ref decimal? LbrCostConv,  ref decimal? FovhdCostConv,  ref decimal? VovhdCostConv,  ref decimal? OutCostConv,  ref decimal? UnitCostConv);
        int ObsSlowSp(string Item, [DefaultParameterValue((byte)1)] byte? WarnIfSlowMoving, [DefaultParameterValue((byte)0)] byte? ErrorIfSlowMoving, [DefaultParameterValue((byte)0)] byte? WarnIfObsolete, [DefaultParameterValue((byte)1)] byte? ErrorIfObsolete, ref string Infobar,  ref string Prompt,  ref string PromptButtons,  string Site);
    }
}