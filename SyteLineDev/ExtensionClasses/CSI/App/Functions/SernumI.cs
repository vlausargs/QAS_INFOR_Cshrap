//PROJECT NAME: Data
//CLASS NAME: SernumI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SernumI : ISernumI
	{
		readonly IApplicationDB appDB;
		
		public SernumI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SernumISp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			decimal? TargetQty,
			Guid? TmpSerId,
			decimal? RsvdInvRsvdNum,
			string Infobar,
			string PImportDocId = null,
			int? PCalledFromPickWorkbench = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyTotlType _TargetQty = TargetQty;
			RowPointerType _TmpSerId = TmpSerId;
			RsvdNumType _RsvdInvRsvdNum = RsvdInvRsvdNum;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ListYesNoType _PCalledFromPickWorkbench = PCalledFromPickWorkbench;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SernumISp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetQty", _TargetQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsvdInvRsvdNum", _RsvdInvRsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCalledFromPickWorkbench", _PCalledFromPickWorkbench, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
