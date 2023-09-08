//PROJECT NAME: Data
//CLASS NAME: ItemUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemUpd : IItemUpd
	{
		readonly IApplicationDB appDB;
		
		public ItemUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Item) ItemUpdSp(
			string Item,
			string DrawingNbr = null,
			string Revision = null)
		{
			ItemType _Item = Item;
			DrawingNbrType _DrawingNbr = DrawingNbr;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemUpdSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DrawingNbr", _DrawingNbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				
				return (Severity, Item);
			}
		}
	}
}
