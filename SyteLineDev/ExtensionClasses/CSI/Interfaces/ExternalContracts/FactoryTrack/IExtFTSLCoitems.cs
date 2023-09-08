using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLCoitems
    {
        int GetItemInfoSp(ref string Item, ref string Description, ref string UM, ref int? SerialTracked, ref string Revision, ref string DrawingNbr, ref string CostType, ref string PMTCode, ref decimal? CurMatCost, ref decimal? CurMatCostConv, ref decimal? CurFreightCost, ref decimal? CurFreightCostConv, ref decimal? CurDutyCost, ref decimal? CurDutyCostConv, ref decimal? CurBrokerageCost, ref decimal? CurBrokerageCostConv, ref decimal? CurInsuranceCost, ref decimal? CurInsuranceCostConv, ref decimal? CurLocFrtCost, ref decimal? CurLocFrtCostConv, ref string CommCode, ref string Origin, ref decimal? UnitWeight, ref string TaxCode1, ref string TaxCode2, ref int? ItemExists, ref int? SupplQtyReq, ref decimal? SupplQtyConvFactor, ref string PromptMsg, ref string Infobar, string Site, ref int? LotTracked,  ref int? PreassignLots,  ref int? PreassignSerials, ref string LotPrefix, ref string SerialPrefix,  string Whse, [DefaultParameterValue(0)] ref int? IsOpenNonInvForm);
    }
}