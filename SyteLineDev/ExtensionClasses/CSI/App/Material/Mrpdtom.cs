//PROJECT NAME: Material
//CLASS NAME: Mrpdtom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Mrpdtom : IMrpdtom
	{
		readonly IApplicationDB appDB;
		
		public Mrpdtom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Next,
			DateTime? McalMDate,
			int? McalMdayNum,
			Guid? McalRowPointer,
			string Infobar) MrpdtomSp(
			DateTime? PDate,
			string OrderNum,
			string OrderType,
			int? OrdLineSuf,
			int? OrderRel,
			string RcvReq,
			string Item,
			int? Next,
			DateTime? McalMDate,
			int? McalMdayNum,
			Guid? McalRowPointer,
			string Infobar)
		{
			DateTimeType _PDate = PDate;
			ApsOrderType _OrderNum = OrderNum;
			MrpOrderType _OrderType = OrderType;
			MrpOrderLineType _OrdLineSuf = OrdLineSuf;
			MrpOrderReleaseType _OrderRel = OrderRel;
			LongListType _RcvReq = RcvReq;
			ItemType _Item = Item;
			FlagNyType _Next = Next;
			DateType _McalMDate = McalMDate;
			MdayNumType _McalMdayNum = McalMdayNum;
			RowPointerType _McalRowPointer = McalRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpdtomSp";
				
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdLineSuf", _OrdLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderRel", _OrderRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvReq", _RcvReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Next", _Next, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "McalMDate", _McalMDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "McalMdayNum", _McalMdayNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "McalRowPointer", _McalRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Next = _Next;
				McalMDate = _McalMDate;
				McalMdayNum = _McalMdayNum;
				McalRowPointer = _McalRowPointer;
				Infobar = _Infobar;
				
				return (Severity, Next, McalMDate, McalMdayNum, McalRowPointer, Infobar);
			}
		}
	}
}
