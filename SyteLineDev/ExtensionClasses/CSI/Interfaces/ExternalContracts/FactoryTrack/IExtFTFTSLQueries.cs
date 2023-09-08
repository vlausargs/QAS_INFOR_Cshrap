
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTFTSLQueries
    {

        int CLM_FTSLItemAndVendorItemCheckSp(string PoReceiptType,
                string PoNum,
                string VendorNum,
                string GrnNum,
                string GrnLine,
                string VendorItem,
                ref string InfoBar); 

        int FTDeleteSelectedTmpserSp(Guid? SessionID,
                string SerNum,
                ref int? SerCount,
                ref string Infobar); 

        int FTDeleteTmpserSp(Guid? SessionID,
                ref string Infobar); 

        int FTGetSLVersionSiteInfoSp(string DefaultConfig,
                ref string Site,
                ref string SyteLineVersion); 

        int FTInsertIntoTmpserSp(Guid? SessionID,
                string Ser_num,
                string RefStr,
                string Item,
                byte? FlagInvCheck,
                ref string Infobar); 

        int FTSLCheckBackflushNeededSp(byte? BackflushByLot,
                [Optional, DefaultParameterValue("J")] string TransClass,
                decimal? TransNum,
                string Job,
                short? Suffix,
                int? OperNum,
                string JobItem,
                decimal? PhantomMulti,
                string PhantomUnits,
                decimal? PhantomScrap,
                DateTime? TransDate,
                string Whse,
                string Lot,
                decimal? RouteQtyComplete,
                decimal? RouteQtyScrapped,
                string EmpNum,
                ref string Infobar,
                ref int? BflushLotNeeded,
                ref int? BflushSerialNeeded); 

        int FTSLCheckQtyOnCloseJobSp(string Job,
                short? Suffix,
                int? OperNum,
                ref decimal? OperQtyComplete,
                ref decimal? OperQtyMoved,
                ref string Infobar); 

        int FTSLCheckQtyReceivedSp(string Job,
                short? Suffix,
                int? OperNum,
                ref decimal? OperQtyComplete,
                ref decimal? OperQtyScrapped,
                ref decimal? OperQtyReceived,
                ref string Infobar); 

        int FTSLGetAllJobInfoSp(string Job,
                short? Suffix,
                int? OperNum,
                string Loc,
                byte? ScrapConsider,
                string CallForm,
                [Optional, DefaultParameterValue((short)0)] short? TAImplement,
                string Empum,
                ref byte? CoProdcutMix,
                ref decimal? JobOpReceivedQty,
                ref decimal? QtyScrapped,
                ref decimal? QtyCompleted,
                ref decimal? QtyMoved,
                ref string WC,
                ref string WCDesc,
                ref byte? IsLastOperation,
                ref byte? Complete,
                ref string LocDesc,
                ref int? NextOper,
                ref decimal? JobBalance,
                ref string Item,
                ref string ItemDesc,
                ref string UOM,
                ref string UOMDesc,
                ref string JobStat,
                ref decimal? JobQty,
                ref string Whse,
                ref string WhseDesc,
                ref byte? LotTrack,
                ref byte? PreassignLot,
                ref string LotPrefix,
                ref byte? SerialTrack,
                ref string RefJob,
                ref string Shift,
                ref string Overhead,
                ref string LotAttrGroup,
                ref string ProductCode,
                ref string SerialPrefix); 

        int FTSLGetDefaultWCLocationSp(string Inputworkcenter,
                [Optional] string DefaultWhseRecLoc,
                ref string ReceiptLoc); 

        int FTSLGetItemConvQtyOnHandSp(string Whse,
                string Item,
                string Loc,
                string Lot,
                string UM,
                ref decimal? QtyOnHand,
                ref decimal? QtyReserved,
                ref string LocType,
                ref string Infobar); 

        int FTSLGetJobMatlItemSp([Optional] string Item,
                [Optional] string UM,
                [Optional] string Job,
                [Optional] short? Suffix,
                [Optional] int? OperNum,
                [Optional] short? Sequence,
                [Optional] byte? ExtByScrap,
                ref string item_UM,
                ref string item_Description,
                ref byte? ItemNotExists,
                ref double? UMConvFactor,
                ref byte? JobmatlNotExists,
                ref decimal? item_MatlCost,
                ref decimal? item_MatlCostConv,
                ref byte? item_SerialTracked,
                ref byte? item_LotTracked,
                ref decimal? ReqQty,
                ref decimal? ReqQtyConv,
                ref decimal? QtyIssued,
                ref decimal? QtyIssuedConv,
                ref string Infobar); 

        int FTSLGetJobTeamWorkSetDetailsSp(int? TaskCode,
                string OrderNumber,
                short? Suffix,
                int? Operation,
                string OrderType,
                ref int? TaskCodeName,
                ref string JobName,
                ref short? SuffixName,
                ref int? OperationName); 

        int FTSLGetLaborBackFlushStatusSp(string Type,
                string Job,
                short? Suffix,
                int? OperNum,
                string Item,
                string WC,
                ref byte? BackFlush,
                ref string Infobar); 

        int FTSLGetPSJITInfoSp(string Item,
                string PsNum,
                string Wc,
                int? OperNum,
                ref string ItemDescription,
                ref string ItemUM,
                ref int? ItemLotTracked,
                ref int? ItemSerialTracked,
                ref string WcDescription,
                ref string Whse,
                ref string Loc,
                ref decimal? QtyExpected,
                ref decimal? QtyCompleted,
                ref decimal? QtyScrapped,
                [Optional] ref string SymixJob,
                [Optional, DefaultParameterValue(0)] ref int? IsLastOper,
                ref decimal? QtyRemaining,
                ref DateTime? DueDate,
                [Optional, DefaultParameterValue(0)] ref int? SymixSuffix); 

        int FTSLGetSLTrnOrderPrefixSp(ref string TrnPrefix,
                ref string Infobar); 

        int FTSLGetTimeInfoSp(string EmpNum,
                [Optional, DefaultParameterValue((byte)0)] byte? TAImplement,
                string CallForm,
                string Job,
                short? Suffix,
                ref int? SLOperation,
                [Optional] ref string Infobar); 

        int FTSLICValidateResourceIdSp(short? DisplayResourceId,
                short? OnlyAllowResource,
                short? AllowMultiuseResource,
                short? TTImplemented,
                string Job,
                short? Suffix,
                int? Operation,
                string Rgid,
                string MachineResource,
                short? IsAllowMultiuseResource,
                ref string Infobar); 

        int FTSLItemPackageValidateSp(decimal? ShipmentId,
                string Item,
                ref string ItemDesc,
                ref string RefType,
                ref decimal? QtyPicked,
                ref string SerialTracked,
                ref string LotTracked,
                ref string ShipmentLine,
                ref string ShipmentSeq,
                ref string Lot,
                ref string Infobar); 

        int FTSLItemValidateSp(string Item,
                ref byte? TaxFreeMatl,
                [Optional] ref string ImportDocId,
                ref string InfoBar); 

        int FTSLJobEfficiencyCalculationSp(string Job,
                int? Suffix,
                int? Operation,
                DateTime? CurrDate,
                int? RefreshInterval,
                decimal? HighEfficiencyLevel,
                decimal? MediumEfficiencyLevel,
                DateTime? StartTime,
                ref int? Color); 

        int FTSLJobOpEmployeeSkillValidationSp(string EmpNum,
                string Job,
                int? Suffix,
                int? Operation,
                ref string Infobar,
                DateTime? PunchDate,
                string ERPQueryResponseString); 

        int FTSLJobOpTeamSkillValidationSp(string Team,
                string Job,
                int? Suffix,
                int? Operation,
                ref string Infobar,
                DateTime? PunchDate,
                string EmpNums,
                string ERPQueryResponseString); 

        int FTSLLabelCountSp(string LabelType,
                string Whse,
                string FromLoc,
                string ToLoc,
                string FromItem,
                string ToItem,
                string FromContainer,
                string ToContainer,
                string Type,
                string TaskType,
                string FromEmp,
                string ToEmp,
                ref int? Count,
                ref string Infobar); 

        int FTSLLotValidateSp(string Lot,
                string Item,
                string Whse,
                string Loc,
                ref decimal? QtyOnHand,
                ref decimal? QtyRsvd,
                ref decimal? QtyContained,
                ref string Infobar); 

        int FTSLMaterialCostSp(string Item,
                ref string Infobar); 

        int FTSLMatlGetInvparmsSp(ref string DefWhse,
                ref byte? NegFlag,
                ref string Infobar); 

        int FTSLPSVal10Sp(string PSItem,
                [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
                ref string PSNum,
                ref string UM,
                ref byte? LotTracked,
                ref byte? SerTracked,
                ref string Whse,
                ref string Wc,
                ref int? OperNum,
                ref string PSItemJob,
                ref short? PSItemSuffix,
                ref decimal? QtyComplete,
                ref string Infobar); 

        int FTSLQCSGetTestEachStatusSp(string RcvrNum,
                string Item,
                int? Sequence,
                decimal? ActualValue,
                ref int? PassStatus); 

        int FTSLRSQC_UpdateCOCSp(string CoNum,
                int? CoLine,
                int? CoRelease,
                decimal? QtyCOC,
                ref string Infobar); 

        int FTSLSerialCountSp(string SessionID,
                ref string Infobar); 

        int FTSLTAGetOverHeadMachineSp(string Ordernumber,
                int? Operation,
                short? Suffix,
                ref string OverHead,
                ref string Infobar); 

        int FTSLTAGetPartnerIdSp(string EmployeeNumber,
                string PartnerID,
                ref string Name); 

        int FTSLTAValidateResourceIdSp(short? OnlyAllowResource,
                short? AllowMultiuseResource,
                string Job,
                short? Suffix,
                string Operation,
                string Rgid,
                string MachineResource,
                ref string Infobar); 

        int FTSLValidateAllJobOperCompleteSp(string JobNum,
                short? Suffix,
                ref string Infobar); 

        int FTSLValidateComponentSp(string ValidateObject,
                string Job,
                short? Suffix,
                int? Oper,
                [Optional] ref string Infobar); 

        int FTSLValidateIssuedLotSp(string Lot,
                string Item,
                string Whse,
                string Loc,
                ref decimal? QtyOnHand,
                ref decimal? QtyRsvd,
                ref decimal? QtyContained,
                ref decimal? QtyAvailable,
                ref int? SLLotExp,
                byte? SLAllowNegInvFlag,
                byte? FTAllowNegInvFlag,
                ref string Infobar,
                [Optional, DefaultParameterValue((byte)0)] byte? FDALotTraceability,
                string Job,
                short? Suffix,
                short? Operation,
                ref string Uom); 

        int FTSLValidateIssueLotSp(string Lot,
                string Item,
                string Whse,
                string Loc,
                ref decimal? QtyOnHand,
                ref decimal? QtyRsvd,
                ref string Infobar); 

        int FTSLValidateItemNonInvItemSp(string Item,
                ref string ItemDesc,
                ref string IsInventory,
                ref string UM,
                ref byte? SerialTracked,
                ref byte? LotTracked,
                ref byte? GenerateLot,
                ref string Infobar); 

        int FTSLValidateJobLotSp(string Lot,
                string Item,
                string Job,
                int? SLLotExp,
                ref string Infobar); 

        int FTSLValidateJobMaterialExistSp(string Job,
                short? Suffix,
                int? OperNum,
                string Material,
                [Optional, DefaultParameterValue((byte)0)] byte? AllowNonBomItems,
                [Optional, DefaultParameterValue((byte)0)] byte? AllowNonInvItems,
                [Optional, DefaultParameterValue((byte)0)] byte? AdjustForScrap,
                ref string MaterialDesc,
                ref decimal? Sequence,
                ref string UM,
                ref byte? LotTracked,
                ref byte? SerialTracked,
                ref decimal? QtyRequired,
                ref decimal? QtyIssued,
                ref decimal? MaterialCost,
                ref byte? JobmatlNotExists,
                ref byte? ItemNotExists,
                ref byte? TaxFreeMatl,
                [Optional] ref string ImportDocId,
                ref string InfoBar); 

        int FTSLValidateLocationAcctSp(string Whse,
                string Loc,
                string Material,
                ref string InfoBar); 

        int FTSLValidateLotForAttributesSp(string Lot,
                string Item,
                ref Guid? LotRowPointer); 

        int FTSLValidateLotSp(string Lot,
                string Item,
                string Whse,
                string Loc,
                ref decimal? QtyOnHand,
                ref decimal? QtyRsvd,
                ref decimal? QtyContained,
                ref decimal? QtyAvailable,
                ref int? SLLotExp,
                byte? SLAllowNegInvFlag,
                byte? FTAllowNegInvFlag,
                ref string Infobar); 

        int FTSLValidateOperationDropDownSp(string CallForm,
                string Job,
                short? Suffix,
                int? Operation,
                [Optional] string EmpNum,
                [Optional, DefaultParameterValue((short)0)] ref short? IsComplete,
                [Optional] ref string InfoBar); 

        int FTSLValidateProjContainerSp(string ProjNum,
                int? TaskNum,
                string ContainerNum,
                byte? AllowNewItemContainer,
                ref string Loc,
                ref string Description,
                ref string Infobar); 

        int FTSLValidateQtyOnCompleteOperSp(string Job,
                short? Suffix,
                int? OperNum,
                decimal? QtyGood,
                decimal? QtyScrapped,
                ref string PromptCheckMsg,
                ref string PromptCheckButtons); 

        int FTSLValidateResourceByGroupSp(string ResourceID,
                string ResourceGroup,
                ref string InfoBar); 

        int FTSLValidateRestrictedTransSp([Optional] string Item,
                [Optional] string Lot,
                [Optional] string SerialNums,
                string MatlTransType,
                ref string Infobar,
                [Optional, DefaultParameterValue(0)] decimal? RefId,
                [Optional] string RefType,
                [Optional] Guid? ProcessId,
                [Optional] string Site); 

        int FTSLValidateSerialNumberSp(string SerialNumber,
                [Optional] string Job,
                [Optional, DefaultParameterValue((short)0)] short? Suffix,
                string TransactionType,
                [Optional] string Item,
                [Optional] string Whse,
                [Optional] string Loc,
                [Optional] string Lot,
                [Optional] string Site,
                ref string Infobar); 

        int FTSLValidateSerialSp(string Item,
                string Whse,
                string Loc,
                string Lot,
                string Status,
                string Ser_num,
                ref string Infobar,
                string RefNum); 

        int FTSLValidInvContOptAllowNewSp(string Location,
                string Container,
                ref string Infobar); 

        int FTSLWMGetActiveTransactionByEmployeeSp(string EmployeeNumber,
                ref string EmployeeShift,
                ref int? IsEmployeeActive,
                ref DateTime? StartTime,
                ref string OrderType,
                ref string OrderNumber,
                ref short? Suffix,
                ref int? Line,
                ref int? Operation,
                ref string Task,
                ref string Whse,
                ref string Item,
                ref string ItemDesc,
                ref string WC,
                ref string PartnerId,
                ref string PartnerDesc,
                ref string OrderCusName,
                ref string OrderDesc,
                ref string LineDesc,
                ref string InfoBar); 

        int FTSLWMRemoveTeamMemberSp(ref string EmployeeNumber,
                ref string ReturnSLEmpShift,
                ref string InfoBar); 

        int FTSLWMSLNegInvCheckSp(string Whse,
                string Item,
                string Location,
                string Lot,
                byte? SLAllowNegInvFlag,
                byte? FTAllowNegInvFlag,
                byte? Transaction,
                string Field,
                [Optional, DefaultParameterValue((byte)0)] byte? AllowNewLot,
                decimal? AvailQty,
                decimal? ScannedQty,
                [Optional, DefaultParameterValue(0)] ref decimal? Onhand,
                [Optional, DefaultParameterValue(0)] ref decimal? QtyRsvd,
                [Optional, DefaultParameterValue(0)] ref decimal? QtyContained,
                ref string LocLot,
                ref decimal? LocAvail,
                ref string Infobar,
                [Optional, DefaultParameterValue(0)] ref int? SLLotExp); 

        int FTSLWMSLNegInvLotCheckSp(string Whse,
                string Item,
                string Location,
                string Lot,
                byte? SLAllowNegInvFlag,
                byte? FTAllowNegInvFlag,
                byte? Transaction,
                string Field,
                [Optional, DefaultParameterValue((byte)0)] byte? AllowNewLot,
                decimal? AvailQty,
                decimal? ScannedQty,
                [Optional, DefaultParameterValue(0)] ref decimal? Onhand,
                [Optional, DefaultParameterValue(0)] ref decimal? QtyRsvd,
                [Optional, DefaultParameterValue(0)] ref decimal? QtyContained,
                ref string LocLot,
                ref decimal? LocAvail,
                ref string Infobar,
                [Optional, DefaultParameterValue(0)] ref int? SLLotExp,
                [Optional, DefaultParameterValue(0)] ref int? SLLotExpDate); 

        int FTSLWMStartOperationSp(DateTime? PunchDateTime,
                string EmployeeNumber,
                string OrderType,
                string OrderNumber,
                short? Suffix,
                string Operation,
                string InputTaskCode,
                string WorkCenter,
                ref string Whse,
                ref string Item,
                ref string InfoBar,
                [Optional] int? Line,
                [Optional] string PartnerId); 

        int FTSLWMStopOperationSp(DateTime? PunchDateTime,
                ref string EmployeeNumber,
                string OrderType,
                string OrderNumber,
                short? Suffix,
                string Operation,
                int? Line,
                string InputTaskcode,
                string InputWC,
                string PartnerId,
                string LocalItem,
                decimal? QuantityRejected,
                string ReasonCode,
                ref string InfoBar,
                ref string ReturnSLEmployee,
                ref string ReturnSLEmpShift); 

        int FTTAGetResourceIdListSP(string Job,
                short? Suffix,
                int? Operation,
                ref string ResID);

        int FTSLGetProductionScheduleDetailsSp(string Item,
                                            string PsNum,
                                            string Wc,
                                            int? OperNum,
                                            DateTime? DueDate,
                                            ref string ItemDescription,
                                            ref string ItemUM,
                                            ref int? ItemLotTracked,
                                            ref int? ItemSerialTracked,
                                            ref string WcDescription,
                                            ref string Whse,
                                            ref string Loc,
                                            ref decimal? QtyExpected,
                                            ref decimal? QtyCompleted,
                                            ref decimal? QtyScrapped,
                                            ref decimal? QtyRemaining,
                                            ref string SymixJob,
                                            ref int? SymixSuffix,
                                            ref int? PSBehind,
                                            ref int? PSAhead,
                                            ref string Infobar);
    }
}
    
