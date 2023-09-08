//PROJECT NAME: Data
//CLASS NAME: UpdItemCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdItemCust : IUpdItemCust
	{
		readonly IApplicationDB appDB;
		
		public UpdItemCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdItemCustSp(
			string CoNum,
			string CoCustNum,
			string NewStat,
			decimal? OldQtyOrderedConv,
			decimal? OldQtyOrdered,
			string OldUM,
			string OldWhse,
			string NewWhse,
			decimal? OldQtyShipped,
			string OldStatus,
			decimal? NewQtyOrderedConv,
			decimal? NewQtyOrdered,
			string NewItem,
			string NewUM,
			string CustItem,
			int? NewRecord,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CoCustNum = CoCustNum;
			CoitemStatusType _NewStat = NewStat;
			QtyUnitNoNegType _OldQtyOrderedConv = OldQtyOrderedConv;
			QtyUnitNoNegType _OldQtyOrdered = OldQtyOrdered;
			UMType _OldUM = OldUM;
			WhseType _OldWhse = OldWhse;
			WhseType _NewWhse = NewWhse;
			QtyUnitNoNegType _OldQtyShipped = OldQtyShipped;
			CoitemStatusType _OldStatus = OldStatus;
			QtyUnitNoNegType _NewQtyOrderedConv = NewQtyOrderedConv;
			QtyUnitNoNegType _NewQtyOrdered = NewQtyOrdered;
			ItemType _NewItem = NewItem;
			UMType _NewUM = NewUM;
			CustItemType _CustItem = CustItem;
			Flag _NewRecord = NewRecord;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdItemCustSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStat", _NewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldQtyOrderedConv", _OldQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldQtyOrdered", _OldQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUM", _OldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldQtyShipped", _OldQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStatus", _OldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewQtyOrderedConv", _NewQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewQtyOrdered", _NewQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUM", _NewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRecord", _NewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
