//PROJECT NAME: Data
//CLASS NAME: FirmPreq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FirmPreq : IFirmPreq
	{
		readonly IApplicationDB appDB;
		
		public FirmPreq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ReqNum,
			string Infobar,
			int? CheckInsertPermission) FirmPreqSp(
			string Item,
			string RefNum,
			string ReqNum,
			string VendNum,
			int? FromWorkbench = 0,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = null,
			int? RefRelease = null,
			int? RefSeq = null,
			string Whse = null,
			string ManufacturerId = null,
			string ManufacturerItem = null,
			string Infobar = null,
			int? CheckInsertPermission = null)
		{
			ItemType _Item = Item;
			UnknownRefNumLastTranType _RefNum = RefNum;
			ReqNumType _ReqNum = ReqNum;
			VendNumType _VendNum = VendNum;
			ListYesNoType _FromWorkbench = FromWorkbench;
			DateType _DueDate = DueDate;
			QtyUnitType _ReqdQty = ReqdQty;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			JobmatlProjmatlSeqType _RefSeq = RefSeq;
			WhseType _Whse = Whse;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CheckInsertPermission = CheckInsertPermission;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FirmPreqSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWorkbench", _FromWorkbench, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckInsertPermission", _CheckInsertPermission, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReqNum = _ReqNum;
				Infobar = _Infobar;
				CheckInsertPermission = _CheckInsertPermission;
				
				return (Severity, ReqNum, Infobar, CheckInsertPermission);
			}
		}
	}
}
