//PROJECT NAME: CSIVendor
//CLASS NAME: GetNextRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetNextRank
	{
		int GetNextRankSp(string Item,
		                  ref short? NextRank,
		                  ref string Infobar);
	}
	
	public class GetNextRank : IGetNextRank
	{
		readonly IApplicationDB appDB;
		
		public GetNextRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetNextRankSp(string Item,
		                         ref short? NextRank,
		                         ref string Infobar)
		{
			ItemType _Item = Item;
			ItemvendRankType _NextRank = NextRank;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextRankSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextRank", _NextRank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextRank = _NextRank;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
