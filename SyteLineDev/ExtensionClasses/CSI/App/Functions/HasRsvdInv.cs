//PROJECT NAME: Data
//CLASS NAME: HasRsvdInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class HasRsvdInv : IHasRsvdInv
	{
		readonly IApplicationDB appDB;
		
		public HasRsvdInv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? HasRsvdInvFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HasRsvdInv](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
