//PROJECT NAME: Finance
//CLASS NAME: ExcelFetchString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IExcelFetchString
	{
		(int? ReturnCode, string InterpretedText, string Infobar) ExcelFetchStringSp(string Text,
		string LanguageCode,
		string UserName,
		string PrimarygroupName,
		int? ScopeType,
		string InterpretedText,
		string Infobar);
	}
	
	public class ExcelFetchString : IExcelFetchString
	{
		readonly IApplicationDB appDB;
		
		public ExcelFetchString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InterpretedText, string Infobar) ExcelFetchStringSp(string Text,
		string LanguageCode,
		string UserName,
		string PrimarygroupName,
		int? ScopeType,
		string InterpretedText,
		string Infobar)
		{
			StringType _Text = Text;
			StringType _LanguageCode = LanguageCode;
			StringType _UserName = UserName;
			StringType _PrimarygroupName = PrimarygroupName;
			IntType _ScopeType = ScopeType;
			StringType _InterpretedText = InterpretedText;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExcelFetchStringSp";
				
				appDB.AddCommandParameter(cmd, "Text", _Text, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LanguageCode", _LanguageCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrimarygroupName", _PrimarygroupName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScopeType", _ScopeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InterpretedText", _InterpretedText, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InterpretedText = _InterpretedText;
				Infobar = _Infobar;
				
				return (Severity, InterpretedText, Infobar);
			}
		}
	}
}
