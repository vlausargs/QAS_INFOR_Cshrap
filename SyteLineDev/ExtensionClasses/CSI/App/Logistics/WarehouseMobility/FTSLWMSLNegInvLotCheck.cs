//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMSLNegInvLotCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLWMSLNegInvLotCheck
	{
		(int? ReturnCode, decimal? Onhand, decimal? QtyRsvd, decimal? QtyContained, string LocLot, decimal? LocAvail, string Infobar, int? SLLotExp, int? SLLotExpDate) FTSLWMSLNegInvLotCheckSp(string Whse,
		string Item,
		string Location,
		string Lot,
		byte? SLAllowNegInvFlag,
		byte? FTAllowNegInvFlag,
		byte? Transaction,
		string Field,
		byte? AllowNewLot = (byte)0,
		decimal? AvailQty = null,
		decimal? ScannedQty = null,
		decimal? Onhand = 0,
		decimal? QtyRsvd = 0,
		decimal? QtyContained = 0,
		string LocLot = null,
		decimal? LocAvail = null,
		string Infobar = null,
		int? SLLotExp = 0,
		int? SLLotExpDate = 0);
	}
	
	public class FTSLWMSLNegInvLotCheck : IFTSLWMSLNegInvLotCheck
	{
		readonly IApplicationDB appDB;
		
		public FTSLWMSLNegInvLotCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Onhand, decimal? QtyRsvd, decimal? QtyContained, string LocLot, decimal? LocAvail, string Infobar, int? SLLotExp, int? SLLotExpDate) FTSLWMSLNegInvLotCheckSp(string Whse,
		string Item,
		string Location,
		string Lot,
		byte? SLAllowNegInvFlag,
		byte? FTAllowNegInvFlag,
		byte? Transaction,
		string Field,
		byte? AllowNewLot = (byte)0,
		decimal? AvailQty = null,
		decimal? ScannedQty = null,
		decimal? Onhand = 0,
		decimal? QtyRsvd = 0,
		decimal? QtyContained = 0,
		string LocLot = null,
		decimal? LocAvail = null,
		string Infobar = null,
		int? SLLotExp = 0,
		int? SLLotExpDate = 0)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Location = Location;
			LotType _Lot = Lot;
			ListYesNoType _SLAllowNegInvFlag = SLAllowNegInvFlag;
			ListYesNoType _FTAllowNegInvFlag = FTAllowNegInvFlag;
			ListYesNoType _Transaction = Transaction;
			PoNumType _Field = Field;
			ListYesNoType _AllowNewLot = AllowNewLot;
			QtyTotlType _AvailQty = AvailQty;
			QtyTotlType _ScannedQty = ScannedQty;
			QtyTotlType _Onhand = Onhand;
			QtyTotlType _QtyRsvd = QtyRsvd;
			QtyTotlType _QtyContained = QtyContained;
			LotType _LocLot = LocLot;
			QtyTotlType _LocAvail = LocAvail;
			InfobarType _Infobar = Infobar;
			CustSeqType _SLLotExp = SLLotExp;
			CustSeqType _SLLotExpDate = SLLotExpDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLWMSLNegInvLotCheckSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLAllowNegInvFlag", _SLAllowNegInvFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTAllowNegInvFlag", _FTAllowNegInvFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Transaction", _Transaction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Field", _Field, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowNewLot", _AllowNewLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AvailQty", _AvailQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScannedQty", _ScannedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Onhand", _Onhand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRsvd", _QtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyContained", _QtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocLot", _LocLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocAvail", _LocAvail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SLLotExp", _SLLotExp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SLLotExpDate", _SLLotExpDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Onhand = _Onhand;
				QtyRsvd = _QtyRsvd;
				QtyContained = _QtyContained;
				LocLot = _LocLot;
				LocAvail = _LocAvail;
				Infobar = _Infobar;
				SLLotExp = _SLLotExp;
				SLLotExpDate = _SLLotExpDate;
				
				return (Severity, Onhand, QtyRsvd, QtyContained, LocLot, LocAvail, Infobar, SLLotExp, SLLotExpDate);
			}
		}
	}
}
