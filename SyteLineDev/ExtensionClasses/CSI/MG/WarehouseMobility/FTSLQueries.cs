//PROJECT NAME: WarehouseMobilityExt
//CLASS NAME: FTSLQueries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.WarehouseMobility;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.WarehouseMobility
{
	[IDOExtensionClass("FTSLQueries")]
	public class FTSLQueries : CSIExtensionClassBase, IExtFTFTSLQueries
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CLM_FTSLItemAndVendorItemCheckSp(string PoReceiptType,
		                                            string PoNum,
		                                            string VendorNum,
		                                            string GrnNum,
		                                            string GrnLine,
		                                            string VendorItem,
		                                            ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCLM_FTSLItemAndVendorItemCheckExt = new CLM_FTSLItemAndVendorItemCheckFactory().Create(appDb);
				
				int Severity = iCLM_FTSLItemAndVendorItemCheckExt.CLM_FTSLItemAndVendorItemCheckSp(PoReceiptType,
				                                                                                   PoNum,
				                                                                                   VendorNum,
				                                                                                   GrnNum,
				                                                                                   GrnLine,
				                                                                                   VendorItem,
				                                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTGetSLVersionSiteInfoSp(string DefaultConfig,
		                                    ref string Site,
		                                    ref string SyteLineVersion)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTGetSLVersionSiteInfoExt = new FTGetSLVersionSiteInfoFactory().Create(appDb);
				
				int Severity = iFTGetSLVersionSiteInfoExt.FTGetSLVersionSiteInfoSp(DefaultConfig,
				                                                                   ref Site,
				                                                                   ref SyteLineVersion);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetItemConvQtyOnHandSp(string Whse,
		                                      string Item,
		                                      string Loc,
		                                      string Lot,
		                                      string UM,
		                                      ref decimal? QtyOnHand,
		                                      ref decimal? QtyReserved,
		                                      ref string LocType,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetItemConvQtyOnHandExt = new FTSLGetItemConvQtyOnHandFactory().Create(appDb);
				
				int Severity = iFTSLGetItemConvQtyOnHandExt.FTSLGetItemConvQtyOnHandSp(Whse,
				                                                                       Item,
				                                                                       Loc,
				                                                                       Lot,
				                                                                       UM,
				                                                                       ref QtyOnHand,
				                                                                       ref QtyReserved,
				                                                                       ref LocType,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetJobTeamWorkSetDetailsSp(int? TaskCode,
		                                          string OrderNumber,
		                                          short? Suffix,
		                                          int? Operation,
		                                          string OrderType,
		                                          ref int? TaskCodeName,
		                                          ref string JobName,
		                                          ref short? SuffixName,
		                                          ref int? OperationName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetJobTeamWorkSetDetailsExt = new FTSLGetJobTeamWorkSetDetailsFactory().Create(appDb);
				
				int Severity = iFTSLGetJobTeamWorkSetDetailsExt.FTSLGetJobTeamWorkSetDetailsSp(TaskCode,
				                                                                               OrderNumber,
				                                                                               Suffix,
				                                                                               Operation,
				                                                                               OrderType,
				                                                                               ref TaskCodeName,
				                                                                               ref JobName,
				                                                                               ref SuffixName,
				                                                                               ref OperationName);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetLaborBackFlushStatusSp(string Type,
		                                         string Job,
		                                         short? Suffix,
		                                         int? OperNum,
		                                         string Item,
		                                         string WC,
		                                         ref byte? BackFlush,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetLaborBackFlushStatusExt = new FTSLGetLaborBackFlushStatusFactory().Create(appDb);
				
				int Severity = iFTSLGetLaborBackFlushStatusExt.FTSLGetLaborBackFlushStatusSp(Type,
				                                                                             Job,
				                                                                             Suffix,
				                                                                             OperNum,
				                                                                             Item,
				                                                                             WC,
				                                                                             ref BackFlush,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetSLTrnOrderPrefixSp(ref string TrnPrefix,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetSLTrnOrderPrefixExt = new FTSLGetSLTrnOrderPrefixFactory().Create(appDb);
				
				int Severity = iFTSLGetSLTrnOrderPrefixExt.FTSLGetSLTrnOrderPrefixSp(ref TrnPrefix,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLICValidateResourceIdSp(short? DisplayResourceId,
		                                      short? OnlyAllowResource,
		                                      short? AllowMultiuseResource,
		                                      short? TTImplemented,
		                                      string Job,
		                                      short? Suffix,
		                                      int? Operation,
		                                      string Rgid,
		                                      string MachineResource,
		                                      short? IsAllowMultiuseResource,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLICValidateResourceIdExt = new FTSLICValidateResourceIdFactory().Create(appDb);
				
				int Severity = iFTSLICValidateResourceIdExt.FTSLICValidateResourceIdSp(DisplayResourceId,
				                                                                       OnlyAllowResource,
				                                                                       AllowMultiuseResource,
				                                                                       TTImplemented,
				                                                                       Job,
				                                                                       Suffix,
				                                                                       Operation,
				                                                                       Rgid,
				                                                                       MachineResource,
				                                                                       IsAllowMultiuseResource,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLItemPackageValidateSp(decimal? ShipmentId,
		                                     string Item,
		                                     ref string ItemDesc,
		                                     ref string RefType,
		                                     ref decimal? QtyPicked,
		                                     ref string SerialTracked,
		                                     ref string LotTracked,
		                                     ref string ShipmentLine,
		                                     ref string ShipmentSeq,
		                                     ref string Lot,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLItemPackageValidateExt = new FTSLItemPackageValidateFactory().Create(appDb);
				
				int Severity = iFTSLItemPackageValidateExt.FTSLItemPackageValidateSp(ShipmentId,
				                                                                     Item,
				                                                                     ref ItemDesc,
				                                                                     ref RefType,
				                                                                     ref QtyPicked,
				                                                                     ref SerialTracked,
				                                                                     ref LotTracked,
				                                                                     ref ShipmentLine,
				                                                                     ref ShipmentSeq,
				                                                                     ref Lot,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLLabelCountSp(string LabelType,
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
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLLabelCountExt = new FTSLLabelCountFactory().Create(appDb);
				
				int Severity = iFTSLLabelCountExt.FTSLLabelCountSp(LabelType,
				                                                   Whse,
				                                                   FromLoc,
				                                                   ToLoc,
				                                                   FromItem,
				                                                   ToItem,
				                                                   FromContainer,
				                                                   ToContainer,
				                                                   Type,
				                                                   TaskType,
				                                                   FromEmp,
				                                                   ToEmp,
				                                                   ref Count,
				                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLLotValidateSp(string Lot,
		                             string Item,
		                             string Whse,
		                             string Loc,
		                             ref decimal? QtyOnHand,
		                             ref decimal? QtyRsvd,
		                             ref decimal? QtyContained,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLLotValidateExt = new FTSLLotValidateFactory().Create(appDb);
				
				int Severity = iFTSLLotValidateExt.FTSLLotValidateSp(Lot,
				                                                     Item,
				                                                     Whse,
				                                                     Loc,
				                                                     ref QtyOnHand,
				                                                     ref QtyRsvd,
				                                                     ref QtyContained,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLMaterialCostSp(string Item,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLMaterialCostExt = new FTSLMaterialCostFactory().Create(appDb);
				
				int Severity = iFTSLMaterialCostExt.FTSLMaterialCostSp(Item,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLMatlGetInvparmsSp(ref string DefWhse,
		                                 ref byte? NegFlag,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLMatlGetInvparmsExt = new FTSLMatlGetInvparmsFactory().Create(appDb);
				
				int Severity = iFTSLMatlGetInvparmsExt.FTSLMatlGetInvparmsSp(ref DefWhse,
				                                                             ref NegFlag,
				                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLSerialCountSp(string SessionID,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLSerialCountExt = new FTSLSerialCountFactory().Create(appDb);
				
				int Severity = iFTSLSerialCountExt.FTSLSerialCountSp(SessionID,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLTAGetOverHeadMachineSp(string Ordernumber,
		                                      int? Operation,
		                                      short? Suffix,
		                                      ref string OverHead,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLTAGetOverHeadMachineExt = new FTSLTAGetOverHeadMachineFactory().Create(appDb);
				
				int Severity = iFTSLTAGetOverHeadMachineExt.FTSLTAGetOverHeadMachineSp(Ordernumber,
				                                                                       Operation,
				                                                                       Suffix,
				                                                                       ref OverHead,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLTAGetPartnerIdSp(string EmployeeNumber,
		                                string PartnerID,
		                                ref string Name)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLTAGetPartnerIdExt = new FTSLTAGetPartnerIdFactory().Create(appDb);
				
				int Severity = iFTSLTAGetPartnerIdExt.FTSLTAGetPartnerIdSp(EmployeeNumber,
				                                                           PartnerID,
				                                                           ref Name);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLTAValidateResourceIdSp(short? OnlyAllowResource,
		                                      short? AllowMultiuseResource,
		                                      string Job,
		                                      short? Suffix,
		                                      string Operation,
		                                      string Rgid,
		                                      string MachineResource,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLTAValidateResourceIdExt = new FTSLTAValidateResourceIdFactory().Create(appDb);
				
				int Severity = iFTSLTAValidateResourceIdExt.FTSLTAValidateResourceIdSp(OnlyAllowResource,
				                                                                       AllowMultiuseResource,
				                                                                       Job,
				                                                                       Suffix,
				                                                                       Operation,
				                                                                       Rgid,
				                                                                       MachineResource,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateAllJobOperCompleteSp(string JobNum,
		                                            short? Suffix,
		                                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateAllJobOperCompleteExt = new FTSLValidateAllJobOperCompleteFactory().Create(appDb);
				
				int Severity = iFTSLValidateAllJobOperCompleteExt.FTSLValidateAllJobOperCompleteSp(JobNum,
				                                                                                   Suffix,
				                                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateIssueLotSp(string Lot,
		                                  string Item,
		                                  string Whse,
		                                  string Loc,
		                                  ref decimal? QtyOnHand,
		                                  ref decimal? QtyRsvd,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateIssueLotExt = new FTSLValidateIssueLotFactory().Create(appDb);
				
				int Severity = iFTSLValidateIssueLotExt.FTSLValidateIssueLotSp(Lot,
				                                                               Item,
				                                                               Whse,
				                                                               Loc,
				                                                               ref QtyOnHand,
				                                                               ref QtyRsvd,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTSLValidateRestrictedTransSp([Optional] string Item,
        [Optional] string Lot,
        [Optional] string SerialNums,
        string MatlTransType,
        ref string Infobar,
        [Optional, DefaultParameterValue(0)] decimal? RefId,
        [Optional] string RefType,
        [Optional] Guid? ProcessId,
        [Optional] string Site)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTSLValidateRestrictedTransExt = new FTSLValidateRestrictedTransFactory().Create(appDb);

                var result = iFTSLValidateRestrictedTransExt.FTSLValidateRestrictedTransSp(Item,
                                                                                             Lot,
                                                                                             SerialNums,
                                                                                             MatlTransType,
                                                                                             Infobar,
                                                                                             RefId,
                                                                                             RefType,
                                                                                             ProcessId,
                                                                                             Site
                                                                               );

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateItemNonInvItemSp(string Item,
		                                        ref string ItemDesc,
		                                        ref string IsInventory,
		                                        ref string UM,
		                                        ref byte? SerialTracked,
		                                        ref byte? LotTracked,
		                                        ref byte? GenerateLot,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateItemNonInvItemExt = new FTSLValidateItemNonInvItemFactory().Create(appDb);
				
				int Severity = iFTSLValidateItemNonInvItemExt.FTSLValidateItemNonInvItemSp(Item,
				                                                                           ref ItemDesc,
				                                                                           ref IsInventory,
				                                                                           ref UM,
				                                                                           ref SerialTracked,
				                                                                           ref LotTracked,
				                                                                           ref GenerateLot,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateJobLotSp(string Lot,
		                                string Item,
		                                string Job,
		                                int? SLLotExp,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateJobLotExt = new FTSLValidateJobLotFactory().Create(appDb);
				
				int Severity = iFTSLValidateJobLotExt.FTSLValidateJobLotSp(Lot,
				                                                           Item,
				                                                           Job,
				                                                           SLLotExp,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateLocationAcctSp(string Whse,
		                                      string Loc,
		                                      string Material,
		                                      ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateLocationAcctExt = new FTSLValidateLocationAcctFactory().Create(appDb);
				
				int Severity = iFTSLValidateLocationAcctExt.FTSLValidateLocationAcctSp(Whse,
				                                                                       Loc,
				                                                                       Material,
				                                                                       ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateLotForAttributesSp(string Lot,
		                                          string Item,
		                                          ref Guid? LotRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateLotForAttributesExt = new FTSLValidateLotForAttributesFactory().Create(appDb);
				
				int Severity = iFTSLValidateLotForAttributesExt.FTSLValidateLotForAttributesSp(Lot,
				                                                                               Item,
				                                                                               ref LotRowPointer);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateLotSp(string Lot,
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
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateLotExt = new FTSLValidateLotFactory().Create(appDb);
				
				int Severity = iFTSLValidateLotExt.FTSLValidateLotSp(Lot,
				                                                     Item,
				                                                     Whse,
				                                                     Loc,
				                                                     ref QtyOnHand,
				                                                     ref QtyRsvd,
				                                                     ref QtyContained,
				                                                     ref QtyAvailable,
				                                                     ref SLLotExp,
				                                                     SLAllowNegInvFlag,
				                                                     FTAllowNegInvFlag,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateProjContainerSp(string ProjNum,
		                                       int? TaskNum,
		                                       string ContainerNum,
		                                       byte? AllowNewItemContainer,
		                                       ref string Loc,
		                                       ref string Description,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateProjContainerExt = new FTSLValidateProjContainerFactory().Create(appDb);
				
				int Severity = iFTSLValidateProjContainerExt.FTSLValidateProjContainerSp(ProjNum,
				                                                                         TaskNum,
				                                                                         ContainerNum,
				                                                                         AllowNewItemContainer,
				                                                                         ref Loc,
				                                                                         ref Description,
				                                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateQtyOnCompleteOperSp(string Job,
		                                           short? Suffix,
		                                           int? OperNum,
		                                           decimal? QtyGood,
		                                           decimal? QtyScrapped,
		                                           ref string PromptCheckMsg,
		                                           ref string PromptCheckButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateQtyOnCompleteOperExt = new FTSLValidateQtyOnCompleteOperFactory().Create(appDb);
				
				int Severity = iFTSLValidateQtyOnCompleteOperExt.FTSLValidateQtyOnCompleteOperSp(Job,
				                                                                                 Suffix,
				                                                                                 OperNum,
				                                                                                 QtyGood,
				                                                                                 QtyScrapped,
				                                                                                 ref PromptCheckMsg,
				                                                                                 ref PromptCheckButtons);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidInvContOptAllowNewSp(string Location,
		                                         string Container,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidInvContOptAllowNewExt = new FTSLValidInvContOptAllowNewFactory().Create(appDb);
				
				int Severity = iFTSLValidInvContOptAllowNewExt.FTSLValidInvContOptAllowNewSp(Location,
				                                                                             Container,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLWMGetActiveTransactionByEmployeeSp(string EmployeeNumber,
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
		                                                  ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLWMGetActiveTransactionByEmployeeExt = new FTSLWMGetActiveTransactionByEmployeeFactory().Create(appDb);
				
				int Severity = iFTSLWMGetActiveTransactionByEmployeeExt.FTSLWMGetActiveTransactionByEmployeeSp(EmployeeNumber,
				                                                                                               ref EmployeeShift,
				                                                                                               ref IsEmployeeActive,
				                                                                                               ref StartTime,
				                                                                                               ref OrderType,
				                                                                                               ref OrderNumber,
				                                                                                               ref Suffix,
				                                                                                               ref Line,
				                                                                                               ref Operation,
				                                                                                               ref Task,
				                                                                                               ref Whse,
				                                                                                               ref Item,
				                                                                                               ref ItemDesc,
				                                                                                               ref WC,
				                                                                                               ref PartnerId,
				                                                                                               ref PartnerDesc,
				                                                                                               ref OrderCusName,
				                                                                                               ref OrderDesc,
				                                                                                               ref LineDesc,
				                                                                                               ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLWMRemoveTeamMemberSp(ref string EmployeeNumber,
		                                    ref string ReturnSLEmpShift,
		                                    ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLWMRemoveTeamMemberExt = new FTSLWMRemoveTeamMemberFactory().Create(appDb);
				
				int Severity = iFTSLWMRemoveTeamMemberExt.FTSLWMRemoveTeamMemberSp(ref EmployeeNumber,
				                                                                   ref ReturnSLEmpShift,
				                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLWMStopOperationSp(DateTime? PunchDateTime,
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
		                                 ref string ReturnSLEmpShift)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLWMStopOperationExt = new FTSLWMStopOperationFactory().Create(appDb);
				
				int Severity = iFTSLWMStopOperationExt.FTSLWMStopOperationSp(PunchDateTime,
				                                                             ref EmployeeNumber,
				                                                             OrderType,
				                                                             OrderNumber,
				                                                             Suffix,
				                                                             Operation,
				                                                             Line,
				                                                             InputTaskcode,
				                                                             InputWC,
				                                                             PartnerId,
				                                                             LocalItem,
				                                                             QuantityRejected,
				                                                             ReasonCode,
				                                                             ref InfoBar,
				                                                             ref ReturnSLEmployee,
				                                                             ref ReturnSLEmpShift);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTTAGetResourceIdListSP(string Job,
		                                   short? Suffix,
		                                   int? Operation,
		                                   ref string ResID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTTAGetResourceIdListExt = new FTTAGetResourceIdListFactory().Create(appDb);
				
				int Severity = iFTTAGetResourceIdListExt.FTTAGetResourceIdListSP(Job,
				                                                                 Suffix,
				                                                                 Operation,
				                                                                 ref ResID);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTDeleteSelectedTmpserSp(Guid? SessionID,
		                                    string SerNum,
		                                    ref int? SerCount,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTDeleteSelectedTmpserExt = new FTDeleteSelectedTmpserFactory().Create(appDb);
				
				var result = iFTDeleteSelectedTmpserExt.FTDeleteSelectedTmpserSp(SessionID,
				                                                                 SerNum,
				                                                                 SerCount,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				SerCount = result.SerCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTDeleteTmpserSp(Guid? SessionID,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTDeleteTmpserExt = new FTDeleteTmpserFactory().Create(appDb);
				
				var result = iFTDeleteTmpserExt.FTDeleteTmpserSp(SessionID,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetAllJobInfoSp(string Job,
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
		ref string SerialPrefix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetAllJobInfoExt = new FTSLGetAllJobInfoFactory().Create(appDb);
				
				var result = iFTSLGetAllJobInfoExt.FTSLGetAllJobInfoSp(Job,
				                                                       Suffix,
				                                                       OperNum,
				                                                       Loc,
				                                                       ScrapConsider,
				                                                       CallForm,
				                                                       TAImplement,
				                                                       Empum,
				                                                       CoProdcutMix,
				                                                       JobOpReceivedQty,
				                                                       QtyScrapped,
				                                                       QtyCompleted,
				                                                       QtyMoved,
				                                                       WC,
				                                                       WCDesc,
				                                                       IsLastOperation,
				                                                       Complete,
				                                                       LocDesc,
				                                                       NextOper,
				                                                       JobBalance,
				                                                       Item,
				                                                       ItemDesc,
				                                                       UOM,
				                                                       UOMDesc,
				                                                       JobStat,
				                                                       JobQty,
				                                                       Whse,
				                                                       WhseDesc,
				                                                       LotTrack,
				                                                       PreassignLot,
				                                                       LotPrefix,
				                                                       SerialTrack,
				                                                       RefJob,
				                                                       Shift,
				                                                       Overhead,
				                                                       LotAttrGroup,
				                                                       ProductCode,
				                                                       SerialPrefix);
				
				int Severity = result.ReturnCode.Value;
				CoProdcutMix = result.CoProdcutMix;
				JobOpReceivedQty = result.JobOpReceivedQty;
				QtyScrapped = result.QtyScrapped;
				QtyCompleted = result.QtyCompleted;
				QtyMoved = result.QtyMoved;
				WC = result.WC;
				WCDesc = result.WCDesc;
				IsLastOperation = result.IsLastOperation;
				Complete = result.Complete;
				LocDesc = result.LocDesc;
				NextOper = result.NextOper;
				JobBalance = result.JobBalance;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				UOM = result.UOM;
				UOMDesc = result.UOMDesc;
				JobStat = result.JobStat;
				JobQty = result.JobQty;
				Whse = result.Whse;
				WhseDesc = result.WhseDesc;
				LotTrack = result.LotTrack;
				PreassignLot = result.PreassignLot;
				LotPrefix = result.LotPrefix;
				SerialTrack = result.SerialTrack;
				RefJob = result.RefJob;
				Shift = result.Shift;
				Overhead = result.Overhead;
				LotAttrGroup = result.LotAttrGroup;
				ProductCode = result.ProductCode;
				SerialPrefix = result.SerialPrefix;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetDefaultWCLocationSp(string Inputworkcenter,
		                                      [Optional] string DefaultWhseRecLoc,
		                                      ref string ReceiptLoc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetDefaultWCLocationExt = new FTSLGetDefaultWCLocationFactory().Create(appDb);
				
				var result = iFTSLGetDefaultWCLocationExt.FTSLGetDefaultWCLocationSp(Inputworkcenter,
				                                                                     DefaultWhseRecLoc,
				                                                                     ReceiptLoc);
				
				int Severity = result.ReturnCode.Value;
				ReceiptLoc = result.ReceiptLoc;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLPSVal10Sp(string PSItem,
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
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLPSVal10Ext = new FTSLPSVal10Factory().Create(appDb);
				
				var result = iFTSLPSVal10Ext.FTSLPSVal10Sp(PSItem,
				                                           Cmpl,
				                                           PSNum,
				                                           UM,
				                                           LotTracked,
				                                           SerTracked,
				                                           Whse,
				                                           Wc,
				                                           OperNum,
				                                           PSItemJob,
				                                           PSItemSuffix,
				                                           QtyComplete,
				                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				PSNum = result.PSNum;
				UM = result.UM;
				LotTracked = result.LotTracked;
				SerTracked = result.SerTracked;
				Whse = result.Whse;
				Wc = result.Wc;
				OperNum = result.OperNum;
				PSItemJob = result.PSItemJob;
				PSItemSuffix = result.PSItemSuffix;
				QtyComplete = result.QtyComplete;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateIssuedLotSp(string Lot,
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
		ref string Uom)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateIssuedLotExt = new FTSLValidateIssuedLotFactory().Create(appDb);
				
				var result = iFTSLValidateIssuedLotExt.FTSLValidateIssuedLotSp(Lot,
				                                                               Item,
				                                                               Whse,
				                                                               Loc,
				                                                               QtyOnHand,
				                                                               QtyRsvd,
				                                                               QtyContained,
				                                                               QtyAvailable,
				                                                               SLLotExp,
				                                                               SLAllowNegInvFlag,
				                                                               FTAllowNegInvFlag,
				                                                               Infobar,
				                                                               FDALotTraceability,
				                                                               Job,
				                                                               Suffix,
				                                                               Operation,
				                                                               Uom);
				
				int Severity = result.ReturnCode.Value;
				QtyOnHand = result.QtyOnHand;
				QtyRsvd = result.QtyRsvd;
				QtyContained = result.QtyContained;
				QtyAvailable = result.QtyAvailable;
				SLLotExp = result.SLLotExp;
				Infobar = result.Infobar;
				Uom = result.Uom;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateResourceByGroupSp(string ResourceID,
		                                         string ResourceGroup,
		                                         ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateResourceByGroupExt = new FTSLValidateResourceByGroupFactory().Create(appDb);
				
				var result = iFTSLValidateResourceByGroupExt.FTSLValidateResourceByGroupSp(ResourceID,
				                                                                           ResourceGroup,
				                                                                           InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateSerialSp(string Item,
		                                string Whse,
		                                string Loc,
		                                string Lot,
		                                string Status,
		                                string Ser_num,
		                                ref string Infobar,
		                                string RefNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateSerialExt = new FTSLValidateSerialFactory().Create(appDb);
				
				var result = iFTSLValidateSerialExt.FTSLValidateSerialSp(Item,
				                                                         Whse,
				                                                         Loc,
				                                                         Lot,
				                                                         Status,
				                                                         Ser_num,
				                                                         Infobar,
				                                                         RefNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLWMSLNegInvCheckSp(string Whse,
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
		[Optional, DefaultParameterValue(0)] ref int? SLLotExp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLWMSLNegInvCheckExt = new FTSLWMSLNegInvCheckFactory().Create(appDb);
				
				var result = iFTSLWMSLNegInvCheckExt.FTSLWMSLNegInvCheckSp(Whse,
				                                                           Item,
				                                                           Location,
				                                                           Lot,
				                                                           SLAllowNegInvFlag,
				                                                           FTAllowNegInvFlag,
				                                                           Transaction,
				                                                           Field,
				                                                           AllowNewLot,
				                                                           AvailQty,
				                                                           ScannedQty,
				                                                           Onhand,
				                                                           QtyRsvd,
				                                                           QtyContained,
				                                                           LocLot,
				                                                           LocAvail,
				                                                           Infobar,
				                                                           SLLotExp);
				
				int Severity = result.ReturnCode.Value;
				Onhand = result.Onhand;
				QtyRsvd = result.QtyRsvd;
				QtyContained = result.QtyContained;
				LocLot = result.LocLot;
				LocAvail = result.LocAvail;
				Infobar = result.Infobar;
				SLLotExp = result.SLLotExp;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLWMSLNegInvLotCheckSp(string Whse,
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
		[Optional, DefaultParameterValue(0)] ref int? SLLotExpDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLWMSLNegInvLotCheckExt = new FTSLWMSLNegInvLotCheckFactory().Create(appDb);
				
				var result = iFTSLWMSLNegInvLotCheckExt.FTSLWMSLNegInvLotCheckSp(Whse,
				                                                                 Item,
				                                                                 Location,
				                                                                 Lot,
				                                                                 SLAllowNegInvFlag,
				                                                                 FTAllowNegInvFlag,
				                                                                 Transaction,
				                                                                 Field,
				                                                                 AllowNewLot,
				                                                                 AvailQty,
				                                                                 ScannedQty,
				                                                                 Onhand,
				                                                                 QtyRsvd,
				                                                                 QtyContained,
				                                                                 LocLot,
				                                                                 LocAvail,
				                                                                 Infobar,
				                                                                 SLLotExp,
				                                                                 SLLotExpDate);
				
				int Severity = result.ReturnCode.Value;
				Onhand = result.Onhand;
				QtyRsvd = result.QtyRsvd;
				QtyContained = result.QtyContained;
				LocLot = result.LocLot;
				LocAvail = result.LocAvail;
				Infobar = result.Infobar;
				SLLotExp = result.SLLotExp;
				SLLotExpDate = result.SLLotExpDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetJobMatlItemSp([Optional] string Item,
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
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetJobMatlItemExt = new FTSLGetJobMatlItemFactory().Create(appDb);
				
				var result = iFTSLGetJobMatlItemExt.FTSLGetJobMatlItemSp(Item,
				UM,
				Job,
				Suffix,
				OperNum,
				Sequence,
				ExtByScrap,
				item_UM,
				item_Description,
				ItemNotExists,
				UMConvFactor,
				JobmatlNotExists,
				item_MatlCost,
				item_MatlCostConv,
				item_SerialTracked,
				item_LotTracked,
				ReqQty,
				ReqQtyConv,
				QtyIssued,
				QtyIssuedConv,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				item_UM = result.item_UM;
				item_Description = result.item_Description;
				ItemNotExists = result.ItemNotExists;
				UMConvFactor = result.UMConvFactor;
				JobmatlNotExists = result.JobmatlNotExists;
				item_MatlCost = result.item_MatlCost;
				item_MatlCostConv = result.item_MatlCostConv;
				item_SerialTracked = result.item_SerialTracked;
				item_LotTracked = result.item_LotTracked;
				ReqQty = result.ReqQty;
				ReqQtyConv = result.ReqQtyConv;
				QtyIssued = result.QtyIssued;
				QtyIssuedConv = result.QtyIssuedConv;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetShiftGenerateLotSp(string CallForm,
		[Optional, DefaultParameterValue((short)0)] short? TAImplement,
		[Optional] string EmpNum,
		[Optional, DefaultParameterValue((byte)0)] ref byte? GenerateLot,
		[Optional] ref string Shift)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetShiftGenerateLotExt = new FTSLGetShiftGenerateLotFactory().Create(appDb);
				
				var result = iFTSLGetShiftGenerateLotExt.FTSLGetShiftGenerateLotSp(CallForm,
				TAImplement,
				EmpNum,
				GenerateLot,
				Shift);
				
				int Severity = result.ReturnCode.Value;
				GenerateLot = result.GenerateLot;
				Shift = result.Shift;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetTimeInfoSp(string EmpNum,
		[Optional, DefaultParameterValue((byte)0)] byte? TAImplement,
		string CallForm,
		string Job,
		short? Suffix,
		ref int? SLOperation,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLGetTimeInfoExt = new FTSLGetTimeInfoFactory().Create(appDb);
				
				var result = iFTSLGetTimeInfoExt.FTSLGetTimeInfoSp(EmpNum,
				TAImplement,
				CallForm,
				Job,
				Suffix,
				SLOperation,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				SLOperation = result.SLOperation;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLItemValidateSp(string Item,
		ref byte? TaxFreeMatl,
		[Optional] ref string ImportDocId,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLItemValidateExt = new FTSLItemValidateFactory().Create(appDb);
				
				var result = iFTSLItemValidateExt.FTSLItemValidateSp(Item,
				TaxFreeMatl,
				ImportDocId,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				TaxFreeMatl = result.TaxFreeMatl;
				ImportDocId = result.ImportDocId;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateComponentSp(string ValidateObject,
		string Job,
		short? Suffix,
		int? Oper,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateComponentExt = new FTSLValidateComponentFactory().Create(appDb);
				
				var result = iFTSLValidateComponentExt.FTSLValidateComponentSp(ValidateObject,
				Job,
				Suffix,
				Oper,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateJobMaterialExistSp(string Job,
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
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateJobMaterialExistExt = new FTSLValidateJobMaterialExistFactory().Create(appDb);
				
				var result = iFTSLValidateJobMaterialExistExt.FTSLValidateJobMaterialExistSp(Job,
				Suffix,
				OperNum,
				Material,
				AllowNonBomItems,
				AllowNonInvItems,
				AdjustForScrap,
				MaterialDesc,
				Sequence,
				UM,
				LotTracked,
				SerialTracked,
				QtyRequired,
				QtyIssued,
				MaterialCost,
				JobmatlNotExists,
				ItemNotExists,
				TaxFreeMatl,
				ImportDocId,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				MaterialDesc = result.MaterialDesc;
				Sequence = result.Sequence;
				UM = result.UM;
				LotTracked = result.LotTracked;
				SerialTracked = result.SerialTracked;
				QtyRequired = result.QtyRequired;
				QtyIssued = result.QtyIssued;
				MaterialCost = result.MaterialCost;
				JobmatlNotExists = result.JobmatlNotExists;
				ItemNotExists = result.ItemNotExists;
				TaxFreeMatl = result.TaxFreeMatl;
				ImportDocId = result.ImportDocId;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateOperationDropDownSp(string CallForm,
		string Job,
		short? Suffix,
		int? Operation,
		[Optional] string EmpNum,
		[Optional, DefaultParameterValue((short)0)] ref short? IsComplete,
		[Optional] ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateOperationDropDownExt = new FTSLValidateOperationDropDownFactory().Create(appDb);
				
				var result = iFTSLValidateOperationDropDownExt.FTSLValidateOperationDropDownSp(CallForm,
				Job,
				Suffix,
				Operation,
				EmpNum,
				IsComplete,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				IsComplete = result.IsComplete;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLValidateSerialNumberSp(string SerialNumber,
		[Optional] string Job,
		[Optional, DefaultParameterValue((short)0)] short? Suffix,
		string TransactionType,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLValidateSerialNumberExt = new FTSLValidateSerialNumberFactory().Create(appDb);
				
				var result = iFTSLValidateSerialNumberExt.FTSLValidateSerialNumberSp(SerialNumber,
				Job,
				Suffix,
				TransactionType,
				Item,
				Whse,
				Loc,
				Lot,
				Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLWMStartOperationSp(DateTime? PunchDateTime,
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
		[Optional] string PartnerId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFTSLWMStartOperationExt = new FTSLWMStartOperationFactory().Create(appDb);
				
				var result = iFTSLWMStartOperationExt.FTSLWMStartOperationSp(PunchDateTime,
				EmployeeNumber,
				OrderType,
				OrderNumber,
				Suffix,
				Operation,
				InputTaskCode,
				WorkCenter,
				Whse,
				Item,
				InfoBar,
				Line,
				PartnerId);
				
				int Severity = result.ReturnCode.Value;
				Whse = result.Whse;
				Item = result.Item;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTGetWorkCenterJobsSp(string WorkCenter,
		[Optional] string FilterString,
		[Optional] string OrderByString,
		string ResouceGroup,
		string ResourceId,
		int? DateInterval)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTGetWorkCenterJobsExt = new CLM_FTGetWorkCenterJobsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTGetWorkCenterJobsExt.CLM_FTGetWorkCenterJobsSp(WorkCenter,
				FilterString,
				OrderByString,
				ResouceGroup,
				ResourceId,
				DateInterval);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLAPISerialLoadSp(string TransNum,
		string Item,
		string Whse,
		string Loc,
		string Lot,
		string Site,
		string ERPQueryResponseString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLAPISerialLoadExt = new CLM_FTSLAPISerialLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLAPISerialLoadExt.CLM_FTSLAPISerialLoadSp(TransNum,
				Item,
				Whse,
				Loc,
				Lot,
				Site,
				ERPQueryResponseString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLBuildIcTmpPickListSp(string Item,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLBuildIcTmpPickListExt = new CLM_FTSLBuildIcTmpPickListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLBuildIcTmpPickListExt.CLM_FTSLBuildIcTmpPickListSp(Item,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLContainerLabelSp(string Whse,
		string FromLoc,
		string ToLoc,
		string FromContainer,
		string ToContainer,
		int? FromRange,
		int? ToRange,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLContainerLabelExt = new CLM_FTSLContainerLabelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLContainerLabelExt.CLM_FTSLContainerLabelSp(Whse,
				FromLoc,
				ToLoc,
				FromContainer,
				ToContainer,
				FromRange,
				ToRange,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLDocumentListingSp([Optional] string Job,
		[Optional] int? Suffix,
		[Optional, DefaultParameterValue(0)] int? ViewJob,
		[Optional, DefaultParameterValue(0)] int? ReadSyteLine,
		[Optional] int? Operation,
		[Optional] string Item,
		[Optional, DefaultParameterValue(0)] int? ViewOperation,
		[Optional, DefaultParameterValue(0)] int? ViewItem,
		[Optional, DefaultParameterValue(0)] int? ReadDocTrak)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLDocumentListingExt = new CLM_FTSLDocumentListingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLDocumentListingExt.CLM_FTSLDocumentListingSp(Job,
				Suffix,
				ViewJob,
				ReadSyteLine,
				Operation,
				Item,
				ViewOperation,
				ViewItem,
				ReadDocTrak);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLEmployeeLabelSp(string FromEmp,
		string ToEmp,
		int? FromRange,
		int? ToRange,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLEmployeeLabelExt = new CLM_FTSLEmployeeLabelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLEmployeeLabelExt.CLM_FTSLEmployeeLabelSp(FromEmp,
				ToEmp,
				FromRange,
				ToRange,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetActiveTransSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetActiveTransExt = new CLM_FTSLGetActiveTransFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetActiveTransExt.CLM_FTSLGetActiveTransSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetEmpInfoSp(string EmpNum,
		[Optional, DefaultParameterValue(0)] int? TAImplement)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetEmpInfoExt = new CLM_FTSLGetEmpInfoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetEmpInfoExt.CLM_FTSLGetEmpInfoSp(EmpNum,
				TAImplement);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetIssuedLotsSp(string Whse,
		string Item,
		string Location,
		[Optional, DefaultParameterValue(0)] int? FDALotTraceability,
		string Job,
		int? Suffix,
		string Operation)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetIssuedLotsExt = new CLM_FTSLGetIssuedLotsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetIssuedLotsExt.CLM_FTSLGetIssuedLotsSp(Whse,
				Item,
				Location,
				FDALotTraceability,
				Job,
				Suffix,
				Operation);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetItemsNonInventoryItemsSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetItemsNonInventoryItemsExt = new CLM_FTSLGetItemsNonInventoryItemsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetItemsNonInventoryItemsExt.CLM_FTSLGetItemsNonInventoryItemsSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetJobInfoSp(string CallForm,
		[Optional, DefaultParameterValue(0)] int? TAImplement,
		string Job,
		int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetJobInfoExt = new CLM_FTSLGetJobInfoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetJobInfoExt.CLM_FTSLGetJobInfoSp(CallForm,
				TAImplement,
				Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetJobMaterialsByPreassignedSerialSp(string Job,
		int? Suffix,
		string EndItem,
		string EndItemSerial)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetJobMaterialsByPreassignedSerialExt = new CLM_FTSLGetJobMaterialsByPreassignedSerialFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetJobMaterialsByPreassignedSerialExt.CLM_FTSLGetJobMaterialsByPreassignedSerialSp(Job,
				Suffix,
				EndItem,
				EndItemSerial);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetJobMatlSerialUsageSp([Optional] string Job,
		[Optional] int? Suffix,
		[Optional] int? OperNum,
		[Optional] string EndItem,
		[Optional] string EndItemSerial,
		[Optional] string JobMatlItem,
		[Optional] string JobMatlSerial)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetJobMatlSerialUsageExt = new CLM_FTSLGetJobMatlSerialUsageFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetJobMatlSerialUsageExt.CLM_FTSLGetJobMatlSerialUsageSp(Job,
				Suffix,
				OperNum,
				EndItem,
				EndItemSerial,
				JobMatlItem,
				JobMatlSerial);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetKanbanLabelPrintingDataSp(string KanbanItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetKanbanLabelPrintingDataExt = new CLM_FTSLGetKanbanLabelPrintingDataFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetKanbanLabelPrintingDataExt.CLM_FTSLGetKanbanLabelPrintingDataSp(KanbanItem);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetPartnerIdSp(string EmployeeNumber,
		ref string PartnerID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetPartnerIdExt = new CLM_FTSLGetPartnerIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetPartnerIdExt.CLM_FTSLGetPartnerIdSp(EmployeeNumber,
				PartnerID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				PartnerID = result.PartnerID;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetPSJITSp([Optional, DefaultParameterValue(0)] int? TT_Implemented,
		[Optional] string Wc,
		[Optional] string Facility,
		string EmpNum,
		[Optional, DefaultParameterValue(1)] int? Page,
		[Optional, DefaultParameterValue(0)] int? IsAcitveTransaction,
		[Optional] DateTime? PunchDateTime,
		[Optional] string FilterString,
		[Optional] string OrderByString,
		string ERPQueryResponseString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetPSJITExt = new CLM_FTSLGetPSJITFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetPSJITExt.CLM_FTSLGetPSJITSp(TT_Implemented,
				Wc,
				Facility,
				EmpNum,
				Page,
				IsAcitveTransaction,
				PunchDateTime,
				FilterString,
				OrderByString,
				ERPQueryResponseString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetResourceIdSp(int? DisplayResourceId,
		string Job,
		int? Suffix,
		int? Operation)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetResourceIdExt = new CLM_FTSLGetResourceIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetResourceIdExt.CLM_FTSLGetResourceIdSp(DisplayResourceId,
				Job,
				Suffix,
				Operation);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetSerialNumbersSp(Guid? SessionID,
		[Optional] string Job,
		[Optional, DefaultParameterValue(0)] int? Suffix,
		string TransactionType,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetSerialNumbersExt = new CLM_FTSLGetSerialNumbersFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetSerialNumbersExt.CLM_FTSLGetSerialNumbersSp(SessionID,
				Job,
				Suffix,
				TransactionType,
				Item,
				Whse,
				Loc,
				Lot,
				Site);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetTeamPunchDetailsSp(string ERPQueryResponseString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetTeamPunchDetailsExt = new CLM_FTSLGetTeamPunchDetailsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetTeamPunchDetailsExt.CLM_FTSLGetTeamPunchDetailsSp(ERPQueryResponseString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetWCActiveTransSp(string ERPQueryResponseString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetWCActiveTransExt = new CLM_FTSLGetWCActiveTransFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetWCActiveTransExt.CLM_FTSLGetWCActiveTransSp(ERPQueryResponseString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetWorkCenterProjectsSp([Optional, DefaultParameterValue(0)] int? TT_Implemented)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetWorkCenterProjectsExt = new CLM_FTSLGetWorkCenterProjectsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetWorkCenterProjectsExt.CLM_FTSLGetWorkCenterProjectsSp(TT_Implemented);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetWorkCenterServiceOrdersSp([Optional, DefaultParameterValue(0)] int? TT_Implemented)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLGetWorkCenterServiceOrdersExt = new CLM_FTSLGetWorkCenterServiceOrdersFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLGetWorkCenterServiceOrdersExt.CLM_FTSLGetWorkCenterServiceOrdersSp(TT_Implemented);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLInvCodeLabelSp(string Type,
		int? FromRange,
		int? ToRange,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLInvCodeLabelExt = new CLM_FTSLInvCodeLabelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLInvCodeLabelExt.CLM_FTSLInvCodeLabelSp(Type,
				FromRange,
				ToRange,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLInventoryLabelSp(string Whse,
		string FromLoc,
		string ToLoc,
		string FromItem,
		string ToItem,
		int? FromRange,
		int? ToRange,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLInventoryLabelExt = new CLM_FTSLInventoryLabelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLInventoryLabelExt.CLM_FTSLInventoryLabelSp(Whse,
				FromLoc,
				ToLoc,
				FromItem,
				ToItem,
				FromRange,
				ToRange,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLItemAttributeValueSp(Guid? RowPointer,
		string AttrGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLItemAttributeValueExt = new CLM_FTSLItemAttributeValueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLItemAttributeValueExt.CLM_FTSLItemAttributeValueSp(RowPointer,
				AttrGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLJobStatusSp(string JobStart,
		string JobEnd,
		int? SuffixStart,
		int? SuffixEnd,
		string WorkCenterStart,
		string WorkCenterEnd,
		DateTime? StartDate,
		DateTime? EndDate,
		int? SortBy,
		int? Clear)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLJobStatusExt = new CLM_FTSLJobStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLJobStatusExt.CLM_FTSLJobStatusSp(JobStart,
				JobEnd,
				SuffixStart,
				SuffixEnd,
				WorkCenterStart,
				WorkCenterEnd,
				StartDate,
				EndDate,
				SortBy,
				Clear);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLKanbanPickListDetailSp([Optional] string PickFromWhse,
		[Optional] string KbItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLKanbanPickListDetailExt = new CLM_FTSLKanbanPickListDetailFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLKanbanPickListDetailExt.CLM_FTSLKanbanPickListDetailSp(PickFromWhse,
				KbItem);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadBackflushLotSerialSp(int? BackflushByLot,
		string TransClass,
		decimal? TransNum,
		string Job,
		int? Suffix,
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
		[Optional, DefaultParameterValue(0)] ref int? BflushNeeded,
		[Optional, DefaultParameterValue(0)] int? ReverseQty,
		[Optional, DefaultParameterValue(0)] int? FDALotTraceability)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadBackflushLotSerialExt = new CLM_FTSLLoadBackflushLotSerialFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadBackflushLotSerialExt.CLM_FTSLLoadBackflushLotSerialSp(BackflushByLot,
				TransClass,
				TransNum,
				Job,
				Suffix,
				OperNum,
				JobItem,
				PhantomMulti,
				PhantomUnits,
				PhantomScrap,
				TransDate,
				Whse,
				Lot,
				RouteQtyComplete,
				RouteQtyScrapped,
				EmpNum,
				Infobar,
				BflushNeeded,
				ReverseQty,
				FDALotTraceability);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				BflushNeeded = result.BflushNeeded;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadBackflushSp(int? BackflushByLot,
		[Optional, DefaultParameterValue("J")] string TransClass,
		decimal? TransNum,
		string Job,
		int? Suffix,
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
		string ERPQueryJobMatResponseString,
		string ERPQueryJobSerResponseString,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadBackflushExt = new CLM_FTSLLoadBackflushFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadBackflushExt.CLM_FTSLLoadBackflushSp(BackflushByLot,
				TransClass,
				TransNum,
				Job,
				Suffix,
				OperNum,
				JobItem,
				PhantomMulti,
				PhantomUnits,
				PhantomScrap,
				TransDate,
				Whse,
				Lot,
				RouteQtyComplete,
				RouteQtyScrapped,
				EmpNum,
				ERPQueryJobMatResponseString,
				ERPQueryJobSerResponseString,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadJobtranitemSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadJobtranitemExt = new CLM_FTSLLoadJobtranitemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadJobtranitemExt.CLM_FTSLLoadJobtranitemSp(TransNum,
				Job,
				Suffix,
				OperNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadResourceSkillsSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadResourceSkillsExt = new CLM_FTSLLoadResourceSkillsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadResourceSkillsExt.CLM_FTSLLoadResourceSkillsSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadVSAJobAndPreSerialsSp([Optional] string Job,
		[Optional] int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadVSAJobAndPreSerialsExt = new CLM_FTSLLoadVSAJobAndPreSerialsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadVSAJobAndPreSerialsExt.CLM_FTSLLoadVSAJobAndPreSerialsSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadXdocOrderItemsPagingSp(string Item,
		string Whse,
		string Job)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadXdocOrderItemsPagingExt = new CLM_FTSLLoadXdocOrderItemsPagingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadXdocOrderItemsPagingExt.CLM_FTSLLoadXdocOrderItemsPagingSp(Item,
				Whse,
				Job);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadXdocOrderItemsSp(string Item,
		string Whse,
		string Job,
		int? priority_1,
		int? priority_2,
		int? priority_3,
		int? priority_4,
		int? future_days_1,
		int? future_days_2,
		int? future_days_3,
		int? future_days_4)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLoadXdocOrderItemsExt = new CLM_FTSLLoadXdocOrderItemsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLoadXdocOrderItemsExt.CLM_FTSLLoadXdocOrderItemsSp(Item,
				Whse,
				Job,
				priority_1,
				priority_2,
				priority_3,
				priority_4,
				future_days_1,
				future_days_2,
				future_days_3,
				future_days_4);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLocationLabelSp(string FromLoc,
		string ToLoc,
		int? FromRange,
		int? ToRange,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLLocationLabelExt = new CLM_FTSLLocationLabelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLLocationLabelExt.CLM_FTSLLocationLabelSp(FromLoc,
				ToLoc,
				FromRange,
				ToRange,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateJobDropDownSp(string CallForm,
		[Optional, DefaultParameterValue(0)] int? TTImplemented)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateJobDropDownExt = new CLM_FTSLPopulateJobDropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateJobDropDownExt.CLM_FTSLPopulateJobDropDownSp(CallForm,
				TTImplemented);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateOperationDropDownSp([Optional, DefaultParameterValue(0)] int? TTImplemented,
		string Job)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateOperationDropDownExt = new CLM_FTSLPopulateOperationDropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateOperationDropDownExt.CLM_FTSLPopulateOperationDropDownSp(TTImplemented,
				Job);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateProgressDataSp(string Job,
		int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateProgressDataExt = new CLM_FTSLPopulateProgressDataFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateProgressDataExt.CLM_FTSLPopulateProgressDataSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateProjectDropDownSp(string CallForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateProjectDropDownExt = new CLM_FTSLPopulateProjectDropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateProjectDropDownExt.CLM_FTSLPopulateProjectDropDownSp(CallForm);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateProjectTaskDropDownSp(string ProjNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateProjectTaskDropDownExt = new CLM_FTSLPopulateProjectTaskDropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateProjectTaskDropDownExt.CLM_FTSLPopulateProjectTaskDropDownSp(ProjNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateSRODropDownSp(string CallForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateSRODropDownExt = new CLM_FTSLPopulateSRODropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateSRODropDownExt.CLM_FTSLPopulateSRODropDownSp(CallForm);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateSROLineDropDownSp(string CallForm,
		string SroNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateSROLineDropDownExt = new CLM_FTSLPopulateSROLineDropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateSROLineDropDownExt.CLM_FTSLPopulateSROLineDropDownSp(CallForm,
				SroNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLPopulateSROOperationDropDownSp(string CallForm,
		string SroNum,
		int? SroLine)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLPopulateSROOperationDropDownExt = new CLM_FTSLPopulateSROOperationDropDownFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLPopulateSROOperationDropDownExt.CLM_FTSLPopulateSROOperationDropDownSp(CallForm,
				SroNum,
				SroLine);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLQcsGetSerialNumbersSp([Optional] string Job,
		[Optional, DefaultParameterValue(0)] int? Suffix,
		string TransactionType,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLQcsGetSerialNumbersExt = new CLM_FTSLQcsGetSerialNumbersFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLQcsGetSerialNumbersExt.CLM_FTSLQcsGetSerialNumbersSp(Job,
				Suffix,
				TransactionType,
				Item,
				Whse,
				Loc,
				Lot,
				Site);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLQCSGetTestdDetailsSp(string RcvrNum,
		int? Page)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLQCSGetTestdDetailsExt = new CLM_FTSLQCSGetTestdDetailsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLQCSGetTestdDetailsExt.CLM_FTSLQCSGetTestdDetailsSp(RcvrNum,
				Page);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLQCSGetTesteachDetailsSp(string RcvrNum,
		int? Page)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLQCSGetTesteachDetailsExt = new CLM_FTSLQCSGetTesteachDetailsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLQCSGetTesteachDetailsExt.CLM_FTSLQCSGetTesteachDetailsSp(RcvrNum,
				Page);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLSerialSelectSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLSerialSelectExt = new CLM_FTSLSerialSelectFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLSerialSelectExt.CLM_FTSLSerialSelectSp(Item,
				Whse,
				Loc,
				Lot,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLTaskLabelSp(string Type,
		int? FromRange,
		int? ToRange,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLTaskLabelExt = new CLM_FTSLTaskLabelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLTaskLabelExt.CLM_FTSLTaskLabelSp(Type,
				FromRange,
				ToRange,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLValidateProjTaskSp(string ValidateType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLValidateProjTaskExt = new CLM_FTSLValidateProjTaskFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLValidateProjTaskExt.CLM_FTSLValidateProjTaskSp(ValidateType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLVisualDispatchSp([Optional] string ResGrp,
		[Optional] string Job)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_FTSLVisualDispatchExt = new CLM_FTSLVisualDispatchFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_FTSLVisualDispatchExt.CLM_FTSLVisualDispatchSp(ResGrp,
				Job);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTInsertIntoTmpserSp(Guid? SessionID,
                string Ser_num,
                string RefStr,
                string Item,
                byte? FlagInvCheck,
                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTInsertIntoTmpserExt = new FTInsertIntoTmpserFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTInsertIntoTmpserExt.FTInsertIntoTmpserSp(SessionID,
				Ser_num,
				RefStr,
				Item,
				FlagInvCheck,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSL_BflushLotSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		int? Selected,
		string Job,
		string JobMatlItem,
		string Loc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSL_BflushLotSaveExt = new FTSL_BflushLotSaveFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSL_BflushLotSaveExt.FTSL_BflushLotSaveSp(TransNum,
				Whse,
				Lot,
				Selected,
				Job,
				JobMatlItem,
				Loc);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSL_BflushSerialSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		int? Selected,
		string JobMatlItem,
		string Loc,
		string SerNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSL_BflushSerialSaveExt = new FTSL_BflushSerialSaveFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSL_BflushSerialSaveExt.FTSL_BflushSerialSaveSp(TransNum,
				Whse,
				Lot,
				Selected,
				JobMatlItem,
				Loc,
				SerNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLCheckBackflushNeededSp(byte? BackflushByLot,
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
                ref int? BflushSerialNeeded)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLCheckBackflushNeededExt = new FTSLCheckBackflushNeededFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLCheckBackflushNeededExt.FTSLCheckBackflushNeededSp(BackflushByLot,
				TransClass,
				TransNum,
				Job,
				Suffix,
				OperNum,
				JobItem,
				PhantomMulti,
				PhantomUnits,
				PhantomScrap,
				TransDate,
				Whse,
				Lot,
				RouteQtyComplete,
				RouteQtyScrapped,
				EmpNum,
				Infobar,
				BflushLotNeeded,
				BflushSerialNeeded);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				BflushLotNeeded = result.BflushLotNeeded;
				BflushSerialNeeded = result.BflushSerialNeeded;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLCheckQtyOnCloseJobSp(string Job,
                short? Suffix,
                int? OperNum,
                ref decimal? OperQtyComplete,
                ref decimal? OperQtyMoved,
                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLCheckQtyOnCloseJobExt = new FTSLCheckQtyOnCloseJobFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLCheckQtyOnCloseJobExt.FTSLCheckQtyOnCloseJobSp(Job,
				Suffix,
				OperNum,
				OperQtyComplete,
				OperQtyMoved,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperQtyComplete = result.OperQtyComplete;
				OperQtyMoved = result.OperQtyMoved;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLCheckQtyReceivedSp(string Job,
                short? Suffix,
                int? OperNum,
                ref decimal? OperQtyComplete,
                ref decimal? OperQtyScrapped,
                ref decimal? OperQtyReceived,
                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLCheckQtyReceivedExt = new FTSLCheckQtyReceivedFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLCheckQtyReceivedExt.FTSLCheckQtyReceivedSp(Job,
				Suffix,
				OperNum,
				OperQtyComplete,
				OperQtyScrapped,
				OperQtyReceived,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperQtyComplete = result.OperQtyComplete;
				OperQtyScrapped = result.OperQtyScrapped;
				OperQtyReceived = result.OperQtyReceived;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLGetPOPreAssignedSerialsSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string InPutSerials,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLGetPOPreAssignedSerialsExt = new FTSLGetPOPreAssignedSerialsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLGetPOPreAssignedSerialsExt.FTSLGetPOPreAssignedSerialsSp(Item,
				Whse,
				Loc,
				Lot,
				InPutSerials,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLGetProjectTaksMatlSp(string ProjNum,
		[Optional, DefaultParameterValue(0)] int? TaskNum,
		[Optional, DefaultParameterValue(0)] int? Seq,
		[Optional, DefaultParameterValue("")] string Item,
		[Optional, DefaultParameterValue(0)] int? OverIssue)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLGetProjectTaksMatlExt = new FTSLGetProjectTaksMatlFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLGetProjectTaksMatlExt.FTSLGetProjectTaksMatlSp(ProjNum,
				TaskNum,
				Seq,
				Item,
				OverIssue);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetPSJITInfoSp(string Item,
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
		[Optional, DefaultParameterValue(0)] ref int? SymixSuffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLGetPSJITInfoExt = new FTSLGetPSJITInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLGetPSJITInfoExt.FTSLGetPSJITInfoSp(Item,
				PsNum,
				Wc,
				OperNum,
				ItemDescription,
				ItemUM,
				ItemLotTracked,
				ItemSerialTracked,
				WcDescription,
				Whse,
				Loc,
				QtyExpected,
				QtyCompleted,
				QtyScrapped,
				SymixJob,
				IsLastOper,
				QtyRemaining,
				DueDate,
				SymixSuffix);
				
				int Severity = result.ReturnCode.Value;
				ItemDescription = result.ItemDescription;
				ItemUM = result.ItemUM;
				ItemLotTracked = result.ItemLotTracked;
				ItemSerialTracked = result.ItemSerialTracked;
				WcDescription = result.WcDescription;
				Whse = result.Whse;
				Loc = result.Loc;
				QtyExpected = result.QtyExpected;
				QtyCompleted = result.QtyCompleted;
				QtyScrapped = result.QtyScrapped;
				SymixJob = result.SymixJob;
				IsLastOper = result.IsLastOper;
				QtyRemaining = result.QtyRemaining;
				DueDate = result.DueDate;
				SymixSuffix = result.SymixSuffix;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLGetShipmentLinesSp(decimal? ShipmentId,
		decimal? PickListId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLGetShipmentLinesExt = new FTSLGetShipmentLinesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLGetShipmentLinesExt.FTSLGetShipmentLinesSp(ShipmentId,
				PickListId,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLGetShipmentsSp(decimal? ShipmentId,
		string ShipLoc,
		string PackLoc,
		string Order,
		string ShipTo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLGetShipmentsExt = new FTSLGetShipmentsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLGetShipmentsExt.FTSLGetShipmentsSp(ShipmentId,
				ShipLoc,
				PackLoc,
				Order,
				ShipTo,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLItemCountSp(string Whse,
		string Item,
		string UnCount,
		string Loc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLItemCountExt = new FTSLItemCountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLItemCountExt.FTSLItemCountSp(Whse,
				Item,
				UnCount,
				Loc);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLItemCountVerifySp(string Whse,
		string Mismatch,
		string Serial,
		string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLItemCountVerifyExt = new FTSLItemCountVerifyFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLItemCountVerifyExt.FTSLItemCountVerifySp(Whse,
				Mismatch,
				Serial,
				Lot);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLItemPackageSelectSp(decimal? ShipmentId,
		int? PackageId,
		string ERPQueryResponseString,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLItemPackageSelectExt = new FTSLItemPackageSelectFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLItemPackageSelectExt.FTSLItemPackageSelectSp(ShipmentId,
				PackageId,
				ERPQueryResponseString,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLJobEfficiencyCalculationSp(string Job,
		int? Suffix,
		int? Operation,
		DateTime? CurrDate,
		int? RefreshInterval,
		decimal? HighEfficiencyLevel,
		decimal? MediumEfficiencyLevel,
		DateTime? StartTime,
		ref int? Color)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLJobEfficiencyCalculationExt = new FTSLJobEfficiencyCalculationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLJobEfficiencyCalculationExt.FTSLJobEfficiencyCalculationSp(Job,
				Suffix,
				Operation,
				CurrDate,
				RefreshInterval,
				HighEfficiencyLevel,
				MediumEfficiencyLevel,
				StartTime,
				Color);
				
				int Severity = result.ReturnCode.Value;
				Color = result.Color;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLJobOpEmployeeSkillValidationSp(string EmpNum,
		string Job,
		int? Suffix,
		int? Operation,
		ref string Infobar,
		DateTime? PunchDate,
		string ERPQueryResponseString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLJobOpEmployeeSkillValidationExt = new FTSLJobOpEmployeeSkillValidationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLJobOpEmployeeSkillValidationExt.FTSLJobOpEmployeeSkillValidationSp(EmpNum,
				Job,
				Suffix,
				Operation,
				Infobar,
				PunchDate,
				ERPQueryResponseString);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLJobOpTeamSkillValidationSp(string Team,
		string Job,
		int? Suffix,
		int? Operation,
		ref string Infobar,
		DateTime? PunchDate,
		string EmpNums,
		string ERPQueryResponseString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLJobOpTeamSkillValidationExt = new FTSLJobOpTeamSkillValidationFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLJobOpTeamSkillValidationExt.FTSLJobOpTeamSkillValidationSp(Team,
				Job,
				Suffix,
				Operation,
				Infobar,
				PunchDate,
				EmpNums,
				ERPQueryResponseString);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLMESGetEmployeeInfoSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLMESGetEmployeeInfoExt = new FTSLMESGetEmployeeInfoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLMESGetEmployeeInfoExt.FTSLMESGetEmployeeInfoSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLPreAssignedSnSelectSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLPreAssignedSnSelectExt = new FTSLPreAssignedSnSelectFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLPreAssignedSnSelectExt.FTSLPreAssignedSnSelectSp(Item,
				Whse,
				Loc,
				Lot,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLQCSGetTestEachStatusSp(string RcvrNum,
		string Item,
		int? Sequence,
		decimal? ActualValue,
		ref int? PassStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLQCSGetTestEachStatusExt = new FTSLQCSGetTestEachStatusFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLQCSGetTestEachStatusExt.FTSLQCSGetTestEachStatusSp(RcvrNum,
				Item,
				Sequence,
				ActualValue,
				PassStatus);
				
				int Severity = result.ReturnCode.Value;
				PassStatus = result.PassStatus;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLTAGetResourceIdSp(int? DisplayResourceId,
		int? OnlyAllowResource,
		string Job,
		int? Suffix,
		int? Operation)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLTAGetResourceIdExt = new FTSLTAGetResourceIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLTAGetResourceIdExt.FTSLTAGetResourceIdSp(DisplayResourceId,
				OnlyAllowResource,
				Job,
				Suffix,
				Operation);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLTeamMemberReportingSp(string OrderNumber,
		int? Suffix,
		int? Operation,
		[Optional] string Loc,
		[Optional] string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLTeamMemberReportingExt = new FTSLTeamMemberReportingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLTeamMemberReportingExt.FTSLTeamMemberReportingSp(OrderNumber,
				Suffix,
				Operation,
				Loc,
				Lot);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLValidServiceLaborSp(string CallForm,
		string EmpNum,
		string SroNum,
		int? SroLine,
		int? SroOper,
		int? TTImplemented,
		string PartnerId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLValidServiceLaborExt = new FTSLValidServiceLaborFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLValidServiceLaborExt.FTSLValidServiceLaborSp(CallForm,
				EmpNum,
				SroNum,
				SroLine,
				SroOper,
				TTImplemented,
				PartnerId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTSLWMEndTeamRunSp(string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTSLWMEndTeamRunExt = new FTSLWMEndTeamRunFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTSLWMEndTeamRunExt.FTSLWMEndTeamRunSp(Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FTTAOrderDownloadSp(string OrderType,
		string OrderNumber,
		string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFTTAOrderDownloadExt = new FTTAOrderDownloadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFTTAOrderDownloadExt.FTTAOrderDownloadSp(OrderType,
				OrderNumber,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLGetSerialNumbersSROSp(Guid? SessionID,
		[Optional] string Job,
		[Optional, DefaultParameterValue(0)] int? Suffix,
		string TransactionType,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string Site,
		[Optional] string RefNum,
		[Optional, DefaultParameterValue(0)] int? RefLine,
		[Optional, DefaultParameterValue(0)] int? RefRelease)
		{
			var iCLM_FTSLGetSerialNumbersSROExt = new CLM_FTSLGetSerialNumbersSROFactory().Create(this, true);
			
			var result = iCLM_FTSLGetSerialNumbersSROExt.CLM_FTSLGetSerialNumbersSROSp(SessionID,
			Job,
			Suffix,
			TransactionType,
			Item,
			Whse,
			Loc,
			Lot,
			Site,
			RefNum,
			RefLine,
			RefRelease);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FTSLLoadPOXdocOrderItemsSp(string Item,
		string Whse,
		string Job,
		int? priority_1,
		int? priority_2,
		int? priority_3,
		int? priority_4,
		int? priority_5,
		int? future_days_1,
		int? future_days_2,
		int? future_days_3,
		int? future_days_4,
		int? future_days_5)
		{
			var iCLM_FTSLLoadPOXdocOrderItemsExt = new CLM_FTSLLoadPOXdocOrderItemsFactory().Create(this, true);
			
			var result = iCLM_FTSLLoadPOXdocOrderItemsExt.CLM_FTSLLoadPOXdocOrderItemsSp(Item,
			Whse,
			Job,
			priority_1,
			priority_2,
			priority_3,
			priority_4,
			priority_5,
			future_days_1,
			future_days_2,
			future_days_3,
			future_days_4,
			future_days_5);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLRSQC_UpdateCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? QtyCOC,
		ref string Infobar)
		{
			var iFTSLRSQC_UpdateCOCExt = new FTSLRSQC_UpdateCOCFactory().Create(this, true);
			
			var result = iFTSLRSQC_UpdateCOCExt.FTSLRSQC_UpdateCOCSp(CoNum,
			CoLine,
			CoRelease,
			QtyCOC,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FTSLGetProductionScheduleDetailsSp(string Item,
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
		ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iFTSLGetProductionScheduleDetailsExt = new FTSLGetProductionScheduleDetailsFactory().Create(appDb);

				var result = iFTSLGetProductionScheduleDetailsExt.FTSLGetProductionScheduleDetailsSp(Item,
																										PsNum,
																										Wc,
																										OperNum,
																										DueDate,
																										ItemDescription,
																										ItemUM,
																										ItemLotTracked,
																										ItemSerialTracked,
																										WcDescription,
																										Whse,
																										Loc,
																										QtyExpected,
																										QtyCompleted,
																										QtyScrapped,
																										QtyRemaining,
																										SymixJob,
																										SymixSuffix,
																										PSBehind,
																										PSAhead,
																										Infobar);

				int Severity = result.ReturnCode.Value;
				ItemDescription = result.ItemDescription;
				ItemUM = result.ItemUM;
				ItemLotTracked = result.ItemLotTracked;
				ItemSerialTracked = result.ItemSerialTracked;
				WcDescription = result.WcDescription;
				Whse = result.Whse;
				Loc = result.Loc;
				QtyExpected = result.QtyExpected;
				QtyCompleted = result.QtyCompleted;
				QtyScrapped = result.QtyScrapped;
				QtyRemaining = result.QtyRemaining;
				SymixJob = result.SymixJob;
				SymixSuffix = result.SymixSuffix;
				PSBehind = result.PSBehind;
				PSAhead = result.PSAhead;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}

