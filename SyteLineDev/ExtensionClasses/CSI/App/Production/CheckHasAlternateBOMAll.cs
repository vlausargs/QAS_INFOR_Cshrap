//PROJECT NAME: Production
//CLASS NAME: CheckHasAlternateBOMAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CheckHasAlternateBOMAll : ICheckHasAlternateBOMAll
	{
		readonly IApplicationDB appDB;
		
		public CheckHasAlternateBOMAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckHasAlternateBOMAllFn(
			string Item,
			string Site)
		{
			ItemType _Item = Item;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CheckHasAlternateBOMAll](@Item, @Site)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
