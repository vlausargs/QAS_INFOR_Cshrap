//PROJECT NAME: BusInterface
//CLASS NAME: ESBInventoryCountCreation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class ESBInventoryCountCreation : IESBInventoryCountCreation
	{
		readonly IApplicationDB appDB;
		
		public ESBInventoryCountCreation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ESBInventoryCountCreationSp(
			string Item,
			string Whse,
			string loc,
			string lot,
			decimal? CountSequence,
			int? UpdateItemWhse)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _loc = loc;
			LotType _lot = lot;
			CountSequenceType _CountSequence = CountSequence;
			ListYesNoType _UpdateItemWhse = UpdateItemWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ESBInventoryCountCreationSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "loc", _loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lot", _lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountSequence", _CountSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateItemWhse", _UpdateItemWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
