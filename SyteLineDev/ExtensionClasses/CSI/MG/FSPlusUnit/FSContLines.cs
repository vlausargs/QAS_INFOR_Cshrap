//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSContLines.cs

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
	[IDOExtensionClass("FSContLines")]
	public class FSContLines : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContLineDefaultsSp(ref string ContractSurchargeAcct,
		                                   ref string ContractSurchargeAcctUnit1,
		                                   ref string ContractSurchargeAcctUnit2,
		                                   ref string ContractSurchargeAcctUnit3,
		                                   ref string ContractSurchargeAcctUnit4,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSContLineDefaultsExt = new SSSFSContLineDefaultsFactory().Create(appDb);
				
				int Severity = iSSSFSContLineDefaultsExt.SSSFSContLineDefaultsSp(ref ContractSurchargeAcct,
				                                                                 ref ContractSurchargeAcctUnit1,
				                                                                 ref ContractSurchargeAcctUnit2,
				                                                                 ref ContractSurchargeAcctUnit3,
				                                                                 ref ContractSurchargeAcctUnit4,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContLineItemChangeSp(string Contract,
		                                     int? ContLine,
		                                     string Item,
		                                     ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSContLineItemChangeExt = new SSSFSContLineItemChangeFactory().Create(appDb);
				
				int Severity = iSSSFSContLineItemChangeExt.SSSFSContLineItemChangeSp(Contract,
				                                                                     ContLine,
				                                                                     Item,
				                                                                     ref InfoBar);
				
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContLineGetContractInfoSp(string Contract,
		ref string BillingType,
		ref string BillingFreq,
		ref string ContractStatus,
		ref int? ContractClosed,
		ref string ServiceType,
		ref string ContractWhse,
		ref int? ContractProrate,
		ref DateTime? StartDate,
		ref DateTime? EndDate,
		ref string TaxCode1,
		ref string TaxCode1Desc,
		ref string TaxCode2,
		ref string TaxCode2Desc,
		ref string Infobar,
		[Optional] ref string CustPo,
		ref string CurAmtFormat,
		ref string CurCstPrcFormat,
		ref string CustNum,
		[Optional, DefaultParameterValue(0)] ref int? CustSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContLineGetContractInfoExt = new SSSFSContLineGetContractInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContLineGetContractInfoExt.SSSFSContLineGetContractInfoSp(Contract,
				BillingType,
				BillingFreq,
				ContractStatus,
				ContractClosed,
				ServiceType,
				ContractWhse,
				ContractProrate,
				StartDate,
				EndDate,
				TaxCode1,
				TaxCode1Desc,
				TaxCode2,
				TaxCode2Desc,
				Infobar,
				CustPo,
				CurAmtFormat,
				CurCstPrcFormat,
				CustNum,
				CustSeq);
				
				int Severity = result.ReturnCode.Value;
				BillingType = result.BillingType;
				BillingFreq = result.BillingFreq;
				ContractStatus = result.ContractStatus;
				ContractClosed = result.ContractClosed;
				ServiceType = result.ServiceType;
				ContractWhse = result.ContractWhse;
				ContractProrate = result.ContractProrate;
				StartDate = result.StartDate;
				EndDate = result.EndDate;
				TaxCode1 = result.TaxCode1;
				TaxCode1Desc = result.TaxCode1Desc;
				TaxCode2 = result.TaxCode2;
				TaxCode2Desc = result.TaxCode2Desc;
				Infobar = result.Infobar;
				CustPo = result.CustPo;
				CurAmtFormat = result.CurAmtFormat;
				CurCstPrcFormat = result.CurCstPrcFormat;
				CustNum = result.CustNum;
				CustSeq = result.CustSeq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContLineGetItemRateSp(string Contract,
		string Item,
		string UnitOfRate,
		[Optional] DateTime? StartDate,
		[Optional] ref decimal? Rate,
		[Optional] ref decimal? MeterRate,
		[Optional] ref int? MeterAllow,
		[Optional] ref decimal? ProrateRate,
		[Optional] ref DateTime? DueDate,
		[Optional] ref DateTime? MinBillThru,
		[Optional] ref string ProrateUnitOfRate,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContLineGetItemRateExt = new SSSFSContLineGetItemRateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContLineGetItemRateExt.SSSFSContLineGetItemRateSp(Contract,
				Item,
				UnitOfRate,
				StartDate,
				Rate,
				MeterRate,
				MeterAllow,
				ProrateRate,
				DueDate,
				MinBillThru,
				ProrateUnitOfRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Rate = result.Rate;
				MeterRate = result.MeterRate;
				MeterAllow = result.MeterAllow;
				ProrateRate = result.ProrateRate;
				DueDate = result.DueDate;
				MinBillThru = result.MinBillThru;
				ProrateUnitOfRate = result.ProrateUnitOfRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContractGetItemInfoSp(string Contract,
		string Item,
		[Optional] DateTime? StartDate,
		[Optional, DefaultParameterValue(1)] int? UnitOfRateLookup,
		[Optional] ref int? SerialTracked,
		[Optional] ref string UnitOfRate,
		[Optional] ref string Description,
		[Optional] ref string ItemUM,
		[Optional, DefaultParameterValue(0)] ref int? ItemExists,
		[Optional] ref decimal? Rate,
		[Optional] ref decimal? MeterRate,
		[Optional] ref int? MeterAllow,
		[Optional] ref decimal? ProrateRate,
		[Optional] ref string TaxCode1,
		[Optional] ref string TaxCode1Desc,
		[Optional] ref string TaxCode2,
		[Optional] ref string TaxCode2Desc,
		[Optional] ref DateTime? DueDate,
		[Optional] ref DateTime? MinBillThru,
		[Optional, DefaultParameterValue(0)] ref int? InclWaiverCharge,
		[Optional] ref string ContPriceBasis,
		[Optional] ref string PromptMsgNI,
		string SerNum,
		[Optional] ref string Infobar,
		[Optional, DefaultParameterValue(0)] ref int? IsOpenNonInvForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContractGetItemInfoExt = new SSSFSContractGetItemInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContractGetItemInfoExt.SSSFSContractGetItemInfoSp(Contract,
				Item,
				StartDate,
				UnitOfRateLookup,
				SerialTracked,
				UnitOfRate,
				Description,
				ItemUM,
				ItemExists,
				Rate,
				MeterRate,
				MeterAllow,
				ProrateRate,
				TaxCode1,
				TaxCode1Desc,
				TaxCode2,
				TaxCode2Desc,
				DueDate,
				MinBillThru,
				InclWaiverCharge,
				ContPriceBasis,
				PromptMsgNI,
				SerNum,
				Infobar,
				IsOpenNonInvForm);
				
				int Severity = result.ReturnCode.Value;
				SerialTracked = result.SerialTracked;
				UnitOfRate = result.UnitOfRate;
				Description = result.Description;
				ItemUM = result.ItemUM;
				ItemExists = result.ItemExists;
				Rate = result.Rate;
				MeterRate = result.MeterRate;
				MeterAllow = result.MeterAllow;
				ProrateRate = result.ProrateRate;
				TaxCode1 = result.TaxCode1;
				TaxCode1Desc = result.TaxCode1Desc;
				TaxCode2 = result.TaxCode2;
				TaxCode2Desc = result.TaxCode2Desc;
				DueDate = result.DueDate;
				MinBillThru = result.MinBillThru;
				InclWaiverCharge = result.InclWaiverCharge;
				ContPriceBasis = result.ContPriceBasis;
				PromptMsgNI = result.PromptMsgNI;
				Infobar = result.Infobar;
				IsOpenNonInvForm = result.IsOpenNonInvForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSContractGetUnitInfoSp(string Contract,
		string SerNum,
		[Optional] string ContPriceBasis,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional, DefaultParameterValue(1)] int? UnitOfRateLookup,
		[Optional, DefaultParameterValue(0)] ref int? UnitExists,
		[Optional, DefaultParameterValue(0)] ref int? ItemExists,
		[Optional] ref string UnitCustNum,
		[Optional, DefaultParameterValue(0)] ref int? UnitCustSeq,
		[Optional] ref string Item,
		[Optional] ref string Description,
		[Optional] ref string ItemUM,
		[Optional] ref decimal? ContBasisConv,
		[Optional] ref int? CurrentMeterAmt,
		[Optional] ref int? StartMeterAmt,
		[Optional] ref int? BilledThruMeterAmt,
		[Optional, DefaultParameterValue(0)] ref decimal? Rate,
		[Optional] ref string UnitOfRate,
		[Optional] ref decimal? MeterRate,
		[Optional] ref int? MeterAllow,
		[Optional] ref decimal? ProrateRate,
		[Optional] ref string TaxCode1,
		[Optional] ref string TaxCode1Desc,
		[Optional] ref string TaxCode2,
		[Optional] ref string TaxCode2Desc,
		[Optional] ref DateTime? DueDate,
		[Optional] ref DateTime? MinBillThru,
		[Optional, DefaultParameterValue(0)] ref int? InclWaiverCharge,
		[Optional] ref string PromptMsgBadCust,
		[Optional] ref string PromptMsgNoUnit,
		[Optional] ref string PromptMsgSerContLine,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContractGetUnitInfoExt = new SSSFSContractGetUnitInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContractGetUnitInfoExt.SSSFSContractGetUnitInfoSp(Contract,
				SerNum,
				ContPriceBasis,
				StartDate,
				EndDate,
				UnitOfRateLookup,
				UnitExists,
				ItemExists,
				UnitCustNum,
				UnitCustSeq,
				Item,
				Description,
				ItemUM,
				ContBasisConv,
				CurrentMeterAmt,
				StartMeterAmt,
				BilledThruMeterAmt,
				Rate,
				UnitOfRate,
				MeterRate,
				MeterAllow,
				ProrateRate,
				TaxCode1,
				TaxCode1Desc,
				TaxCode2,
				TaxCode2Desc,
				DueDate,
				MinBillThru,
				InclWaiverCharge,
				PromptMsgBadCust,
				PromptMsgNoUnit,
				PromptMsgSerContLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				UnitExists = result.UnitExists;
				ItemExists = result.ItemExists;
				UnitCustNum = result.UnitCustNum;
				UnitCustSeq = result.UnitCustSeq;
				Item = result.Item;
				Description = result.Description;
				ItemUM = result.ItemUM;
				ContBasisConv = result.ContBasisConv;
				CurrentMeterAmt = result.CurrentMeterAmt;
				StartMeterAmt = result.StartMeterAmt;
				BilledThruMeterAmt = result.BilledThruMeterAmt;
				Rate = result.Rate;
				UnitOfRate = result.UnitOfRate;
				MeterRate = result.MeterRate;
				MeterAllow = result.MeterAllow;
				ProrateRate = result.ProrateRate;
				TaxCode1 = result.TaxCode1;
				TaxCode1Desc = result.TaxCode1Desc;
				TaxCode2 = result.TaxCode2;
				TaxCode2Desc = result.TaxCode2Desc;
				DueDate = result.DueDate;
				MinBillThru = result.MinBillThru;
				InclWaiverCharge = result.InclWaiverCharge;
				PromptMsgBadCust = result.PromptMsgBadCust;
				PromptMsgNoUnit = result.PromptMsgNoUnit;
				PromptMsgSerContLine = result.PromptMsgSerContLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
