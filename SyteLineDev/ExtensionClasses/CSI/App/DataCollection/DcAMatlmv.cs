//PROJECT NAME: DataCollection
//CLASS NAME: DcAMatlmv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAMatlmv : IDcAMatlmv
	{
		readonly IApplicationDB appDB;
		
		
		public DcAMatlmv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAMatlmvSp(string TTermId,
		string TEmpNum,
		DateTime? TTransDate,
		string TItem,
		string TCurWhse,
		string TLoc1,
		string TLot1,
		string TLoc2,
		string TLot2,
		decimal? TQty,
		string TUM,
		string DocumentNum,
		string Infobar)
		{
			DcTermIdType _TTermId = TTermId;
			EmpNumType _TEmpNum = TEmpNum;
			DateTimeType _TTransDate = TTransDate;
			ItemType _TItem = TItem;
			WhseType _TCurWhse = TCurWhse;
			LocType _TLoc1 = TLoc1;
			LotType _TLot1 = TLot1;
			LocType _TLoc2 = TLoc2;
			LotType _TLot2 = TLot2;
			QtyUnitType _TQty = TQty;
			UMType _TUM = TUM;
			DocumentNumType _DocumentNum = DocumentNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAMatlmvSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc1", _TLoc1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot1", _TLot1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc2", _TLoc2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot2", _TLot2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
