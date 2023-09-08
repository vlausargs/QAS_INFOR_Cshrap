//PROJECT NAME: DataCollection
//CLASS NAME: DcPoUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcPoUpdate : IDcPoUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public DcPoUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcPoUpdateSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		string TPoNum,
		int? TPoLine,
		int? TPoRelease,
		string TItem,
		string TLocation,
		string TLot,
		string TCurWhse,
		string TReasonCode,
		string TUM,
		decimal? TQtyReceived,
		decimal? TQtyRejected,
		decimal? TQtyReturned,
		string SerNumList,
		string Infobar)
		{
			DcTermIdType _TTermId = TTermId;
			DcTransNumType _TTransType = TTransType;
			EmpNumType _TEmpNum = TEmpNum;
			PoNumType _TPoNum = TPoNum;
			PoLineType _TPoLine = TPoLine;
			PoReleaseType _TPoRelease = TPoRelease;
			ItemType _TItem = TItem;
			LocType _TLocation = TLocation;
			LotType _TLot = TLot;
			WhseType _TCurWhse = TCurWhse;
			ReasonCodeType _TReasonCode = TReasonCode;
			UMType _TUM = TUM;
			QtyUnitType _TQtyReceived = TQtyReceived;
			QtyUnitType _TQtyRejected = TQtyRejected;
			QtyUnitType _TQtyReturned = TQtyReturned;
			Infobar _SerNumList = SerNumList;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcPoUpdateSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransType", _TTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoNum", _TPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoLine", _TPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoRelease", _TPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocation", _TLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TReasonCode", _TReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyReceived", _TQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyRejected", _TQtyRejected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyReturned", _TQtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumList", _SerNumList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
