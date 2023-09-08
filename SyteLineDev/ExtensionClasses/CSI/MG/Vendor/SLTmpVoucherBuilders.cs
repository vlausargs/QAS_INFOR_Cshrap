//PROJECT NAME: VendorExt
//CLASS NAME: SLTmpVoucherBuilders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLTmpVoucherBuilders")]
	public class SLTmpVoucherBuilders : ExtensionClassBase, IExtFTSLTmpVoucherBuilders
	{





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoucherBuilderDeleteSp(Guid? ProcessID,
		[Optional] string Vend_Num)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoucherBuilderDeleteExt = new VoucherBuilderDeleteFactory().Create(appDb);
				
				var result = iVoucherBuilderDeleteExt.VoucherBuilderDeleteSp(ProcessID,
				Vend_Num);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoucherBuilderProcessSp(Guid? PProcessID,
		string PVendNum,
		int? PAutoVoucher,
		[Optional, DefaultParameterValue("PurchaseOrderReceiving")] string CalledFrom,
		[Optional, DefaultParameterValue(0)] ref int? PoVoucher,
		ref string PBuilderVoucherNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoucherBuilderProcessExt = new VoucherBuilderProcessFactory().Create(appDb);
				
				var result = iVoucherBuilderProcessExt.VoucherBuilderProcessSp(PProcessID,
				PVendNum,
				PAutoVoucher,
				CalledFrom,
				PoVoucher,
				PBuilderVoucherNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PoVoucher = result.PoVoucher;
				PBuilderVoucherNum = result.PBuilderVoucherNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoucherBuilderSaveDistSp(Guid? PRowPointer,
		int? PSelected,
		decimal? PQtyVoucher,
		decimal? PUnitMatCostConv,
		decimal? PFreight,
		decimal? PMiscCharges,
		string PTransNat,
		string PTransNat2,
		DateTime? GLDistDate,
		string PVendorInvoice,
		DateTime? PInvoiceDate,
		string PTerms,
		string PAuthorizer,
		Guid? PProcessID,
		string PVendNum,
		int? PVoucher,
		int? PClearSel,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		DateTime? TaxDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVoucherBuilderSaveDistExt = new VoucherBuilderSaveDistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVoucherBuilderSaveDistExt.VoucherBuilderSaveDistSp(PRowPointer,
				PSelected,
				PQtyVoucher,
				PUnitMatCostConv,
				PFreight,
				PMiscCharges,
				PTransNat,
				PTransNat2,
				GLDistDate,
				PVendorInvoice,
				PInvoiceDate,
				PTerms,
				PAuthorizer,
				PProcessID,
				PVendNum,
				PVoucher,
				PClearSel,
				PSalesTax,
				PSalesTax2,
				TaxDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutoVoucherPromptSaveSp(Guid? PProcessID,
		decimal? PFreight,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		DateTime? GLDistDate,
		string PVendorInvoice,
		DateTime? PInvoiceDate,
		string PTerms,
		DateTime? PTaxDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAutoVoucherPromptSaveExt = new AutoVoucherPromptSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAutoVoucherPromptSaveExt.AutoVoucherPromptSaveSp(PProcessID,
				PFreight,
				PMiscCharges,
				PSalesTax,
				PSalesTax2,
				GLDistDate,
				PVendorInvoice,
				PInvoiceDate,
				PTerms,
				PTaxDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CreatePendingVoucherSp(Guid? PProcessID,
		string PVendNum,
		string PVoucherType,
		string PSite,
		int? PVoucher,
		[Optional] string FilterString,
		[Optional] string PoCurrCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_CreatePendingVoucherExt = new CLM_CreatePendingVoucherFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_CreatePendingVoucherExt.CLM_CreatePendingVoucherSp(PProcessID,
				PVendNum,
				PVoucherType,
				PSite,
				PVoucher,
				FilterString,
				PoCurrCode);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
