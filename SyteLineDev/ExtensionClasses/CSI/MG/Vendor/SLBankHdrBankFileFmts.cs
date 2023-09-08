//PROJECT NAME: VendorExt
//CLASS NAME: SLBankHdrBankFileFmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLBankHdrBankFileFmts")]
	public class SLBankHdrBankFileFmts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateBankCodeFormatSp(string BankCode,
		string EFTFormat,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateBankCodeFormatExt = new ValidateBankCodeFormatFactory().Create(appDb);
				
				var result = iValidateBankCodeFormatExt.ValidateBankCodeFormatSp(BankCode,
				EFTFormat,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
