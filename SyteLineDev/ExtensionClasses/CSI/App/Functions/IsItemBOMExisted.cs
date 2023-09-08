//PROJECT NAME: Data
//CLASS NAME: IsItemBOMExisted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsItemBOMExisted : IIsItemBOMExisted
	{
		readonly IApplicationDB appDB;
		
		public IsItemBOMExisted(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsItemBOMExistedFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsItemBOMExisted](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
