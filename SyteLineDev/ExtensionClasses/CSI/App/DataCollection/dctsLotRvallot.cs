//PROJECT NAME: DataCollection
//CLASS NAME: dctsLotRvallot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class dctsLotRvallot : IdctsLotRvallot
	{
		readonly IApplicationDB appDB;
		
		
		public dctsLotRvallot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) dctsLotRvallotSp(string Item,
		string Lot,
		string RemoteSiteLot,
		string Infobar,
		string Site = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			ListExistingCreateBothType _RemoteSiteLot = RemoteSiteLot;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dctsLotRvallotSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLot", _RemoteSiteLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
