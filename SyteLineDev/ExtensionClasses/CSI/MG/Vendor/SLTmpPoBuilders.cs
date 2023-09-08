//PROJECT NAME: VendorExt
//CLASS NAME: SLTmpPoBuilders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLTmpPoBuilders")]
	public class SLTmpPoBuilders : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckPOBuilderViewsSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckPOBuilderViewsExt = new CheckPOBuilderViewsFactory().Create(appDb);
				
				int Severity = iCheckPOBuilderViewsExt.CheckPOBuilderViewsSp();
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetMasterBuyAgreementSp(string Item,
		                                   string VendNum,
		                                   ref byte? MasterBuyAgreement)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetMasterBuyAgreementExt = new GetMasterBuyAgreementFactory().Create(appDb);
				
				int Severity = iGetMasterBuyAgreementExt.GetMasterBuyAgreementSp(Item,
				                                                                 VendNum,
				                                                                 ref MasterBuyAgreement);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsUmcfSameSp(string OtherUM,
		                        string Item,
		                        string VendNum,
		                        string Area,
		                        string FromSite,
		                        string ToSite,
		                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsUmcfSameExt = new IsUmcfSameFactory().Create(appDb);
				
				int Severity = iIsUmcfSameExt.IsUmcfSameSp(OtherUM,
				                                           Item,
				                                           VendNum,
				                                           Area,
				                                           FromSite,
				                                           ToSite,
				                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateVendSiteCurrCodeSp(string CurrSite,
		ref string ToSite,
		string VendNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateVendSiteCurrCodeExt = new ValidateVendSiteCurrCodeFactory().Create(appDb);
				
				var result = iValidateVendSiteCurrCodeExt.ValidateVendSiteCurrCodeSp(CurrSite,
				ToSite,
				VendNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ToSite = result.ToSite;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GenerateIntranetSitesSp([Optional] string SiteFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GenerateIntranetSitesExt = new CLM_GenerateIntranetSitesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GenerateIntranetSitesExt.CLM_GenerateIntranetSitesSp(SiteFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_POBuilderPLNDataSp(int? RecordCap,
			string Site,
			string SiteGroup,
			string ItemStarting,
			string ItemEnding,
			DateTime? StartingDueDate,
			DateTime? EndingDueDate,
			string Planner,
			string VendorCurrCode)
		{
			var iCLM_POBuilderPLNDataExt = this.GetService<ICLM_POBuilderPLNData>();

			var result = iCLM_POBuilderPLNDataExt.CLM_POBuilderPLNDataSp(RecordCap,
				Site,
				SiteGroup,
				ItemStarting,
				ItemEnding,
				StartingDueDate,
				EndingDueDate,
				Planner,
				VendorCurrCode);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POBSaveSecondaryCollSp(Guid? ProcessID,
		string SiteRef,
		string Item,
		string Description,
		string VendItem,
		decimal? QtyOrdered,
		decimal? QtyOrderedConv,
		string UM,
		string Stat,
		decimal? PlanCost,
		decimal? PlanCostConv,
		decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitLocalFreight,
		decimal? UnitLocalFreightConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		DateTime? DueDate,
		DateTime? ReleaseDate,
		string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		int? LcOverride,
		Guid? ApsPlanRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPOBSaveSecondaryCollExt = new POBSaveSecondaryCollFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPOBSaveSecondaryCollExt.POBSaveSecondaryCollSp(ProcessID,
				SiteRef,
				Item,
				Description,
				VendItem,
				QtyOrdered,
				QtyOrderedConv,
				UM,
				Stat,
				PlanCost,
				PlanCostConv,
				UnitMatCost,
				UnitMatCostConv,
				UnitDutyCost,
				UnitDutyCostConv,
				UnitFreightCost,
				UnitFreightCostConv,
				UnitBrokerageCost,
				UnitBrokerageCostConv,
				UnitLocalFreight,
				UnitLocalFreightConv,
				UnitInsuranceCost,
				UnitInsuranceCostConv,
				DueDate,
				ReleaseDate,
				NonInvAcct,
				NonInvAcctUnit1,
				NonInvAcctUnit2,
				NonInvAcctUnit3,
				NonInvAcctUnit4,
				LcOverride,
				ApsPlanRowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POBuilderSP(Guid? ProcessID,
		string Vendor,
		DateTime? Date,
		string POType,
		string Status,
		string CreateAs,
		int? IncludeTaxInCost,
		string TermsCode,
		ref string BuilderPONumber,
		ref string Infobar,
		int? AutoVoucher)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPOBuilderExt = new POBuilderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPOBuilderExt.POBuilderSP(ProcessID,
				Vendor,
				Date,
				POType,
				Status,
				CreateAs,
				IncludeTaxInCost,
				TermsCode,
				BuilderPONumber,
				Infobar,
				AutoVoucher);
				
				int Severity = result.ReturnCode.Value;
				BuilderPONumber = result.BuilderPONumber;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
