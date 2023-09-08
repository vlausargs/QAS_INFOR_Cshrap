//PROJECT NAME: Data
//CLASS NAME: GetTotalOnHandQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTotalOnHandQty : IGetTotalOnHandQty
	{
		readonly IApplicationDB appDB;
		
		public GetTotalOnHandQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TotOnHdQty,
			decimal? TotResvCO) GetTotalOnHandQtySp(
			string SiteGroup,
			string Item,
			decimal? TotOnHdQty,
			decimal? TotResvCO)
		{
			SiteGroupType _SiteGroup = SiteGroup;
			ItemType _Item = Item;
			QtyTotlType _TotOnHdQty = TotOnHdQty;
			QtyTotlType _TotResvCO = TotResvCO;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTotalOnHandQtySp";
				
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotOnHdQty", _TotOnHdQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotResvCO", _TotResvCO, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotOnHdQty = _TotOnHdQty;
				TotResvCO = _TotResvCO;
				
				return (Severity, TotOnHdQty, TotResvCO);
			}
		}
	}
}
