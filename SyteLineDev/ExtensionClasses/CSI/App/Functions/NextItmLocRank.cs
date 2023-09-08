//PROJECT NAME: Data
//CLASS NAME: NextItmLocRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextItmLocRank : INextItmLocRank
	{
		readonly IApplicationDB appDB;
		
		public NextItmLocRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NextItmLocRankFn(
			string Whse,
			string Item)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[NextItmLocRank](@Whse, @Item)";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
