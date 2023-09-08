//PROJECT NAME: Data
//CLASS NAME: MvRsvd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MvRsvd : IMvRsvd
	{
		readonly IApplicationDB appDB;
		
		public MvRsvd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MvRsvdSp(
			decimal? PQty,
			string PItem,
			string PWhse,
			string FrLoc,
			string FrLot,
			string ToLoc,
			string ToLot,
			string PWorkkey = null,
			string Infobar = null,
			string FrImportDocId = null,
			string ToImportDocId = null)
		{
			QtyUnitType _PQty = PQty;
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			LocType _FrLoc = FrLoc;
			LotType _FrLot = FrLot;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			LongListType _PWorkkey = PWorkkey;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _FrImportDocId = FrImportDocId;
			ImportDocIdType _ToImportDocId = ToImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MvRsvdSp";
				
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrLoc", _FrLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrLot", _FrLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWorkkey", _PWorkkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrImportDocId", _FrImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToImportDocId", _ToImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
