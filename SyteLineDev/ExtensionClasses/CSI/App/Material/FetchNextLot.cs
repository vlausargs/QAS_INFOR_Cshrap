//PROJECT NAME: Material
//CLASS NAME: FetchNextLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class FetchNextLot : IFetchNextLot
	{
		readonly IApplicationDB appDB;
		
		
		public FetchNextLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string Key) FetchNextLotSp(string Item,
		string Prefix,
		string Infobar,
		string Key,
		string Site = null)
		{
			ItemType _Item = Item;
			LotPrefixType _Prefix = Prefix;
			InfobarType _Infobar = Infobar;
			LotType _Key = Key;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FetchNextLotSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Key = _Key;
				
				return (Severity, Infobar, Key);
			}
		}
	}
}
