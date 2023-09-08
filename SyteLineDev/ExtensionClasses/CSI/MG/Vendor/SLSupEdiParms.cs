//PROJECT NAME: VendorExt
//CLASS NAME: SLSupEdiParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLSupEdiParms")]
	public class SLSupEdiParms : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertSupEdiParmsSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInsertSupEdiParmsExt = new InsertSupEdiParmsFactory().Create(appDb);
				
				int Severity = iInsertSupEdiParmsExt.InsertSupEdiParmsSp();
				
				return Severity;
			}
		}
	}
}
