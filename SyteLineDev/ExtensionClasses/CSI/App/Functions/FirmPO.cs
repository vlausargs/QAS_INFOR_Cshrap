//PROJECT NAME: Data
//CLASS NAME: FirmPO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FirmPO : IFirmPO
	{
		readonly IApplicationDB appDB;
		
		public FirmPO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ReqNum,
			string Infobar,
			int? CheckInsertPermission) FirmPOSp(
			string Item,
			string RefNum,
			string ReqNum,
			string PoChange,
			int? BlanketQtyOverOK,
			string VendNum,
			decimal? BlanketQty,
			int? FromWorkbench = 0,
			string MrpWbDemandReqNum = null,
			int? MrpWbDemandReqLine = 0,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			int? RefSeq = 0,
			string Whse = null,
			int? PurchReqNotes = 0,
			string ManufacturerId = null,
			string ManufacturerItem = null,
			string Infobar = null,
			int? CheckInsertPermission = null,
			DateTime? ReleaseDate = null)
		{
			ItemType _Item = Item;
			UnknownRefNumLastTranType _RefNum = RefNum;
			ReqNumType _ReqNum = ReqNum;
			ListAlwaysSometimesNeverType _PoChange = PoChange;
			ListYesNoType _BlanketQtyOverOK = BlanketQtyOverOK;
			VendNumType _VendNum = VendNum;
			QtyUnitType _BlanketQty = BlanketQty;
			ListYesNoType _FromWorkbench = FromWorkbench;
			ReqNumType _MrpWbDemandReqNum = MrpWbDemandReqNum;
			ReqLineType _MrpWbDemandReqLine = MrpWbDemandReqLine;
			DateType _DueDate = DueDate;
			QtyUnitType _ReqdQty = ReqdQty;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			JobmatlProjmatlSeqType _RefSeq = RefSeq;
			WhseType _Whse = Whse;
			ListYesNoType _PurchReqNotes = PurchReqNotes;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CheckInsertPermission = CheckInsertPermission;
			DateType _ReleaseDate = ReleaseDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FirmPOSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChange", _PoChange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQtyOverOK", _BlanketQtyOverOK, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQty", _BlanketQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWorkbench", _FromWorkbench, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbDemandReqNum", _MrpWbDemandReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbDemandReqLine", _MrpWbDemandReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchReqNotes", _PurchReqNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckInsertPermission", _CheckInsertPermission, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReqNum = _ReqNum;
				Infobar = _Infobar;
				CheckInsertPermission = _CheckInsertPermission;
				
				return (Severity, ReqNum, Infobar, CheckInsertPermission);
			}
		}
	}
}
