
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLPoItems
    {

        int CreatePoReceiveEsigSp(ref string Infobar); 

        int EvaluateAutoVoucherSp(ref decimal? MaterialAmount,
                ref byte? FixedRate,
                ref string CurrCode,
                ref decimal? ExchangeRate,
                ref byte? IncludeTaxInCost,
                ref string AutoVoucherMethod,
                ref byte? AutoVoucher,
                ref Guid? PProcessID,
                ref string TermsCode,
                ref short? CanAutoGenerateVoucher,
                ref string Infobar,
                [Optional] DateTime? TransDate); 

        int POReceiveQtyConvWrapperSp(decimal? UbQtyReceivedConv,
                decimal? UbQtyReturnedConv,
                decimal? UnitMatCostConv,
                decimal? UnitBrokerageCostConv,
                decimal? UnitDutyCostConv,
                decimal? UnitFreightCostConv,
                decimal? UnitInsuranceCostConv,
                decimal? UnitLocFrtCostConv,
                ref decimal? ItemCostConv,
                string Item,
                string UM,
                string VendNum,
                ref decimal? UbQtyReceived,
                ref decimal? UbQtyReturned,
                ref decimal? UnitMatCost,
                ref decimal? UnitBrokerageCost,
                ref decimal? UnitDutyCost,
                ref decimal? UnitFreightCost,
                ref decimal? UnitInsuranceCost,
                ref decimal? UnitLocFrtCost,
                ref decimal? ItemCost,
                ref string Infobar); 

        int POReceiveUMChangedSp(ref decimal? UnitMatCostConv,
                ref decimal? UnitBrokerageCostConv,
                ref decimal? UnitDutyCostConv,
                ref decimal? UnitFreightCostConv,
                ref decimal? ItemCostConv,
                ref decimal? QtyOrdered,
                ref decimal? QtyReceived,
                ref decimal? QtyRejected,
                string Item,
                string OldUM,
                string NewUM,
                string VendNum,
                ref string Infobar); 

        int POReceivingCleanupSp(); 

        int POReceivingConvertCostSp(string PoVendNum,
                [Optional] string PoNum,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitDutyCost,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitFreightCost,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitBrokerageCost,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitInsuranceCost,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitLocFrtCost,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitDutyCostConv,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitFreightCostConv,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitBrokerageCostConv,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitInsuranceCostConv,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitLocFrtCostConv,
                [Optional, DefaultParameterValue(0)] ref decimal? LUnitDutyCost,
                [Optional, DefaultParameterValue(0)] ref decimal? LUnitFreightCost,
                [Optional, DefaultParameterValue(0)] ref decimal? LUnitBrokerageCost,
                [Optional, DefaultParameterValue(0)] ref decimal? LUnitInsuranceCost,
                [Optional, DefaultParameterValue(0)] ref decimal? LUnitLocFrtCost,
                [Optional] decimal? DutyExchRate,
                [Optional] decimal? FreightExchRate,
                [Optional] decimal? BrokerageExchRate,
                [Optional] decimal? InsuranceExchRate,
                [Optional] decimal? LocFrtExchRate,
                [Optional] string DutyCurrCode,
                [Optional] string FreightCurrCode,
                [Optional] string BrokerageCurrCode,
                [Optional] string InsuranceCurrCode,
                [Optional] string LocFrtCurrCode,
                [Optional, DefaultParameterValue(0)] ref decimal? ItemCost,
                [Optional, DefaultParameterValue(0)] ref decimal? ItemCostConv,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitMatCost,
                [Optional, DefaultParameterValue(0)] ref decimal? UnitMatCostConv,
                [Optional] string RequiredCostTypes,
                [Optional, DefaultParameterValue("D")] string ChangedCostType,
                [Optional] string UM,
                [Optional] string Item,
                ref string Infobar,
                [Optional] DateTime? TransDate); 

        int POReceivingLoopSp(ref int? FirstSequenceWithError,
                ref string Infobar,
                [Optional] ref string PromptButtons,
                [Optional] string DocumentNum,
                [Optional, DefaultParameterValue((byte)0)] byte? ParentWantsReturnCode); 

        int RSQC_QCCheck2Sp(string i_PoNum,
                int? i_PoLine,
                string i_PoRelease,
                decimal? i_Qty,
                string i_Loc,
                string i_Lot,
                int? i_Seq,
                string i_Whse,
                ref string o_Loc,
                ref int? o_IsQC,
                ref int? o_IsCertified,
                ref string Infobar); 

    }
}
    
