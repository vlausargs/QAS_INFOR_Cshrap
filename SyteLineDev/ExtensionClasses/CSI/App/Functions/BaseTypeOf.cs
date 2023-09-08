//PROJECT NAME: Data
//CLASS NAME: BaseTypeOf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BaseTypeOf : IBaseTypeOf
	{
		readonly IApplicationDB appDB;
		
		public BaseTypeOf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string BaseTypeOfFn(
			string TableName,
			string ColumnName)
		{
			StringType _TableName = TableName;
			StringType _ColumnName = ColumnName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BaseTypeOf](@TableName, @ColumnName)";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
