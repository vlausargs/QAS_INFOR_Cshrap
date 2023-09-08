//PROJECT NAME: Logistics
//CLASS NAME: CascadeStatusChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CascadeStatusChange : ICascadeStatusChange
	{
		readonly IApplicationDB appDB;
		
		
		public CascadeStatusChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CascadeStatusChangeSp(string PPoNum,
		string POldStat,
		string PNewStat,
		int? PerformUpdate,
		string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			PoStatType _POldStat = POldStat;
			PoStatType _PNewStat = PNewStat;
			FlagNyType _PerformUpdate = PerformUpdate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CascadeStatusChangeSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldStat", _POldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewStat", _PNewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerformUpdate", _PerformUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
