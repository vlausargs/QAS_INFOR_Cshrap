//PROJECT NAME: Material
//CLASS NAME: UpateItemPiecesForPurchaseOrderReveicing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpateItemPiecesForPurchaseOrderReveicing : IUpateItemPiecesForPurchaseOrderReveicing
	{
		readonly IApplicationDB appDB;
		
		
		public UpateItemPiecesForPurchaseOrderReveicing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpateItemPiecesForPurchaseOrderReveicingSp(string RefNum,
		int? RefLineSuffix,
		int? RefRelease,
		Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		string Infobar)
		{
			CoNumType _RefNum = RefNum;
			CoLineType _RefLineSuffix = RefLineSuffix;
			CoReleaseType _RefRelease = RefRelease;
			RowPointerType _ItempieceRowPointer = ItempieceRowPointer;
			PieceCountType _Change = Change;
			WhseType _NewWhse = NewWhse;
			LocType _NewLoc = NewLoc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpateItemPiecesForPurchaseOrderReveicingSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuffix", _RefLineSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItempieceRowPointer", _ItempieceRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Change", _Change, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewLoc", _NewLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
