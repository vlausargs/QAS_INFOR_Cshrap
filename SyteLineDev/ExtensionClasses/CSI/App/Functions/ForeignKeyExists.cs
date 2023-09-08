//PROJECT NAME: Data
//CLASS NAME: ForeignKeyExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ForeignKeyExists : IForeignKeyExists
	{
		readonly IApplicationDB appDB;
		
		public ForeignKeyExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ForeignKeyExistsFn(
			string TableName)
		{
			StringType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ForeignKeyExists](@TableName)";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
