//PROJECT NAME: CSIProjects
//CLASS NAME: ProjmatlValidateLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjmatlValidateLoc
	{
		int ProjmatlValidateLocSp(string Item,
		                          string ProjNum,
		                          int? TaskNum,
		                          int? SeqNum,
		                          string Whse,
		                          string TLoc,
		                          double? UomConvFactor,
		                          ref string TLot,
		                          ref decimal? TOnHand,
		                          ref decimal? TOnHandConv,
		                          ref decimal? TQty,
		                          ref decimal? TQtyConv,
		                          ref string Infobar,
		                          ref string TImportDocId);
	}
	
	public class ProjmatlValidateLoc : IProjmatlValidateLoc
	{
		readonly IApplicationDB appDB;
		
		public ProjmatlValidateLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjmatlValidateLocSp(string Item,
		                                 string ProjNum,
		                                 int? TaskNum,
		                                 int? SeqNum,
		                                 string Whse,
		                                 string TLoc,
		                                 double? UomConvFactor,
		                                 ref string TLot,
		                                 ref decimal? TOnHand,
		                                 ref decimal? TOnHandConv,
		                                 ref decimal? TQty,
		                                 ref decimal? TQtyConv,
		                                 ref string Infobar,
		                                 ref string TImportDocId)
		{
			ItemType _Item = Item;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _SeqNum = SeqNum;
			WhseType _Whse = Whse;
			LocType _TLoc = TLoc;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			LotType _TLot = TLot;
			QtyPerType _TOnHand = TOnHand;
			QtyPerType _TOnHandConv = TOnHandConv;
			QtyPerType _TQty = TQty;
			QtyPerType _TQtyConv = TQtyConv;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _TImportDocId = TImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjmatlValidateLocSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeqNum", _SeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOnHand", _TOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOnHandConv", _TOnHandConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyConv", _TQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TImportDocId", _TImportDocId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TLot = _TLot;
				TOnHand = _TOnHand;
				TOnHandConv = _TOnHandConv;
				TQty = _TQty;
				TQtyConv = _TQtyConv;
				Infobar = _Infobar;
				TImportDocId = _TImportDocId;
				
				return Severity;
			}
		}
	}
}
