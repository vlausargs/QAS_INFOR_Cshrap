//PROJECT NAME: Admin
//CLASS NAME: SaveUserSelectedKPI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class SaveUserSelectedKPI : ISaveUserSelectedKPI
	{
		IApplicationDB appDB;
		
		
		public SaveUserSelectedKPI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SaveUserSelectedKPISp(int? Selected,
		int? KPINum,
		string Infobar)
		{
			ListYesNoType _Selected = Selected;
			WBKPINumType _KPINum = KPINum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveUserSelectedKPISp";
				
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
