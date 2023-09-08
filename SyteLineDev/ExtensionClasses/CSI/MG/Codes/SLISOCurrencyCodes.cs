//PROJECT NAME: CodesExt
//CLASS NAME: SLISOCurrencyCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLISOCurrencyCodes")]
	public class SLISOCurrencyCodes : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetISOCurrencyInfoSp(string ISOCurrCode, [Optional] ref string ISODescription)
		{
			var iGetISOCurrencyInfoExt = new GetISOCurrencyInfoFactory().Create(this, true);

			var result = iGetISOCurrencyInfoExt.GetISOCurrencyInfoSp(ISOCurrCode, ISODescription);

			ISODescription = result.ISODescription;

			return result.ReturnCode ?? 0;
		}
	}
}
