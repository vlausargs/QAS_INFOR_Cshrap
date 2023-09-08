//PROJECT NAME: Admin
//CLASS NAME: GetFormsStringTranslation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class GetFormsStringTranslation : IGetFormsStringTranslation
	{
		IApplicationDB appDB;
		
		
		public GetFormsStringTranslation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TranslatedString) GetFormsStringTranslationSp(string LanguageId,
		string LanguageCode,
		string StringToBeTranslated,
		string TranslatedString)
		{
			LanguageIDType _LanguageId = LanguageId;
			LangCodeType _LanguageCode = LanguageCode;
			CharLongDescType _StringToBeTranslated = StringToBeTranslated;
			InfobarType _TranslatedString = TranslatedString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFormsStringTranslationSp";
				
				appDB.AddCommandParameter(cmd, "LanguageId", _LanguageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LanguageCode", _LanguageCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StringToBeTranslated", _StringToBeTranslated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslatedString", _TranslatedString, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TranslatedString = _TranslatedString;
				
				return (Severity, TranslatedString);
			}
		}
	}
}
