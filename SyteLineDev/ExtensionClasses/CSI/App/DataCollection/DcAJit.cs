//PROJECT NAME: DataCollection
//CLASS NAME: DcAJit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAJit : IDcAJit
	{
		readonly IApplicationDB appDB;
		
		
		public DcAJit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAJitSp(string TTermId,
		string TTransType,
		string TEmpNum,
		DateTime? TTransDate,
		decimal? TCompleted,
		string TItem,
		string TShift,
		string TLocation,
		string TLot,
		string TCurWhse,
		string Infobar)
		{
			DcTermIdType _TTermId = TTermId;
			DcTransTypeType _TTransType = TTransType;
			EmpNumType _TEmpNum = TEmpNum;
			DateType _TTransDate = TTransDate;
			QtyUnitType _TCompleted = TCompleted;
			ItemType _TItem = TItem;
			ShiftType _TShift = TShift;
			LocType _TLocation = TLocation;
			LotType _TLot = TLot;
			WhseType _TCurWhse = TCurWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAJitSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransType", _TTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCompleted", _TCompleted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShift", _TShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocation", _TLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
