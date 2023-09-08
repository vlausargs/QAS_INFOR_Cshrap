//PROJECT NAME: VendorExt
//CLASS NAME: SLPreqs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Employee;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLPreqs")]
	public class SLPreqs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckNewPoReqNumSp(string PoReqNum,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckNewPoReqNumExt = new CheckNewPoReqNumFactory().Create(appDb);
				
				int Severity = iCheckNewPoReqNumExt.CheckNewPoReqNumSp(PoReqNum,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreqExistsSp(string ReqNum,
		                        ref byte? PreqExists)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPreqExistsExt = new PreqExistsFactory().Create(appDb);
				
				int Severity = iPreqExistsExt.PreqExistsSp(ReqNum,
				                                           ref PreqExists);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ESSGetSupUsernameSp([Optional] string EmpNum,
		                               ref string SupUsername)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iESSGetSupUsernameExt = new ESSGetSupUsernameFactory().Create(appDb);
				
				var result = iESSGetSupUsernameExt.ESSGetSupUsernameSp(EmpNum,
				                                                       SupUsername);
				
				int Severity = result.ReturnCode.Value;
				SupUsername = result.SupUsername;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateReqNumForConvertSp(string ReqNum,
		ref int? StartLineNum,
		ref int? EndLineNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateReqNumForConvertExt = new ValidateReqNumForConvertFactory().Create(appDb);
				
				var result = iValidateReqNumForConvertExt.ValidateReqNumForConvertSp(ReqNum,
				StartLineNum,
				EndLineNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				StartLineNum = result.StartLineNum;
				EndLineNum = result.EndLineNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextPreqSp(string Context,
		string Prefix,
		int? KeyLength,
		ref string Key,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextPreqExt = new NextPreqFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextPreqExt.NextPreqSp(Context,
				Prefix,
				KeyLength,
				Key,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Key = result.Key;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
