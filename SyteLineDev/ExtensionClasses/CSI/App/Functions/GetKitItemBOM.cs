//PROJECT NAME: Data
//CLASS NAME: GetKitItemBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetKitItemBOM : IGetKitItemBOM
	{
		readonly IApplicationDB appDB;
		
		public GetKitItemBOM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetKitItemBOMSP(
			string KitItem,
			string KitComponent,
			decimal? Item_Qty = 1M,
			int? Expand_Phantom = 1,
			int? BomType = 0)
		{
			ItemType _KitItem = KitItem;
			ItemType _KitComponent = KitComponent;
			QtyPerType _Item_Qty = Item_Qty;
			FlagNyType _Expand_Phantom = Expand_Phantom;
			FlagNyType _BomType = BomType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetKitItemBOMSP";
				
				appDB.AddCommandParameter(cmd, "KitItem", _KitItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KitComponent", _KitComponent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item_Qty", _Item_Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Expand_Phantom", _Expand_Phantom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomType", _BomType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
