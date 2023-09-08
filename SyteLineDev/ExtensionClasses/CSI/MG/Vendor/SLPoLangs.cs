//PROJECT NAME: VendorExt
//CLASS NAME: SLPoLangs.cs

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
	[IDOExtensionClass("SLPoLangs")]
	public class SLPoLangs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetMultiLingualPOTextSp(ref string PoparmPOText1,
		                                   ref string PoparmPoText2,
		                                   ref string PoparmPoText3,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetMultiLingualPOTextExt = new GetMultiLingualPOTextFactory().Create(appDb);
				
				int Severity = iGetMultiLingualPOTextExt.GetMultiLingualPOTextSp(ref PoparmPOText1,
				                                                                 ref PoparmPoText2,
				                                                                 ref PoparmPoText3,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}
	}
}
