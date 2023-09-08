//PROJECT NAME: FinanceExt
//CLASS NAME: SLBankAddrs.cs

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
	[IDOExtensionClass("SLBankAddrs")]
	public class SLBankAddrs : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AcctDSp(string pAccount,
		ref string rDescription)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);
                var iAcctDExt = new AcctDFactory().Create(appDb, mgInvoker, new CSI.Data.SQL.SQLParameterProvider(), true);
				
				var result = iAcctDExt.AcctDSp(pAccount,
				rDescription);
				
				int Severity = result.ReturnCode.Value;
				rDescription = result.rDescription;
				return Severity;
			}
		}
	}
}
