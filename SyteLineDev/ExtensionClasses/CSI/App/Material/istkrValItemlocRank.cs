//PROJECT NAME: Material
//CLASS NAME: istkrValItemlocRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrValItemlocRank
	{
		(int? ReturnCode, string Infobar) istkrValItemlocRankSp(string Whse,
		                                                        string Item,
		                                                        string Loc,
		                                                        string LocType,
		                                                        short? NewRank,
		                                                        int? NewCount,
		                                                        string Action,
		                                                        string Infobar = null);
	}
	
	public class istkrValItemlocRank : IistkrValItemlocRank
	{
		readonly IApplicationDB appDB;
		
		public istkrValItemlocRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) istkrValItemlocRankSp(string Whse,
		                                                               string Item,
		                                                               string Loc,
		                                                               string LocType,
		                                                               short? NewRank,
		                                                               int? NewCount,
		                                                               string Action,
		                                                               string Infobar = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LocTypeType _LocType = LocType;
			ItemlocRankType _NewRank = NewRank;
			IntType _NewCount = NewCount;
			StringType _Action = Action;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrValItemlocRankSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocType", _LocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRank", _NewRank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCount", _NewCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
