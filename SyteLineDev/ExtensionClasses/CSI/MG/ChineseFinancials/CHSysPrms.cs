//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHSysPrms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.ChineseFinancials
{
	[IDOExtensionClass("CHSysPrms")]
	public class CHSysPrms : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSGetDigitsOfMainAcctSp(ref int? DigitsOfMainAcct)
		{
			var iCHSGetDigitsOfMainAcctExt = this.GetService<ICHSGetDigitsOfMainAcct>();

			var result = iCHSGetDigitsOfMainAcctExt.CHSGetDigitsOfMainAcctSp(DigitsOfMainAcct);

			DigitsOfMainAcct = result.DigitsOfMainAcct;

			return result.ReturnCode ?? 0;
		}

	}
}
