//PROJECT NAME: CustomerExt
//CLASS NAME: SLInteractionTopicLangs.cs

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
	[IDOExtensionClass("SLInteractionTopicLangs")]
	public class SLInteractionTopicLangs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetLanguageDescSp(string LanguageCode,
			ref string Description,
			[Optional] ref string Infobar)
		{
			var iGetLanguageDescExt = new GetLanguageDescFactory().Create(this, true);

			var result = iGetLanguageDescExt.GetLanguageDescSp(LanguageCode,
				Description,
				Infobar);

			Description = result.Description;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}
	}
}
