//PROJECT NAME: Data
//CLASS NAME: ItemId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemId : IItemId
	{
		readonly IApplicationDB appDB;
		
		public ItemId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ItemIdFn(
			string BaseTableName,
			string TableAlias,
			DateTime? RecordDate,
			Guid? RowPointer)
		{
			TableNameType _BaseTableName = BaseTableName;
			TableNameType _TableAlias = TableAlias;
			DateType _RecordDate = RecordDate;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemId](@BaseTableName, @TableAlias, @RecordDate, @RowPointer)";
				
				appDB.AddCommandParameter(cmd, "BaseTableName", _BaseTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableAlias", _TableAlias, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
