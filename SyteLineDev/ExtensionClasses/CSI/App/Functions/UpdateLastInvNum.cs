//PROJECT NAME: Data
//CLASS NAME: UpdateLastInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateLastInvNum : IUpdateLastInvNum
	{
		readonly IApplicationDB appDB;
		
		public UpdateLastInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateLastInvNumSp(
			string TableName,
			string ColumnName,
			string InvNum,
			string Type)
		{
			StringType _TableName = TableName;
			StringType _ColumnName = ColumnName;
			InvNumType _InvNum = InvNum;
			ArinvTypeType _Type = Type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateLastInvNumSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
