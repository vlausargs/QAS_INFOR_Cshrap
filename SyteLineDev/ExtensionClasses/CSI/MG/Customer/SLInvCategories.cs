//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvCategories.cs

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
	[IDOExtensionClass("SLInvCategories")]
	public class SLInvCategories : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateDelInvCatSp(string InvCategory,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateDelInvCatExt = new ValidateDelInvCatFactory().Create(appDb);
				
				int Severity = iValidateDelInvCatExt.ValidateDelInvCatSp(InvCategory,
				                                                         ref Infobar);
				
				return Severity;
			}
		}
	}
}
