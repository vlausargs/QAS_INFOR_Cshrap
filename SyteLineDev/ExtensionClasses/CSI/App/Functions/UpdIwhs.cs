//PROJECT NAME: Data
//CLASS NAME: UpdIwhs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdIwhs : IUpdIwhs
	{
		readonly IApplicationDB appDB;
		
		public UpdIwhs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			decimal? ItemcustPurchYtdOld,
			decimal? ItemcustPurchYtdNew,
			decimal? ItemcustOrderYtdOld,
			decimal? ItemcustOrderYtdNew,
			decimal? ItemcustOrderPtdOld,
			decimal? ItemcustOrderPtdNew,
			decimal? ItemwhseQtyAllocCoOld,
			decimal? ItemwhseQtyAllocCoNew) UpdIwhsSp(
			string ParmCoNum,
			string ParmCoCustNum,
			string ParmNewStat,
			decimal? ParmOldQtyOrderedConv,
			decimal? ParmOldQtyOrdered,
			string ParmOldItem,
			string ParmOldUM,
			string ParmOldWhse,
			string ParmNewWhse,
			decimal? ParmOldQtyShipped,
			string ParmOldStatus,
			decimal? ParmNewQtyOrderedConv,
			decimal? ParmNewQtyOrdered,
			string ParmNewItem,
			string ParmNewUM,
			string ParmCustItem,
			int? ParmNewRecord,
			string Infobar,
			int? BufferItemwhse = 0,
			decimal? ItemcustPurchYtdOld = null,
			decimal? ItemcustPurchYtdNew = null,
			decimal? ItemcustOrderYtdOld = null,
			decimal? ItemcustOrderYtdNew = null,
			decimal? ItemcustOrderPtdOld = null,
			decimal? ItemcustOrderPtdNew = null,
			decimal? ItemwhseQtyAllocCoOld = null,
			decimal? ItemwhseQtyAllocCoNew = null)
		{
			CoNumType _ParmCoNum = ParmCoNum;
			CustNumType _ParmCoCustNum = ParmCoCustNum;
			CoitemStatusType _ParmNewStat = ParmNewStat;
			QtyUnitNoNegType _ParmOldQtyOrderedConv = ParmOldQtyOrderedConv;
			QtyUnitNoNegType _ParmOldQtyOrdered = ParmOldQtyOrdered;
			ItemType _ParmOldItem = ParmOldItem;
			UMType _ParmOldUM = ParmOldUM;
			WhseType _ParmOldWhse = ParmOldWhse;
			WhseType _ParmNewWhse = ParmNewWhse;
			QtyUnitNoNegType _ParmOldQtyShipped = ParmOldQtyShipped;
			CoitemStatusType _ParmOldStatus = ParmOldStatus;
			QtyUnitNoNegType _ParmNewQtyOrderedConv = ParmNewQtyOrderedConv;
			QtyUnitNoNegType _ParmNewQtyOrdered = ParmNewQtyOrdered;
			ItemType _ParmNewItem = ParmNewItem;
			UMType _ParmNewUM = ParmNewUM;
			ItemType _ParmCustItem = ParmCustItem;
			Flag _ParmNewRecord = ParmNewRecord;
			InfobarType _Infobar = Infobar;
			ListYesNoType _BufferItemwhse = BufferItemwhse;
			AmtTotType _ItemcustPurchYtdOld = ItemcustPurchYtdOld;
			AmtTotType _ItemcustPurchYtdNew = ItemcustPurchYtdNew;
			AmtTotType _ItemcustOrderYtdOld = ItemcustOrderYtdOld;
			AmtTotType _ItemcustOrderYtdNew = ItemcustOrderYtdNew;
			AmtTotType _ItemcustOrderPtdOld = ItemcustOrderPtdOld;
			AmtTotType _ItemcustOrderPtdNew = ItemcustOrderPtdNew;
			AmtTotType _ItemwhseQtyAllocCoOld = ItemwhseQtyAllocCoOld;
			AmtTotType _ItemwhseQtyAllocCoNew = ItemwhseQtyAllocCoNew;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdIwhsSp";
				
				appDB.AddCommandParameter(cmd, "ParmCoNum", _ParmCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCoCustNum", _ParmCoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewStat", _ParmNewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldQtyOrderedConv", _ParmOldQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldQtyOrdered", _ParmOldQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldItem", _ParmOldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldUM", _ParmOldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldWhse", _ParmOldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewWhse", _ParmNewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldQtyShipped", _ParmOldQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldStatus", _ParmOldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewQtyOrderedConv", _ParmNewQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewQtyOrdered", _ParmNewQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewItem", _ParmNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewUM", _ParmNewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCustItem", _ParmCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewRecord", _ParmNewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BufferItemwhse", _BufferItemwhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemcustPurchYtdOld", _ItemcustPurchYtdOld, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemcustPurchYtdNew", _ItemcustPurchYtdNew, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemcustOrderYtdOld", _ItemcustOrderYtdOld, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemcustOrderYtdNew", _ItemcustOrderYtdNew, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemcustOrderPtdOld", _ItemcustOrderPtdOld, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemcustOrderPtdNew", _ItemcustOrderPtdNew, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemwhseQtyAllocCoOld", _ItemwhseQtyAllocCoOld, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemwhseQtyAllocCoNew", _ItemwhseQtyAllocCoNew, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ItemcustPurchYtdOld = _ItemcustPurchYtdOld;
				ItemcustPurchYtdNew = _ItemcustPurchYtdNew;
				ItemcustOrderYtdOld = _ItemcustOrderYtdOld;
				ItemcustOrderYtdNew = _ItemcustOrderYtdNew;
				ItemcustOrderPtdOld = _ItemcustOrderPtdOld;
				ItemcustOrderPtdNew = _ItemcustOrderPtdNew;
				ItemwhseQtyAllocCoOld = _ItemwhseQtyAllocCoOld;
				ItemwhseQtyAllocCoNew = _ItemwhseQtyAllocCoNew;
				
				return (Severity, Infobar, ItemcustPurchYtdOld, ItemcustPurchYtdNew, ItemcustOrderYtdOld, ItemcustOrderYtdNew, ItemcustOrderPtdOld, ItemcustOrderPtdNew, ItemwhseQtyAllocCoOld, ItemwhseQtyAllocCoNew);
			}
		}
	}
}
