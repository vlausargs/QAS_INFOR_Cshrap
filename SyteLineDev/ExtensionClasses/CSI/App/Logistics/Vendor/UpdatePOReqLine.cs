//PROJECT NAME: Logistics
//CLASS NAME: UpdatePOReqLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class UpdatePOReqLine : IUpdatePOReqLine
	{
		readonly IApplicationDB appDB;
		
		
		public UpdatePOReqLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdatePOReqLineSp(decimal? QtyConv,
		decimal? PriceConv,
		string NonBaseUM,
		string Item,
		DateTime? DueDate,
		string ReqNum,
		int? ReqLine,
		string IprId,
		decimal? IprSeq,
		string Infobar)
		{
			QtyUnitNoNegType _QtyConv = QtyConv;
			CostPrcType _PriceConv = PriceConv;
			UMType _NonBaseUM = NonBaseUM;
			ItemType _Item = Item;
			DateTimeType _DueDate = DueDate;
			ReqNumType _ReqNum = ReqNum;
			ReqLineType _ReqLine = ReqLine;
			ItemPriceRequestIdType _IprId = IprId;
			SequenceType _IprSeq = IprSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePOReqLineSp";
				
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonBaseUM", _NonBaseUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqLine", _ReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IprId", _IprId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IprSeq", _IprSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
