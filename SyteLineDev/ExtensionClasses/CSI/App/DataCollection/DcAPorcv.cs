//PROJECT NAME: DataCollection
//CLASS NAME: DcAPorcv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPorcv : IDcAPorcv
	{
		readonly IApplicationDB appDB;
		
		
		public DcAPorcv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAPorcvSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TTransDate,
		string TPoNum,
		int? TPoLine,
		int? TPoRelease,
		string TItem,
		string TLocation,
		string TLot,
		string TCurWhse,
		string TReasonCode,
		string TUM,
		decimal? TQty,
		decimal? TQtyRejected,
		string Infobar)
		{
			DcTermIdType _TTermId = TTermId;
			DcTransNumType _TTransType = TTransType;
			EmpNumType _TEmpNum = TEmpNum;
			DateTimeType _TTransDate = TTransDate;
			PoNumType _TPoNum = TPoNum;
			PoLineType _TPoLine = TPoLine;
			PoReleaseType _TPoRelease = TPoRelease;
			ItemType _TItem = TItem;
			LocType _TLocation = TLocation;
			LotType _TLot = TLot;
			WhseType _TCurWhse = TCurWhse;
			ReasonCodeType _TReasonCode = TReasonCode;
			UMType _TUM = TUM;
			QtyUnitType _TQty = TQty;
			QtyUnitType _TQtyRejected = TQtyRejected;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAPorcvSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransType", _TTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoNum", _TPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoLine", _TPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoRelease", _TPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocation", _TLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TReasonCode", _TReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyRejected", _TQtyRejected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
