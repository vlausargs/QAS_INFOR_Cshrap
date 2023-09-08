//PROJECT NAME: Data
//CLASS NAME: MvRsvdLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MvRsvdLoc : IMvRsvdLoc
	{
		readonly IApplicationDB appDB;
		
		public MvRsvdLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MvRsvdLocSp(
			string PItem,
			string PWhse,
			string Loc,
			string Lot,
			decimal? PQty,
			int? Fctr,
			string Infobar,
			string ImportDocId)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitType _PQty = PQty;
			IntType _Fctr = Fctr;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MvRsvdLocSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fctr", _Fctr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
