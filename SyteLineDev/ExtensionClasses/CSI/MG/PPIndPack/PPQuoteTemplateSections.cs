//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPQuoteTemplateSections.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.PrintingPackaging;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.PPIndPack
{
	[IDOExtensionClass("PPQuoteTemplateSections")]
	public class PPQuoteTemplateSections : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_GetNextQuoteSectionNumberSp(string QuoteTemplate,
		                                          ref short? NextQuoteTemplateSection)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_GetNextQuoteSectionNumberExt = new PP_GetNextQuoteSectionNumberFactory().Create(appDb);
				
				int Severity = iPP_GetNextQuoteSectionNumberExt.PP_GetNextQuoteSectionNumberSp(QuoteTemplate,
				                                                                               ref NextQuoteTemplateSection);
				
				return Severity;
			}
		}
	}
}
