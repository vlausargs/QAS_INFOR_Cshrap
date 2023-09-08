//PROJECT NAME: THLOC
//CLASS NAME: TH_InventoryMonthEndProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
	public class TH_InventoryMonthEndProcess : ITH_InventoryMonthEndProcess
	{
		readonly IApplicationDB appDB;
		
		
		public TH_InventoryMonthEndProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TH_InventoryMonthEndProcessSp(DateTime? pDateStarting,
		DateTime? pDateEnding,
		string pItemStarting,
		string pItemEnding,
		string pWhseStarting,
		string pWhseEnding,
		string pLocStarting,
		string pLocEnding,
		string Infobar)
		{
			DateType _pDateStarting = pDateStarting;
			DateType _pDateEnding = pDateEnding;
			ItemType _pItemStarting = pItemStarting;
			ItemType _pItemEnding = pItemEnding;
			WhseType _pWhseStarting = pWhseStarting;
			WhseType _pWhseEnding = pWhseEnding;
			LocType _pLocStarting = pLocStarting;
			LocType _pLocEnding = pLocEnding;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TH_InventoryMonthEndProcessSp";
				
				appDB.AddCommandParameter(cmd, "pDateStarting", _pDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDateEnding", _pDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemStarting", _pItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemEnding", _pItemEnding, ParameterDirection.Input);
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
