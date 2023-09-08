//PROJECT NAME: Material
//CLASS NAME: MrpExc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpExc : IMrpExc
	{
		readonly IApplicationDB appDB;
		
		public MrpExc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MrpExcSp(
			string OrderNum,
			string OrderType,
			string Item,
			DateTime? DateReq,
			int? ExceptCode,
			decimal? Qty,
			int? OrdLineSuf,
			int? OrderRel,
			string Infobar,
			int? BufferExcMesg = 0,
			Guid? ProcessId = null)
		{
			ApsOrderType _OrderNum = OrderNum;
			MrpOrderTypeType _OrderType = OrderType;
			ItemType _Item = Item;
			DateType _DateReq = DateReq;
			MrpExceptCodeType _ExceptCode = ExceptCode;
			QtyUnitType _Qty = Qty;
			MrpOrderLineType _OrdLineSuf = OrdLineSuf;
			MrpOrderReleaseType _OrderRel = OrderRel;
			InfobarType _Infobar = Infobar;
			ListYesNoType _BufferExcMesg = BufferExcMesg;
			RowPointerType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpExcSp";
				
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateReq", _DateReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptCode", _ExceptCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdLineSuf", _OrdLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderRel", _OrderRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BufferExcMesg", _BufferExcMesg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
