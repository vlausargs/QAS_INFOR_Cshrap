//PROJECT NAME: Data
//CLASS NAME: GetNextProjNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetNextProjNum : IGetNextProjNum
	{
		readonly IApplicationDB appDB;
		
		public GetNextProjNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string KeyVal,
			string Infobar) GetNextProjNumSp(
			string TableName,
			string ColumnName,
			string Prefix,
			int? KeyLength,
			string KeyVal,
			string Infobar)
		{
			StringType _TableName = TableName;
			StringType _ColumnName = ColumnName;
			GenericKeyType _Prefix = Prefix;
			IntType _KeyLength = KeyLength;
			LongList _KeyVal = KeyVal;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextProjNumSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyVal", _KeyVal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				KeyVal = _KeyVal;
				Infobar = _Infobar;
				
				return (Severity, KeyVal, Infobar);
			}
		}
	}
}
