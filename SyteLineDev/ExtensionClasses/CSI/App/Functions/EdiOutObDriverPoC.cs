//PROJECT NAME: Data
//CLASS NAME: EdiOutObDriverPoC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutObDriverPoC : IEdiOutObDriverPoC
	{
		readonly IApplicationDB appDB;
		
		public EdiOutObDriverPoC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EdiOutObDriverPoCSp(
			string PPoNum,
			string PPoItemStat,
			string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			StringType _PPoItemStat = PPoItemStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutObDriverPoCSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoItemStat", _PPoItemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
