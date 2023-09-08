//PROJECT NAME: VendorExt
//CLASS NAME: SLVendorCurrencies.cs

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
	[IDOExtensionClass("SLVendorCurrencies")]
	public class SLVendorCurrencies : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetVendFixedRateSp(string VendNum,
			string CurrCode,
			ref int? FixedRate,
			ref string Infobar)
		{
			var iGetVendFixedRateExt = new GetVendFixedRateFactory().Create(this, true);

			var result = iGetVendFixedRateExt.GetVendFixedRateSp(VendNum,
				CurrCode,
				FixedRate,
				Infobar);

			FixedRate = result.FixedRate;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}
	}
}
