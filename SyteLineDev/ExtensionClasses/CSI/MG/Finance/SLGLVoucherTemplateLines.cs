//PROJECT NAME: FinanceExt
//CLASS NAME: SLGLVoucherTemplateLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLGLVoucherTemplateLines")]
	public class SLGLVoucherTemplateLines : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalValidBankCodeSp(string PBankCode,
		string PAcct,
		ref string PCurrCode,
		ref string Infobar,
		[Optional] string AcctUnit1,
		[Optional] string AcctUnit2,
		[Optional] string AcctUnit3,
		[Optional] string AcctUnit4)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalValidBankCodeExt = new JournalValidBankCodeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalValidBankCodeExt.JournalValidBankCodeSp(PBankCode,
				PAcct,
				PCurrCode,
				Infobar,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4);
				
				int Severity = result.ReturnCode.Value;
				PCurrCode = result.PCurrCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
