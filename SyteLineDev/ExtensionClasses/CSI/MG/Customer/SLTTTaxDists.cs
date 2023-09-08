//PROJECT NAME: CustomerExt
//CLASS NAME: SLTTTaxDists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLTTTaxDists")]
	public class SLTTTaxDists : ExtensionClassBase
	{







		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TaxDistLoadSp(string PCoNum,
		                                   [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_TaxDistLoadExt = new CLM_TaxDistLoadFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_TaxDistLoadExt.CLM_TaxDistLoadSp(PCoNum,
				                                                   FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxDistClearSp(string CoNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxDistClearExt = new TaxDistClearFactory().Create(appDb);
				
				var result = iTaxDistClearExt.TaxDistClearSp(CoNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxDistCountSp(string PCoNum,
		ref int? PDistCount,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxDistCountExt = new TaxDistCountFactory().Create(appDb);
				
				var result = iTaxDistCountExt.TaxDistCountSp(PCoNum,
				PDistCount,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PDistCount = result.PDistCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxDistDeleteSp(Guid? PRowPointer,
		string PCoNum,
		int? PSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxDistDeleteExt = new TaxDistDeleteFactory().Create(appDb);
				
				var result = iTaxDistDeleteExt.TaxDistDeleteSp(PRowPointer,
				PCoNum,
				PSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxDistInsertSp(string PCoNum,
		int? PSeq,
		int? PTaxSystem,
		string PTaxCode,
		string PTaxCodeE,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PTaxJur,
		decimal? PTaxRate,
		decimal? PTaxAmount,
		decimal? PTaxBasis,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxDistInsertExt = new TaxDistInsertFactory().Create(appDb);
				
				var result = iTaxDistInsertExt.TaxDistInsertSp(PCoNum,
				PSeq,
				PTaxSystem,
				PTaxCode,
				PTaxCodeE,
				PAcct,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				PTaxJur,
				PTaxRate,
				PTaxAmount,
				PTaxBasis,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxDistUpdateSp(Guid? PRowPointer,
		string PCoNum,
		int? PSeq,
		int? PTaxSystem,
		string PTaxCode,
		string PTaxCodeE,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PTaxJur,
		decimal? PTaxRate,
		decimal? PTaxAmount,
		decimal? PTaxBasis,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxDistUpdateExt = new TaxDistUpdateFactory().Create(appDb);
				
				var result = iTaxDistUpdateExt.TaxDistUpdateSp(PRowPointer,
				PCoNum,
				PSeq,
				PTaxSystem,
				PTaxCode,
				PTaxCodeE,
				PAcct,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				PTaxJur,
				PTaxRate,
				PTaxAmount,
				PTaxBasis,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TaxFactSp(string PTermsCode,
		int? PUseExchRate,
		decimal? PExchRate,
		DateTime? PInvDate,
		string PCurrCode,
		ref decimal? PFactor,
		ref string Infobar,
		[Optional] int? EXTGEN_TaxFactSp_Exists,
		[Optional] string Site,
		[Optional] string DomCurrCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTaxFactExt = new TaxFactFactory().Create(appDb);
				
				var result = iTaxFactExt.TaxFactSp(PTermsCode,
				PUseExchRate,
				PExchRate,
				PInvDate,
				PCurrCode,
				PFactor,
				Infobar,
				EXTGEN_TaxFactSp_Exists,
				Site,
				DomCurrCode);
				
				int Severity = result.ReturnCode.Value;
				PFactor = result.PFactor;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UomConvAmtQtyInvAdjsSp(decimal? AmtToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		ref decimal? ConvertedAmt,
		decimal? QtyToBeConverted,
		ref decimal? ConvertedQty,
		ref string Infobar,
		string PMode,
		string PRecidCo,
		decimal? PMiscCharges,
		decimal? PFreight,
		ref decimal? PSalesTax,
		ref decimal? PSalesTax2,
		ref decimal? PLineNet,
		ref decimal? PPrice,
		ref int? PSeq,
		ref string PromptMsg,
		ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUomConvAmtQtyInvAdjsExt = new UomConvAmtQtyInvAdjsFactory().Create(appDb);
				
				var result = iUomConvAmtQtyInvAdjsExt.UomConvAmtQtyInvAdjsSp(AmtToBeConverted,
				UomConvFactor,
				FROMBase,
				ConvertedAmt,
				QtyToBeConverted,
				ConvertedQty,
				Infobar,
				PMode,
				PRecidCo,
				PMiscCharges,
				PFreight,
				PSalesTax,
				PSalesTax2,
				PLineNet,
				PPrice,
				PSeq,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				ConvertedAmt = result.ConvertedAmt;
				ConvertedQty = result.ConvertedQty;
				Infobar = result.Infobar;
				PSalesTax = result.PSalesTax;
				PSalesTax2 = result.PSalesTax2;
				PLineNet = result.PLineNet;
				PPrice = result.PPrice;
				PSeq = result.PSeq;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvAdjSSp(string PMode,
		string PRecidCo,
		decimal? PMiscCharges,
		decimal? PFreight,
		ref decimal? PSalesTax,
		ref decimal? PSalesTax2,
		ref decimal? PLineNet,
		ref decimal? PPrice,
		ref int? PSeq,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvAdjSExt = new InvAdjSFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvAdjSExt.InvAdjSSp(PMode,
				PRecidCo,
				PMiscCharges,
				PFreight,
				PSalesTax,
				PSalesTax2,
				PLineNet,
				PPrice,
				PSeq,
				PromptMsg,
				PromptButtons,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				PSalesTax = result.PSalesTax;
				PSalesTax2 = result.PSalesTax2;
				PLineNet = result.PLineNet;
				PPrice = result.PPrice;
				PSeq = result.PSeq;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
