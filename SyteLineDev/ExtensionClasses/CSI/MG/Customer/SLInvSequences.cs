//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvSequences.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInvSequences")]
	public class SLInvSequences : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckAndGetInvLength(string KeyName,
			ref int? Result,
			ref int? KeyLength,
			ref int? PromptTaxDisc,
			ref string Infobar)
		{
			var iCheckAndGetInvLengthExt = this.GetService<ICheckAndGetInvLength>();

			var result = iCheckAndGetInvLengthExt.CheckAndGetInvLength(KeyName,
				Result,
				KeyLength,
				PromptTaxDisc,
				Infobar);

			Result = result.Result;
			KeyLength = result.KeyLength;
			PromptTaxDisc = result.PromptTaxDisc;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SequencePreSaveSp(string PType,
		string PCategory,
		int? PClosed,
		string PStartInv,
		string PEndInv,
		int? Action,
		[Optional] Guid? PRowPointer,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSequencePreSaveExt = new SequencePreSaveFactory().Create(appDb);
				
				var result = iSequencePreSaveExt.SequencePreSaveSp(PType,
				PCategory,
				PClosed,
				PStartInv,
				PEndInv,
				Action,
				PRowPointer,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckEndingInvSp(string PEndInv,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckEndingInvExt = new CheckEndingInvFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckEndingInvExt.CheckEndingInvSp(PEndInv,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckInvLengthSp(ref int? Result,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckInvLengthExt = new CheckInvLengthFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckInvLengthExt.CheckInvLengthSp(Result,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Result = result.Result;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckPrefixSp(string PStartInv,
		string PEndInv,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckPrefixExt = new CheckPrefixFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckPrefixExt.CheckPrefixSp(PStartInv,
				PEndInv,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
