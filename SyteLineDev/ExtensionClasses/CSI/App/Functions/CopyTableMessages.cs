//PROJECT NAME: Data
//CLASS NAME: CopyTableMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyTableMessages : ICopyTableMessages
	{
		readonly IApplicationDB appDB;
		
		public CopyTableMessages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyTableMessagesSp(
			string TableName,
			string NewAltNo)
		{
			StringType _TableName = TableName;
			StringType _NewAltNo = NewAltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyTableMessagesSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewAltNo", _NewAltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
