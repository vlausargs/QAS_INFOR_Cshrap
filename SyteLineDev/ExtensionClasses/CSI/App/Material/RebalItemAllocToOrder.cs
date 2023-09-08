//PROJECT NAME: Material
//CLASS NAME: RebalItemAllocToOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class RebalItemAllocToOrder : IRebalItemAllocToOrder
	{
		readonly IApplicationDB appDB;
		
		
		public RebalItemAllocToOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CoitemCount) RebalItemAllocToOrderSp(int? CoitemCount,
		string StartingItem = null,
		string EndingItem = null,
		string StartingWhse = null,
		string EndingWhse = null)
		{
			IntType _CoitemCount = CoitemCount;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			WhseType _StartingWhse = StartingWhse;
			WhseType _EndingWhse = EndingWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RebalItemAllocToOrderSp";
				
				appDB.AddCommandParameter(cmd, "CoitemCount", _CoitemCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingWhse", _StartingWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWhse", _EndingWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoitemCount = _CoitemCount;
				
				return (Severity, CoitemCount);
			}
		}
	}
}
