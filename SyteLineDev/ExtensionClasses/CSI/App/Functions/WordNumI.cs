//PROJECT NAME: Data
//CLASS NAME: WordNumI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class WordNumI : IWordNumI
	{
		readonly IApplicationDB appDB;
		
		public WordNumI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Result,
			string Infobar) WordNumISp(
			string WordNum,
			string PCurrCode,
			int? Offset,
			string Result,
			string Infobar)
		{
			LongListType _WordNum = WordNum;
			CurrCodeType _PCurrCode = PCurrCode;
			IntType _Offset = Offset;
			LongListType _Result = Result;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WordNumISp";
				
				appDB.AddCommandParameter(cmd, "WordNum", _WordNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Offset", _Offset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Result = _Result;
				Infobar = _Infobar;
				
				return (Severity, Result, Infobar);
			}
		}
	}
}
