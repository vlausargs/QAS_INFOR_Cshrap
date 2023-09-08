//PROJECT NAME: POS
//CLASS NAME: SSSPOSConPosP2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSConPosP2 : ISSSPOSConPosP2
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSConPosP2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSConPosP2Sp(
			Guid? SessionId,
			string Contract,
			string ContStat,
			DateTime? BilledThruDate,
			string Infobar)
		{
			RowPointerType _SessionId = SessionId;
			StringType _Contract = Contract;
			StringType _ContStat = ContStat;
			DateType _BilledThruDate = BilledThruDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSConPosP2Sp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContStat", _ContStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BilledThruDate", _BilledThruDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
