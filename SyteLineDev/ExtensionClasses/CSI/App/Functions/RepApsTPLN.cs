//PROJECT NAME: Data
//CLASS NAME: RepApsTPLN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepApsTPLN : IRepApsTPLN
	{
		readonly IApplicationDB appDB;
		
		public RepApsTPLN(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepApsTPLNSp(
			string Item,
			DateTime? DueDate,
			decimal? Qty,
			string ReceivingSite,
			string tpln_OrderID,
			string Infobar)
		{
			ItemType _Item = Item;
			DateTimeType _DueDate = DueDate;
			QtyUnitType _Qty = Qty;
			SiteType _ReceivingSite = ReceivingSite;
			ApsOrderType _tpln_OrderID = tpln_OrderID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepApsTPLNSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivingSite", _ReceivingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tpln_OrderID", _tpln_OrderID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
