//PROJECT NAME: Material
//CLASS NAME: UpdateOverrideForItemPiecesAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdateOverrideForItemPiecesAll : IUpdateOverrideForItemPiecesAll
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateOverrideForItemPiecesAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateOverrideForItemPiecesAllSp(Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		string SiteRef = null,
		string Infobar = null)
		{
			RowPointerType _ItempieceRowPointer = ItempieceRowPointer;
			PieceCountType _Change = Change;
			WhseType _NewWhse = NewWhse;
			LocType _NewLoc = NewLoc;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateOverrideForItemPiecesAllSp";
				
				appDB.AddCommandParameter(cmd, "ItempieceRowPointer", _ItempieceRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Change", _Change, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewLoc", _NewLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
