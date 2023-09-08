//PROJECT NAME: Data
//CLASS NAME: CanChangeItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CanChangeItem : ICanChangeItem
	{
		readonly IApplicationDB appDB;
		
		public CanChangeItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CanChangeItemFn(
			string CoNum,
			int? CoLine,
			string Status,
			decimal? QtyConv,
			string Table)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoBlnStatusType _Status = Status;
			QtyTotlType _QtyConv = QtyConv;
			LongListType _Table = Table;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CanChangeItem](@CoNum, @CoLine, @Status, @QtyConv, @Table)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
