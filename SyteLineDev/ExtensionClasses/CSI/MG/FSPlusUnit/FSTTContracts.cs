//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSTTContracts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSTTContracts")]
	public class FSTTContracts : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConInvSubClearBillingTTSp(Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSConInvSubClearBillingTTExt = new SSSFSConInvSubClearBillingTTFactory().Create(appDb);
				
				int Severity = iSSSFSConInvSubClearBillingTTExt.SSSFSConInvSubClearBillingTTSp(SessionId);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConInvSubDelContractSp(Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSConInvSubDelContractExt = new SSSFSConInvSubDelContractFactory().Create(appDb);
				
				int Severity = iSSSFSConInvSubDelContractExt.SSSFSConInvSubDelContractSp(SessionId);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConInvSp(string StartContract,
		string EndContract,
		int? StartContLine,
		int? EndContLine,
		string StartServType,
		string EndServType,
		string StartCustNum,
		string EndCustNum,
		int? InclAnnually,
		int? InclSemiAnnually,
		int? InclQuarterly,
		int? InclBiMonthly,
		int? InclMonthly,
		int? InclOneTime,
		int? InclElapsedTime,
		[Optional] string BillFreqList,
		DateTime? RenewByDate,
		DateTime? InvDate,
		int? DisplayFixed,
		[Optional] string CalledFromForm,
		[Optional] string Mode,
		[Optional] Guid? SessionId,
		[Optional] string ContractStatus,
		[Optional] string RequestingUser,
		[Optional] decimal? UserID,
		[Optional] string PartnerId,
		[Optional] string Drawer,
		ref string StartInvNum,
		ref string EndInvNum,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? PrintZero)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConInvExt = new SSSFSConInvFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConInvExt.SSSFSConInvSp(StartContract,
				EndContract,
				StartContLine,
				EndContLine,
				StartServType,
				EndServType,
				StartCustNum,
				EndCustNum,
				InclAnnually,
				InclSemiAnnually,
				InclQuarterly,
				InclBiMonthly,
				InclMonthly,
				InclOneTime,
				InclElapsedTime,
				BillFreqList,
				RenewByDate,
				InvDate,
				DisplayFixed,
				CalledFromForm,
				Mode,
				SessionId,
				ContractStatus,
				RequestingUser,
				UserID,
				PartnerId,
				Drawer,
				StartInvNum,
				EndInvNum,
				Infobar,
				PrintZero);
				
				int Severity = result.ReturnCode.Value;
				StartInvNum = result.StartInvNum;
				EndInvNum = result.EndInvNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConInvSubCalcTotalsSp(Guid? SessionId,
		string iContract,
		DateTime? iInvDate,
		string iInvNum,
		[Optional] string iMode,
		ref decimal? oSubTotal,
		ref decimal? oTotSurcharge,
		ref decimal? oTotWaiver,
		ref decimal? oSalesTax1,
		ref decimal? oSalesTax2,
		ref decimal? oTotBilled,
		ref decimal? oBalance,
		ref decimal? oPayments,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConInvSubCalcTotalsExt = new SSSFSConInvSubCalcTotalsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConInvSubCalcTotalsExt.SSSFSConInvSubCalcTotalsSp(SessionId,
				iContract,
				iInvDate,
				iInvNum,
				iMode,
				oSubTotal,
				oTotSurcharge,
				oTotWaiver,
				oSalesTax1,
				oSalesTax2,
				oTotBilled,
				oBalance,
				oPayments,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				oSubTotal = result.oSubTotal;
				oTotSurcharge = result.oTotSurcharge;
				oTotWaiver = result.oTotWaiver;
				oSalesTax1 = result.oSalesTax1;
				oSalesTax2 = result.oSalesTax2;
				oTotBilled = result.oTotBilled;
				oBalance = result.oBalance;
				oPayments = result.oPayments;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConInvSubSelContractSp(Guid? SessionId,
		string StartContract,
		string EndContract,
		int? StartContLine,
		int? EndContLine,
		string StartCustNum,
		string EndCustNum,
		[Optional] string StartServType,
		[Optional] string EndServType,
		[Optional] DateTime? RenewByDate,
		[Optional, DefaultParameterValue("ASQBMOE")] string BillingFreq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConInvSubSelContractExt = new SSSFSConInvSubSelContractFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConInvSubSelContractExt.SSSFSConInvSubSelContractSp(SessionId,
				StartContract,
				EndContract,
				StartContLine,
				EndContLine,
				StartCustNum,
				EndCustNum,
				StartServType,
				EndServType,
				RenewByDate,
				BillingFreq);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
