//PROJECT NAME: THLOC
//CLASS NAME: THACreateStockBalanceCons.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
	public class THACreateStockBalanceCons : ITHACreateStockBalanceCons
	{
		readonly IApplicationDB appDB;
		
		
		public THACreateStockBalanceCons(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) THACreateStockBalanceConsSp(DateTime? pStartDate,
		DateTime? pEndDate,
		string pStartItem,
		string pEndItem,
		string pWhseStarting,
		string pWhseEnding,
		string pLocStarting,
		string pLocEnding,
		string Infobar)
		{
			DateType _pStartDate = pStartDate;
			DateType _pEndDate = pEndDate;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			WhseType _pWhseStarting = pWhseStarting;
			WhseType _pWhseEnding = pWhseEnding;
			LocType _pLocStarting = pLocStarting;
			LocType _pLocEnding = pLocEnding;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THACreateStockBalanceConsSp";
				
				appDB.AddCommandParameter(cmd, "pStartDate", _pStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhseStarting", _pWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhseEnding", _pWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLocStarting", _pLocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLocEnding", _pLocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
