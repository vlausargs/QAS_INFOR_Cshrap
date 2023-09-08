//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHPerHdrs.cs

using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.ChineseFinancials
{
	[IDOExtensionClass("CHPerHdrs")]
	public class CHPerHdrs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSRecurrTableDeleteSp(string UserName,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCHSRecurrTableDeleteExt = new CHSRecurrTableDeleteFactory().Create(appDb);
				
				int Severity = iCHSRecurrTableDeleteExt.CHSRecurrTableDeleteSp(UserName,
				                                                               ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSGenRecurrVoucherSp(DateTime? TransDate,
		int? ID,
		string PreviewYN,
		string UserName,
		ref string VoucherNumber,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSGenRecurrVoucherExt = new CHSGenRecurrVoucherFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSGenRecurrVoucherExt.CHSGenRecurrVoucherSp(TransDate,
				ID,
				PreviewYN,
				UserName,
				VoucherNumber,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				VoucherNumber = result.VoucherNumber;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
