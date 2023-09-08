//PROJECT NAME: Data
//CLASS NAME: TH_GetBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TH_GetBalance : ITH_GetBalance
	{
		readonly IApplicationDB appDB;
		
		public TH_GetBalance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Qty,
			decimal? Amount,
			string Infobar) TH_GetBalanceSp(
			DateTime? PeriodEnding,
			string pItem,
			string pWhse,
			string pLoc,
			string pLot,
			decimal? Qty,
			decimal? Amount,
			string Infobar)
		{
			DateType _PeriodEnding = PeriodEnding;
			ItemType _pItem = pItem;
			WhseType _pWhse = pWhse;
			LocType _pLoc = pLoc;
			LotType _pLot = pLot;
			QtyPerType _Qty = Qty;
			AmountType _Amount = Amount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TH_GetBalanceSp";
				
				appDB.AddCommandParameter(cmd, "PeriodEnding", _PeriodEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhse", _pWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLoc", _pLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLot", _pLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Qty = _Qty;
				Amount = _Amount;
				Infobar = _Infobar;
				
				return (Severity, Qty, Amount, Infobar);
			}
		}
	}
}
