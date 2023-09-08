//PROJECT NAME: VendorExt
//CLASS NAME: SLVendaddrs.cs

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
	[IDOExtensionClass("SLVendaddrs")]
	public class SLVendaddrs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DelVendaddrSp(string VendNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDelVendaddrExt = new DelVendaddrFactory().Create(appDb);
				
				var result = iDelVendaddrExt.DelVendaddrSp(VendNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
