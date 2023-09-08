//PROJECT NAME: THLOC
//CLASS NAME: THANextTransactionNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
	public class THANextTransactionNumber : ITHANextTransactionNumber
	{
		readonly IApplicationDB appDB;
		
		
		public THANextTransactionNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Key,
		string Infobar) THANextTransactionNumberSp(string DocumentType,
		string Prefix,
		DateTime? Date,
		int? KeyLength,
		string Key,
		string Infobar)
		{
			THTransTypeType _DocumentType = DocumentType;
			LongList _Prefix = Prefix;
			DateType _Date = Date;
			IntType _KeyLength = KeyLength;
			LongList _Key = Key;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THANextTransactionNumberSp";
				
				appDB.AddCommandParameter(cmd, "DocumentType", _DocumentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Key = _Key;
				Infobar = _Infobar;
				
				return (Severity, Key, Infobar);
			}
		}
	}
}
