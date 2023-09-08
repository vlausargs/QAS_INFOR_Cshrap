//PROJECT NAME: CustomerExt
//CLASS NAME: SLArtranAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
using CSI.Data.RecordSets;
using CSI.Logistics.Vendor;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLArtranAlls")]
	public class SLArtranAlls : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARAPOffsetCreateARPaymentSp(string CustNum,
											   decimal? ExchRate,
											   byte? FixedRate,
											   string InvNum,
											   string Site,
											   decimal? OffsetAmt,
											   string CoNum,
											   string DoNum,
											   decimal? ShipmentId,
											   string OffsetAcct,
											   string OffsetAcctUnit1,
											   string OffsetAcctUnit2,
											   string OffsetAcctUnit3,
											   string OffsetAcctUnit4,
											   byte? CreateArpmt,
											   ref string Infobar,
											   string ApplyCustNum,
                                               string THPaymentNumberPrefix)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iARAPOffsetCreateARPaymentExt = new ARAPOffsetCreateARPaymentFactory().Create(appDb);

				InfobarType oInfobar = Infobar;

				int Severity = iARAPOffsetCreateARPaymentExt.ARAPOffsetCreateARPaymentSp(CustNum,
																						 ExchRate,
																						 FixedRate,
																						 InvNum,
																						 Site,
																						 OffsetAmt,
																						 CoNum,
																						 DoNum,
																						 ShipmentId,
																						 OffsetAcct,
																						 OffsetAcctUnit1,
																						 OffsetAcctUnit2,
																						 OffsetAcctUnit3,
																						 OffsetAcctUnit4,
																						 CreateArpmt,
																						 ref oInfobar,
																						 ApplyCustNum,
                                                                                         THPaymentNumberPrefix);

				Infobar = oInfobar;

				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArsummHasSubordinatesSp(string PCustNum,
										   ref byte? PSubordinate,
										   ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iArsummHasSubordinatesExt = new ArsummHasSubordinatesFactory().Create(appDb);

				ListYesNoType oPSubordinate = PSubordinate;
				InfobarType oInfobar = Infobar;

				int Severity = iArsummHasSubordinatesExt.ArsummHasSubordinatesSp(PCustNum,
																				 ref oPSubordinate,
																				 ref oInfobar);

				PSubordinate = oPSubordinate;
				Infobar = oInfobar;

				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DefARPostedTransFilterSp(string SiteQuery,
											ref string SiteFilterVar,
											ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iDefARPostedTransFilterExt = new DefARPostedTransFilterFactory().Create(appDb);

				StringType oSiteFilterVar = SiteFilterVar;
				InfobarType oInfobar = Infobar;

				int Severity = iDefARPostedTransFilterExt.DefARPostedTransFilterSp(SiteQuery,
																				   ref oSiteFilterVar,
																				   ref oInfobar);

				SiteFilterVar = oSiteFilterVar;
				Infobar = oInfobar;

				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateCoNumXrefSp(string DerCoNumXref,
			string CoNum,
			string InvNum,
			string SiteRef,
			ref string Infobar)
		{
			var iValidateCoNumXrefExt = new ValidateCoNumXrefFactory().Create(this, true);

			var result = iValidateCoNumXrefExt.ValidateCoNumXrefSp(DerCoNumXref,
				CoNum,
				InvNum,
				SiteRef,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LCDomCurrSp(string CurrCode1,
										 [Optional, DefaultParameterValue((byte)0)] byte? UseBuyRate,
		[Optional] decimal? TRate1,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? V1Amount1,
		[Optional] decimal? V1Amount2,
		[Optional] decimal? V1Amount3,
		[Optional] decimal? V1Amount4,
		[Optional] decimal? V1Amount5,
		string CurrCode2,
		[Optional] decimal? TRate2,
		[Optional] decimal? V2Amount1,
		[Optional] decimal? V2Amount2,
		[Optional] decimal? V2Amount3,
		[Optional] decimal? V2Amount4,
		[Optional] decimal? V2Amount5,
		string CurrCode3,
		[Optional] decimal? TRate3,
		[Optional] decimal? V3Amount1,
		[Optional] decimal? V3Amount2,
		[Optional] decimal? V3Amount3,
		[Optional] decimal? V3Amount4,
		[Optional] decimal? V3Amount5,
		string CurrCode4,
		[Optional] decimal? TRate4,
		[Optional] decimal? V4Amount1,
		[Optional] decimal? V4Amount2,
		[Optional] decimal? V4Amount3,
		[Optional] decimal? V4Amount4,
		[Optional] decimal? V4Amount5,
		[Optional] decimal? V4Amount6,
		[Optional] decimal? V4Amount7,
		[Optional] decimal? V4Amount8,
		[Optional] decimal? V4Amount9,
		[Optional] decimal? V4Amount10,
		[Optional] decimal? V4Amount11,
		string CurrCode5,
		[Optional] decimal? TRate5,
		[Optional] decimal? V5Amount1,
		[Optional] decimal? V5Amount2,
		[Optional] decimal? V5Amount3,
		[Optional] decimal? V5Amount4,
		[Optional] decimal? V5Amount5,
		string CurrCode6,
		[Optional] decimal? TRate6,
		[Optional] decimal? V6Amount1,
		[Optional] decimal? V6Amount2,
		[Optional] decimal? V6Amount3,
		[Optional] decimal? V6Amount4,
		[Optional] decimal? V6Amount5,
		[Optional] string PoNum,
		[Optional] string GrnNum)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var iCLM_LCDomCurrExt = new CLM_LCDomCurrFactory().Create(appDb, bunchedLoadCollection);

				var result = iCLM_LCDomCurrExt.CLM_LCDomCurrSp(CurrCode1,
															   UseBuyRate,
															   TRate1,
															   PossibleDate,
															   V1Amount1,
															   V1Amount2,
															   V1Amount3,
															   V1Amount4,
															   V1Amount5,
															   CurrCode2,
															   TRate2,
															   V2Amount1,
															   V2Amount2,
															   V2Amount3,
															   V2Amount4,
															   V2Amount5,
															   CurrCode3,
															   TRate3,
															   V3Amount1,
															   V3Amount2,
															   V3Amount3,
															   V3Amount4,
															   V3Amount5,
															   CurrCode4,
															   TRate4,
															   V4Amount1,
															   V4Amount2,
															   V4Amount3,
															   V4Amount4,
															   V4Amount5,
															   V4Amount6,
															   V4Amount7,
															   V4Amount8,
															   V4Amount9,
															   V4Amount10,
															   V4Amount11,
															   CurrCode5,
															   TRate5,
															   V5Amount1,
															   V5Amount2,
															   V5Amount3,
															   V5Amount4,
															   V5Amount5,
															   CurrCode6,
															   TRate6,
															   V6Amount1,
															   V6Amount2,
															   V6Amount3,
															   V6Amount4,
															   V6Amount5,
															   PoNum,
															   GrnNum);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateInvoiceBatchIDOnARSp(string InvNum,
		decimal? InvBatchID)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iUpdateInvoiceBatchIDOnARExt = new UpdateInvoiceBatchIDOnARFactory().Create(appDb);

				var result = iUpdateInvoiceBatchIDOnARExt.UpdateInvoiceBatchIDOnARSp(InvNum,
				InvBatchID);

				int Severity = result.Value;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArtranUpdRemCallSp(string Site,
		Guid? RowPointer,
		string ArtranType,
		string CustNum,
		string InvNum,
		int? InvSeq,
		int? CheckSeq,
		string CoNum,
		string Description,
		int? Active,
		DateTime? DueDate,
		DateTime? InvDate,
		DateTime? DiscDate,
		string ApplyToInvNum,
		DateTime? InvHdrTaxDate,
		decimal? ExchRate)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iArtranUpdRemCallExt = new ArtranUpdRemCallFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iArtranUpdRemCallExt.ArtranUpdRemCallSp(Site,
				RowPointer,
				ArtranType,
				CustNum,
				InvNum,
				InvSeq,
				CheckSeq,
				CoNum,
				Description,
				Active,
				DueDate,
				InvDate,
				DiscDate,
				ApplyToInvNum,
				InvHdrTaxDate,
				ExchRate);

				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcARGainLossSp(string CustNum,
		string InvNum,
		string CustCurrCode,
		decimal? Amount,
		decimal? DiscAmt,
		decimal? ExchRate,
		int? UseHistRate,
		string Site,
		int? InvSeq,
		int? CheckSeq,
		ref decimal? DomGainAmt,
		ref string Infobar)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iCalcARGainLossExt = new CalcARGainLossFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iCalcARGainLossExt.CalcARGainLossSp(CustNum,
				InvNum,
				CustCurrCode,
				Amount,
				DiscAmt,
				ExchRate,
				UseHistRate,
				Site,
				InvSeq,
				CheckSeq,
				DomGainAmt,
				Infobar);

				int Severity = result.ReturnCode.Value;
				DomGainAmt = result.DomGainAmt;
				Infobar = result.Infobar;
				return Severity;
			}
		}





































		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PortalArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string PDisplayType,
		DateTime? PFromDate,
		DateTime? PToDate)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iCLM_PortalArsummvExt = new CLM_PortalArsummvFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iCLM_PortalArsummvExt.CLM_PortalArsummvSp(PCustNum,
				PCurrentSite,
				PSubordinate,
				PActive,
				PDisplayType,
				PFromDate,
				PToDate);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileCustomerStatementsSP([Optional] DateTime? StatementDate,
		[Optional] int? ShowActive,
		[Optional] string BeginCustNum,
		[Optional] string EndCustNum,
		[Optional] string SiteGroup,
		[Optional] string StateCycle,
		[Optional] int? PrZeroBal,
		[Optional] int? PrCreditBal,
		[Optional] string PrOpenItem2,
		[Optional] string InvDue,
		[Optional] int? HidePaid,
		[Optional] int? PrOpenPay,
		[Optional] int? StatementDateOffset)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iProfileCustomerStatementsExt = new ProfileCustomerStatementsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iProfileCustomerStatementsExt.ProfileCustomerStatementsSP(StatementDate,
				ShowActive,
				BeginCustNum,
				EndCustNum,
				SiteGroup,
				StateCycle,
				PrZeroBal,
				PrCreditBal,
				PrOpenItem2,
				InvDue,
				HidePaid,
				PrOpenPay,
				StatementDateOffset);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateArtranInvNumSp(Guid? RowPointer,
		int? Filter,
		string ArtranType,
		string CustNum,
		string InvNum,
		int? InvSeq,
		int? CheckSeq,
		string PayType,
		ref string DerInvNum,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		string ApplyToInvNum)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iValidateArtranInvNumExt = new ValidateArtranInvNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iValidateArtranInvNumExt.ValidateArtranInvNumSp(RowPointer,
				Filter,
				ArtranType,
				CustNum,
				InvNum,
				InvSeq,
				CheckSeq,
				PayType,
				DerInvNum,
				PromptMsg,
				PromptButtons,
				Infobar,
				ApplyToInvNum);

				int Severity = result.ReturnCode.Value;
				DerInvNum = result.DerInvNum;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}









		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string ArsummFilter,
		[Optional] string SiteGroup,
		[Optional] string CustaddrCurrCode,
		[Optional] string Salesperson,
		[Optional] int? IncludeDirectReports)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iArsummvExt = new ArsummvFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iArsummvExt.ArsummvSp(PCustNum,
				PCurrentSite,
				PSubordinate,
				PActive,
				ArsummFilter,
				SiteGroup,
				CustaddrCurrCode,
				Salesperson,
				IncludeDirectReports);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(this, true);

			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);

			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}