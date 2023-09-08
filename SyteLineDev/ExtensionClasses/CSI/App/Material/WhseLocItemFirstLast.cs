//PROJECT NAME: Material
//CLASS NAME: WhseLocItemFirstLast.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class WhseLocItemFirstLast : IWhseLocItemFirstLast
	{
		readonly IApplicationDB appDB;
		
		public WhseLocItemFirstLast(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? FirstOfWhse,
			int? FirstOfLoc,
			int? FirstOfItem,
			int? LastOfWhse,
			int? LastOfLoc,
			int? LastOfItem) WhseLocItemFirstLastSp(
			int? FETCH_STATUS,
			string Whse,
			string Loc,
			string Item,
			string LastWhse,
			string LastLoc,
			string LastItem,
			int? FirstOfWhse,
			int? FirstOfLoc,
			int? FirstOfItem,
			int? LastOfWhse,
			int? LastOfLoc,
			int? LastOfItem)
		{
			IntType _FETCH_STATUS = FETCH_STATUS;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ItemType _Item = Item;
			WhseType _LastWhse = LastWhse;
			LocType _LastLoc = LastLoc;
			ItemType _LastItem = LastItem;
			ListYesNoType _FirstOfWhse = FirstOfWhse;
			ListYesNoType _FirstOfLoc = FirstOfLoc;
			ListYesNoType _FirstOfItem = FirstOfItem;
			ListYesNoType _LastOfWhse = LastOfWhse;
			ListYesNoType _LastOfLoc = LastOfLoc;
			ListYesNoType _LastOfItem = LastOfItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WhseLocItemFirstLastSp";
				
				appDB.AddCommandParameter(cmd, "FETCH_STATUS", _FETCH_STATUS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastWhse", _LastWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastLoc", _LastLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastItem", _LastItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstOfWhse", _FirstOfWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FirstOfLoc", _FirstOfLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FirstOfItem", _FirstOfItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastOfWhse", _LastOfWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastOfLoc", _LastOfLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastOfItem", _LastOfItem, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstOfWhse = _FirstOfWhse;
				FirstOfLoc = _FirstOfLoc;
				FirstOfItem = _FirstOfItem;
				LastOfWhse = _LastOfWhse;
				LastOfLoc = _LastOfLoc;
				LastOfItem = _LastOfItem;
				
				return (Severity, FirstOfWhse, FirstOfLoc, FirstOfItem, LastOfWhse, LastOfLoc, LastOfItem);
			}
		}
	}
}
