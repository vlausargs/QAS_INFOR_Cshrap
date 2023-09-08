//PROJECT NAME: Data
//CLASS NAME: GetPhantomItemBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPhantomItemBOM : IGetPhantomItemBOM
	{
		readonly IApplicationDB appDB;
		
		public GetPhantomItemBOM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetPhantomItemBOMSP(
			string Item,
			string PhantomComponent,
			decimal? PhantomItem_Qty = 1M,
			int? Explore_Phantom = 1,
			int? BomType = 0)
		{
			ItemType _Item = Item;
			ItemType _PhantomComponent = PhantomComponent;
			QtyPerType _PhantomItem_Qty = PhantomItem_Qty;
			FlagNyType _Explore_Phantom = Explore_Phantom;
			FlagNyType _BomType = BomType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPhantomItemBOMSP";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhantomComponent", _PhantomComponent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhantomItem_Qty", _PhantomItem_Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Explore_Phantom", _Explore_Phantom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomType", _BomType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
