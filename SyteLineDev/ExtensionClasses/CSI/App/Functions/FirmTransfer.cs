//PROJECT NAME: Data
//CLASS NAME: FirmTransfer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FirmTransfer : IFirmTransfer
	{
		readonly IApplicationDB appDB;
		
		public FirmTransfer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TrnNum,
			string Infobar,
			int? CheckInsertPermission) FirmTransferSp(
			string Item,
			string RefNum,
			string TrnNum,
			string FromSite,
			string FromWhse,
			string ToSite,
			string ToWhse,
			int? FromWorkbench = 0,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = null,
			int? RefRelease = null,
			int? RefSeq = null,
			string Infobar = null,
			int? CheckInsertPermission = null,
			int? CreateTransitLoc = 0)
		{
			ItemType _Item = Item;
			MrpOrderType _RefNum = RefNum;
			TrnNumType _TrnNum = TrnNum;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			ListYesNoType _FromWorkbench = FromWorkbench;
			DateType _DueDate = DueDate;
			QtyUnitType _ReqdQty = ReqdQty;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			JobmatlProjmatlSeqType _RefSeq = RefSeq;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CheckInsertPermission = CheckInsertPermission;
			ListYesNoType _CreateTransitLoc = CreateTransitLoc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FirmTransferSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWorkbench", _FromWorkbench, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckInsertPermission", _CheckInsertPermission, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateTransitLoc", _CreateTransitLoc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TrnNum = _TrnNum;
				Infobar = _Infobar;
				CheckInsertPermission = _CheckInsertPermission;
				
				return (Severity, TrnNum, Infobar, CheckInsertPermission);
			}
		}
	}
}
