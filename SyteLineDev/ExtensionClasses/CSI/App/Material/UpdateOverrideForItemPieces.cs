//PROJECT NAME: Material
//CLASS NAME: UpdateOverrideForItemPieces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdateOverrideForItemPieces : IUpdateOverrideForItemPieces
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateOverrideForItemPieces(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateOverrideForItemPiecesSp(Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		string Infobar,
		int? ExitImmediately = 0,
		int? CurrentPieceCount = 0)
		{
			RowPointerType _ItempieceRowPointer = ItempieceRowPointer;
			PieceCountType _Change = Change;
			WhseType _NewWhse = NewWhse;
			LocType _NewLoc = NewLoc;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ExitImmediately = ExitImmediately;
			PieceCountType _CurrentPieceCount = CurrentPieceCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateOverrideForItemPiecesSp";
				
				appDB.AddCommandParameter(cmd, "ItempieceRowPointer", _ItempieceRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Change", _Change, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewLoc", _NewLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExitImmediately", _ExitImmediately, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPieceCount", _CurrentPieceCount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
