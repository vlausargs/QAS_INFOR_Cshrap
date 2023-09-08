//PROJECT NAME: Data
//CLASS NAME: WordNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class WordNum : IWordNum
	{
		readonly IApplicationDB appDB;
		
		public WordNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string WordL1,
			string Infobar) WordNumSp(
			decimal? Digits,
			int? Places,
			string PCurrCode,
			string WordL1,
			string Infobar)
		{
			GenericDecimalType _Digits = Digits;
			GenericNoType _Places = Places;
			CurrCodeType _PCurrCode = PCurrCode;
			LongListType _WordL1 = WordL1;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WordNumSp";
				
				appDB.AddCommandParameter(cmd, "Digits", _Digits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WordL1", _WordL1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WordL1 = _WordL1;
				Infobar = _Infobar;
				
				return (Severity, WordL1, Infobar);
			}
		}
	}
}
