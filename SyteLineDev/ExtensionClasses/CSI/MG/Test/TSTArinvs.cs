//PROJECT NAME: TestExt
//CLASS NAME: TSTArinvs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Test;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Customer;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Test
{
    [IDOExtensionClass("TSTArinvs")]
    public class TSTArinvs : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArinvCustomerInfoSp(string CustNum,
		string ArinvType,
		DateTime? InvoiceDate,
		ref DateTime? DueDate,
		ref string CustType,
		ref string TermsCode,
		ref string PayType,
		ref string TaxCode1,
		ref string TaxCode2,
		ref string CurrCode,
		ref decimal? ExchRate,
		ref int? CurrRateIsFixed,
		ref int? UseExchRate,
		ref string Acct,
		ref string AcctUnit1,
		ref string AcctUnit2,
		ref string AcctUnit3,
		ref string AcctUnit4,
		ref string AccessUnit1,
		ref string AccessUnit2,
		ref string AccessUnit3,
		ref string AccessUnit4,
		ref string Infobar,
		string App_To_Inv_Num,
		ref int? IsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArinvCustomerInfoExt = new ArinvCustomerInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArinvCustomerInfoExt.ArinvCustomerInfoSp(CustNum,
				ArinvType,
				InvoiceDate,
				DueDate,
				CustType,
				TermsCode,
				PayType,
				TaxCode1,
				TaxCode2,
				CurrCode,
				ExchRate,
				CurrRateIsFixed,
				UseExchRate,
				Acct,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4,
				AccessUnit1,
				AccessUnit2,
				AccessUnit3,
				AccessUnit4,
				Infobar,
				App_To_Inv_Num,
				IsControl);
				
				int Severity = result.ReturnCode.Value;
				DueDate = result.DueDate;
				CustType = result.CustType;
				TermsCode = result.TermsCode;
				PayType = result.PayType;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				CurrCode = result.CurrCode;
				ExchRate = result.ExchRate;
				CurrRateIsFixed = result.CurrRateIsFixed;
				UseExchRate = result.UseExchRate;
				Acct = result.Acct;
				AcctUnit1 = result.AcctUnit1;
				AcctUnit2 = result.AcctUnit2;
				AcctUnit3 = result.AcctUnit3;
				AcctUnit4 = result.AcctUnit4;
				AccessUnit1 = result.AccessUnit1;
				AccessUnit2 = result.AccessUnit2;
				AccessUnit3 = result.AccessUnit3;
				AccessUnit4 = result.AccessUnit4;
				Infobar = result.Infobar;
				IsControl = result.IsControl;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArinvInvNumValidateSp(string CustNum,
		string ArinvType,
		string InvNum,
		DateTime? InvDate,
		string CalledFrom,
		ref string PromptMsg,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? IsApplyToInvNum,
		[Optional] ref string CoNum,
		[Optional] ref string PCurrCode,
		[Optional] ref DateTime? PTaxDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArinvInvNumValidateExt = new ArinvInvNumValidateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArinvInvNumValidateExt.ArinvInvNumValidateSp(CustNum,
				ArinvType,
				InvNum,
				InvDate,
				CalledFrom,
				PromptMsg,
				Infobar,
				IsApplyToInvNum,
				CoNum,
				PCurrCode,
				PTaxDate);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				Infobar = result.Infobar;
				CoNum = result.CoNum;
				PCurrCode = result.PCurrCode;
				PTaxDate = result.PTaxDate;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDueDateSp(string ArinvType,
		string TermsCode,
		DateTime? InvoiceDate,
		ref DateTime? DueDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDueDateExt = new GetDueDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDueDateExt.GetDueDateSp(ArinvType,
				TermsCode,
				InvoiceDate,
				DueDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DueDate = result.DueDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetKeyLengthSp(string KeyName,
		ref int? KeyLength,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetKeyLengthExt = new GetKeyLengthFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetKeyLengthExt.GetKeyLengthSp(KeyName,
				KeyLength,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				KeyLength = result.KeyLength;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvPostingAutoDistSp(Guid? PSessionID,
		string PCustNum,
		string PInvNum,
		int? PInvSeq,
		ref string Infobar,
		[Optional] string ToSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvPostingAutoDistExt = new InvPostingAutoDistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvPostingAutoDistExt.InvPostingAutoDistSp(PSessionID,
				PCustNum,
				PInvNum,
				PInvSeq,
				Infobar,
				ToSite);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable InvPostingCreateTTSp(string PStartingCustNum,
		string PEndingCustNum,
		string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		string PInvoice,
		string PDebitMemo,
		string PCreditMemo,
		Guid? PSessionID,
		[Optional] string StartBuilderInvNum,
		[Optional] string EndBuilderInvNum,
		[Optional] string ToSite,
		[Optional, DefaultParameterValue(0)] int? CalledFromBackground,
		[Optional, DefaultParameterValue(0)] int? SkipResultSet)
		{
			var iInvPostingCreateTTExt = new InvPostingCreateTTFactory().Create(this, true);
			
			var result = iInvPostingCreateTTExt.InvPostingCreateTTSp(PStartingCustNum,
			PEndingCustNum,
			PStartingInvNum,
			PEndingInvNum,
			PStartingInvDate,
			PEndingInvDate,
			PStartingDueDate,
			PEndingDueDate,
			PInvoice,
			PDebitMemo,
			PCreditMemo,
			PSessionID,
			StartBuilderInvNum,
			EndBuilderInvNum,
			ToSite,
			CalledFromBackground,
			SkipResultSet);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvPostingDeleteTTSp(Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvPostingDeleteTTExt = new InvPostingDeleteTTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvPostingDeleteTTExt.InvPostingDeleteTTSp(PSessionID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvPostingLockJournSp(Guid? PSessionID,
		decimal? PUserID,
		ref Guid? PJHeaderRowPointer,
		ref string Infobar,
		[Optional] string ToSite,
		[Optional, DefaultParameterValue(1)] int? LockJournal)
		{
			var iInvPostingLockJournExt = new InvPostingLockJournFactory().Create(this, true);
			
			var result = iInvPostingLockJournExt.InvPostingLockJournSp(PSessionID,
			PUserID,
			PJHeaderRowPointer,
			Infobar,
			ToSite,
			LockJournal);
			
			int Severity = result.ReturnCode.Value;
			PJHeaderRowPointer = result.PJHeaderRowPointer;
			Infobar = result.Infobar;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvPostingSp(Guid? PSessionID,
		string PCustNum,
		string PInvNum,
		int? PInvSeq,
		Guid? PJHeaderRowPointer,
		ref int? PostExtFin,
		ref decimal? ExtFinOperationCounter,
		ref string Infobar,
		[Optional] string ToSite,
		[Optional] string PostSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvPostingExt = new InvPostingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvPostingExt.InvPostingSp(PSessionID,
				PCustNum,
				PInvNum,
				PInvSeq,
				PJHeaderRowPointer,
				PostExtFin,
				ExtFinOperationCounter,
				Infobar,
				ToSite,
				PostSite);
				
				int Severity = result.ReturnCode.Value;
				PostExtFin = result.PostExtFin;
				ExtFinOperationCounter = result.ExtFinOperationCounter;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
