//PROJECT NAME: CustomerExt
//CLASS NAME: SLEndtypes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLEndtypes")]
	public class SLEndtypes : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDraftAcctSp(ref string DraftRecvAcct,
		                          ref string DraftRecvUnit1,
		                          ref string DraftRecvUnit2,
		                          ref string DraftRecvUnit3,
		                          ref string DraftRecvUnit4,
		                          ref string DraftRecvDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetDraftAcctExt = new GetDraftAcctFactory().Create(appDb);
				
				int Severity = iGetDraftAcctExt.GetDraftAcctSp(ref DraftRecvAcct,
				                                               ref DraftRecvUnit1,
				                                               ref DraftRecvUnit2,
				                                               ref DraftRecvUnit3,
				                                               ref DraftRecvUnit4,
				                                               ref DraftRecvDesc);
				
				return Severity;
			}
		}
	}
}
