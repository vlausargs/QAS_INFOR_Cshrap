//PROJECT NAME: CSICodes
//CLASS NAME: GetParmAnalyticalLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetParmAnalyticalLedger
	{
		int GetParmAnalyticalLedgerSp(ref byte? AnalyticalLedger);
	}
	
	public class GetParmAnalyticalLedger : IGetParmAnalyticalLedger
	{
		readonly IApplicationDB appDB;
		
		public GetParmAnalyticalLedger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetParmAnalyticalLedgerSp(ref byte? AnalyticalLedger)
		{
			ListYesNoType _AnalyticalLedger = AnalyticalLedger;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetParmAnalyticalLedgerSp";
				
				appDB.AddCommandParameter(cmd, "AnalyticalLedger", _AnalyticalLedger, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AnalyticalLedger = _AnalyticalLedger;
				
				return Severity;
			}
		}
	}
}
