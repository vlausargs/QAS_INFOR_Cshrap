//PROJECT NAME: Data
//CLASS NAME: NextLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextLot : INextLot
	{
		readonly IApplicationDB appDB;
		
		public NextLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Key,
			string Infobar) NextLotSp(
			string Item,
			int? UseParm,
			string Prefix,
			string Key,
			string Infobar,
			string Site = null,
			int? NoExpKey = null)
		{
			ItemType _Item = Item;
			FlagNyType _UseParm = UseParm;
			LotPrefixType _Prefix = Prefix;
			LotType _Key = Key;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			FlagNyType _NoExpKey = NoExpKey;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextLotSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseParm", _UseParm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoExpKey", _NoExpKey, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Key = _Key;
				Infobar = _Infobar;
				
				return (Severity, Key, Infobar);
			}
		}
	}
}
