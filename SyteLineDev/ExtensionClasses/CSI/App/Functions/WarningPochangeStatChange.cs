//PROJECT NAME: Data
//CLASS NAME: WarningPochangeStatChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class WarningPochangeStatChange : IWarningPochangeStatChange
	{
		readonly IApplicationDB appDB;
		
		public WarningPochangeStatChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) WarningPochangeStatChangeSp(
			string PPoNum,
			string PNewStat,
			string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			PoStatType _PNewStat = PNewStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WarningPochangeStatChangeSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewStat", _PNewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
