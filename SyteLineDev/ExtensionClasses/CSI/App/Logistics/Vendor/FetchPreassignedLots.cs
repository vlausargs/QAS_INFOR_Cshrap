//PROJECT NAME: Logistics
//CLASS NAME: FetchPreassignedLots.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class FetchPreassignedLots : IFetchPreassignedLots
	{
		readonly IApplicationDB appDB;
		
		
		public FetchPreassignedLots(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FetchPreassignedLotsSp(string Item,
		string Prefix,
		int? Qty,
		string Infobar,
		string Site = null)
		{
			ItemType _Item = Item;
			LotPrefixType _Prefix = Prefix;
			IntType _Qty = Qty;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FetchPreassignedLots";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
