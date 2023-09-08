//PROJECT NAME: Data
//CLASS NAME: FetchPreassignedSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FetchPreassignedSerials : IFetchPreassignedSerials
	{
		readonly IApplicationDB appDB;
		
		public FetchPreassignedSerials(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FetchPreassignedSerialsSp(
			string Item,
			string Prefix,
			int? Qty,
			string Site = null)
		{
			ItemType _Item = Item;
			SerialPrefixType _Prefix = Prefix;
			IntType _Qty = Qty;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FetchPreassignedSerials";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
