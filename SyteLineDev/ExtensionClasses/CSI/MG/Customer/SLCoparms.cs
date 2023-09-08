//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoparms.cs

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
	[IDOExtensionClass("SLCoparms")]
	public class SLCoparms : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckReplRuleSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckReplRuleExt = new CheckReplRuleFactory().Create(appDb);
				
				int Severity = iCheckReplRuleExt.CheckReplRuleSp(ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetParmReasonTextSp(ref byte? ReasonText)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetParmReasonTextExt = new GetParmReasonTextFactory().Create(appDb);
				
				int Severity = iGetParmReasonTextExt.GetParmReasonTextSp(ref ReasonText);
				
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetOrderParmsSp(ref int? OrderVerificationTemplate, ref int? OrderInvoiceTemplate, [Optional] ref int? PackingSlipTemplate)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var mgInvoker = new MGInvoker(this.Context);

				var iGetOrderParmsExt = new GetOrderParmsFactory().Create(appDb,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);

				var result = iGetOrderParmsExt.GetOrderParmsSp(OrderVerificationTemplate,
					OrderInvoiceTemplate,
					PackingSlipTemplate);

				OrderVerificationTemplate = result.OrderVerificationTemplate;
				OrderInvoiceTemplate = result.OrderInvoiceTemplate;
				PackingSlipTemplate = result.PackingSlipTemplate;

				return result.ReturnCode.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetUseAltPriceParmsSp(ref byte? PUseAltPriceCalc,
		                                 [Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetUseAltPriceParmsExt = new GetUseAltPriceParmsFactory().Create(appDb);
				
				var result = iGetUseAltPriceParmsExt.GetUseAltPriceParmsSp(PUseAltPriceCalc,
				                                                           PSite);
				
				int Severity = result.ReturnCode.Value;
				PUseAltPriceCalc = result.PUseAltPriceCalc;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateOldInvoiceNumSp(int? InvLength)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateOldInvoiceNumExt = new UpdateOldInvoiceNumFactory().Create(appDb);
				
				var result = iUpdateOldInvoiceNumExt.UpdateOldInvoiceNumSp(InvLength);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateParmsRsvd1Sp(int? CoparmsParmKey,
		int? ParmsRsvd1,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateParmsRsvd1Ext = new UpdateParmsRsvd1Factory().Create(appDb);
				
				var result = iUpdateParmsRsvd1Ext.UpdateParmsRsvd1Sp(CoparmsParmKey,
				ParmsRsvd1,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateInvLengthSp(int? InvNumLen,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateInvLengthExt = new ValidateInvLengthFactory().Create(appDb);
				
				var result = iValidateInvLengthExt.ValidateInvLengthSp(InvNumLen,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetParmDuePeriodSp(ref int? DuePeriod)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetParmDuePeriodExt = new GetParmDuePeriodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetParmDuePeriodExt.GetParmDuePeriodSp(DuePeriod);
				
				int Severity = result.ReturnCode.Value;
				DuePeriod = result.DuePeriod;
				return Severity;
			}
		}
	}
}
