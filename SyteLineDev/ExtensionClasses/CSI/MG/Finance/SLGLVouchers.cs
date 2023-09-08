//PROJECT NAME: FinanceExt
//CLASS NAME: SLGLVouchers.cs

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
	[IDOExtensionClass("SLGLVouchers")]
	public class SLGLVouchers : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetGLVoucherStatusSp(string Status,
		string GLVoucher,
		[Optional] string Approver,
		ref string Infobar,
		ref int? Succ)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetGLVoucherStatusExt = new SetGLVoucherStatusFactory().Create(appDb);
				
				var result = iSetGLVoucherStatusExt.SetGLVoucherStatusSp(Status,
				GLVoucher,
				Approver,
				Infobar,
				Succ);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				Succ = result.Succ;
				return Severity;
			}
		}
	}
}
