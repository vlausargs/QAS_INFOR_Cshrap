//PROJECT NAME: Production
//CLASS NAME: CheckHasAlternateBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CheckHasAlternateBOM : ICheckHasAlternateBOM
	{
		readonly IApplicationDB appDB;
		
		public CheckHasAlternateBOM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckHasAlternateBOMFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CheckHasAlternateBOM](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
