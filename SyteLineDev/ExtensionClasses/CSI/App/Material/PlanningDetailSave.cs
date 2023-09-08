//PROJECT NAME: Material
//CLASS NAME: PlanningDetailSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PlanningDetailSave : IPlanningDetailSave
	{
		readonly IApplicationDB appDB;
		
		
		public PlanningDetailSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PlanningDetailSaveSp(Guid? SessionID,
		string Item,
		DateTime? DueDate,
		decimal? QtyReq,
		decimal? OrigQty,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		string OrderType)
		{
			RowPointerType _SessionID = SessionID;
			ItemType _Item = Item;
			DateType _DueDate = DueDate;
			QtyUnitType _QtyReq = QtyReq;
			QtyUnitType _OrigQty = OrigQty;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefNumLastTranType _RefNum = RefNum;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			JobmatlProjmatlSeqType _RefSeq = RefSeq;
			RefTypeIJKMNOTType _OrderType = OrderType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PlanningDetailSaveSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigQty", _OrigQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
