//PROJECT NAME: Admin
//CLASS NAME: IGetFormsStringTranslation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IGetFormsStringTranslation
	{
		(int? ReturnCode, string TranslatedString) GetFormsStringTranslationSp(string LanguageId,
		string LanguageCode,
		string StringToBeTranslated,
		string TranslatedString);
	}
}

