//PROJECT NAME: APSExt
//CLASS NAME: SLMATLnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLMATLnnns")]
    public class SLMATLnnns : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLSp(short? AltNo,
		                                  [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetMATLExt = new CLM_ApsGetMATLFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetMATLExt.CLM_ApsGetMATLSp(AltNo,
				                                                 FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMatlDelSp(Guid? Rowp,
		string PMatl,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMatlDelExt = new ApsMatlDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMatlDelExt.ApsMatlDelSp(Rowp,
				PMatl,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMatlInsSp(string MatlID,
		string Descr,
		decimal? QuOnHand,
		decimal? FLeadTime,
		decimal? VLeadTime,
		int? DerExp,
		decimal? FExplTime,
		decimal? VExplTime,
		decimal? OrdMin,
		decimal? OrdMult,
		decimal? OrdMax,
		string UnitMeas,
		decimal? Shrink,
		int? Prec,
		int? LowLevel,
		int? DerSupTol,
		decimal? SupplyTol,
		int? TfRule,
		decimal? TfValue,
		string ShiftID,
		DateTime? ExpoDate,
		int? POTolIn,
		int? POTolOut,
		int? JobTolIn,
		int? JobTolOut,
		int? DerPassMfg,
		int? DerPassPur,
		int? DerAccReq,
		int? DerAccReqNoEnd,
		int? DerUnconst,
		int? DerUnresMfg,
		int? DerMRP,
		int? DerMfgSS,
		int? DerReord,
		int? DerTrans,
		int? DerPurchased,
		int? DerMustUseFuturePOs,
		int? PrtFlags,
		int? AltNo,
		decimal? MinCap,
		int? PURule,
		decimal? PUValue,
		int? DerChargeItem,
		int? DerForecastBOMSupply)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMatlInsExt = new ApsMatlInsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMatlInsExt.ApsMatlInsSp(MatlID,
				Descr,
				QuOnHand,
				FLeadTime,
				VLeadTime,
				DerExp,
				FExplTime,
				VExplTime,
				OrdMin,
				OrdMult,
				OrdMax,
				UnitMeas,
				Shrink,
				Prec,
				LowLevel,
				DerSupTol,
				SupplyTol,
				TfRule,
				TfValue,
				ShiftID,
				ExpoDate,
				POTolIn,
				POTolOut,
				JobTolIn,
				JobTolOut,
				DerPassMfg,
				DerPassPur,
				DerAccReq,
				DerAccReqNoEnd,
				DerUnconst,
				DerUnresMfg,
				DerMRP,
				DerMfgSS,
				DerReord,
				DerTrans,
				DerPurchased,
				DerMustUseFuturePOs,
				PrtFlags,
				AltNo,
				MinCap,
				PURule,
				PUValue,
				DerChargeItem,
				DerForecastBOMSupply);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMatlUpdSp(string MatlID,
		string Descr,
		decimal? QuOnHand,
		decimal? FLeadTime,
		decimal? VLeadTime,
		int? DerExp,
		decimal? FExplTime,
		decimal? VExplTime,
		decimal? OrdMin,
		decimal? OrdMult,
		decimal? OrdMax,
		string UnitMeas,
		decimal? Shrink,
		int? Prec,
		int? LowLevel,
		decimal? MinCap,
		int? DerSupTol,
		decimal? SupplyTol,
		int? TfRule,
		decimal? TfValue,
		string ShiftID,
		DateTime? ExpoDate,
		int? POTolIn,
		int? POTolOut,
		int? JobTolIn,
		int? JobTolOut,
		int? DerPassMfg,
		int? DerPassPur,
		int? DerAccReq,
		int? DerAccReqNoEnd,
		int? DerUnconst,
		int? DerUnresMfg,
		int? DerMRP,
		int? DerMfgSS,
		int? DerReord,
		int? DerTrans,
		int? DerPurchased,
		int? DerMustUseFuturePOs,
		int? PrtFlags,
		Guid? RowP,
		int? AltNo,
		int? PURule,
		decimal? PUValue,
		int? DerChargeItem,
		int? DerForecastBOMSupply)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMatlUpdExt = new ApsMatlUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMatlUpdExt.ApsMatlUpdSp(MatlID,
				Descr,
				QuOnHand,
				FLeadTime,
				VLeadTime,
				DerExp,
				FExplTime,
				VExplTime,
				OrdMin,
				OrdMult,
				OrdMax,
				UnitMeas,
				Shrink,
				Prec,
				LowLevel,
				MinCap,
				DerSupTol,
				SupplyTol,
				TfRule,
				TfValue,
				ShiftID,
				ExpoDate,
				POTolIn,
				POTolOut,
				JobTolIn,
				JobTolOut,
				DerPassMfg,
				DerPassPur,
				DerAccReq,
				DerAccReqNoEnd,
				DerUnconst,
				DerUnresMfg,
				DerMRP,
				DerMfgSS,
				DerReord,
				DerTrans,
				DerPurchased,
				DerMustUseFuturePOs,
				PrtFlags,
				RowP,
				AltNo,
				PURule,
				PUValue,
				DerChargeItem,
				DerForecastBOMSupply);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetAltsItemIdSp(int? AltNo1,
		int? AltNo2,
		[Optional] string ItemFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetAltsItemIdExt = new CLM_ApsGetAltsItemIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetAltsItemIdExt.CLM_ApsGetAltsItemIdSp(AltNo1,
				AltNo2,
				ItemFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetItemIdSp(int? AltNo,
		[Optional] string MaterialIdFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetItemIdExt = new CLM_ApsGetItemIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetItemIdExt.CLM_ApsGetItemIdSp(AltNo,
				MaterialIdFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLPlusSp(int? AltNo,
			[Optional] string MaterialIdFilter)
		{
			var iCLM_ApsGetMATLPlusExt = this.GetService<ICLM_ApsGetMATLPlus>();
			
			var result = iCLM_ApsGetMATLPlusExt.CLM_ApsGetMATLPlusSp(AltNo,
				MaterialIdFilter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsWhatIfEXRCPTItemSp(int? AltNo,
			[Optional] string MaterialIdFilter)
		{
			var iCLM_ApsWhatIfEXRCPTItemExt = this.GetService<ICLM_ApsWhatIfEXRCPTItem>();
			
			var result = iCLM_ApsWhatIfEXRCPTItemExt.CLM_ApsWhatIfEXRCPTItemSp(AltNo,
				MaterialIdFilter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
    }
}
