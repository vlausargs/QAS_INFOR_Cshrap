//PROJECT NAME: Data
//CLASS NAME: InventoryConstoCustOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InventoryConstoCustOrder : IInventoryConstoCustOrder
	{
		readonly IApplicationDB appDB;
		
		public InventoryConstoCustOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? RowPointer,
			string Infobar) InventoryConstoCustOrderSp(
			string pOrderType,
			string pStat,
			string CoCustNum,
			int? CoCustSeq,
			DateTime? pOrderDate,
			string pWhse,
			int? pCoConsignment = 0,
			Guid? RowPointer = null,
			string Infobar = null)
		{
			StringType _pOrderType = pOrderType;
			StringType _pStat = pStat;
			CustNumType _CoCustNum = CoCustNum;
			CustSeqType _CoCustSeq = CoCustSeq;
			DateType _pOrderDate = pOrderDate;
			WhseType _pWhse = pWhse;
			ListYesNoType _pCoConsignment = pCoConsignment;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InventoryConstoCustOrderSp";
				
				appDB.AddCommandParameter(cmd, "pOrderType", _pOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustSeq", _CoCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderDate", _pOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhse", _pWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoConsignment", _pCoConsignment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}
