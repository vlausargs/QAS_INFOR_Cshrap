//PROJECT NAME: AdminExt
//CLASS NAME: SLObjectMainMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
	[IDOExtensionClass("SLObjectMainMessages")]
	public class SLObjectMainMessages : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetFormsStringTranslationSp(string LanguageId,
		string LanguageCode,
		string StringToBeTranslated,
		ref string TranslatedString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetFormsStringTranslationExt = new GetFormsStringTranslationFactory().Create(appDb);
				
				var result = iGetFormsStringTranslationExt.GetFormsStringTranslationSp(LanguageId,
				LanguageCode,
				StringToBeTranslated,
				TranslatedString);
				
				int Severity = result.ReturnCode.Value;
				TranslatedString = result.TranslatedString;
				return Severity;
			}
		}
	}
}
