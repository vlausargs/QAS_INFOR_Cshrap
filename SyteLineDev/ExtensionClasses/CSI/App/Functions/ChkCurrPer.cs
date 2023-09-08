//PROJECT NAME: Data
//CLASS NAME: ChkCurrPer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChkCurrPer : IChkCurrPer
	{
		readonly IApplicationDB appDB;
		
		public ChkCurrPer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string WarmMsg) ChkCurrPerSp(
			DateTime? Date,
			string WarmMsg)
		{
			DateType _Date = Date;
			InfobarType _WarmMsg = WarmMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkCurrPerSp";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarmMsg", _WarmMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WarmMsg = _WarmMsg;
				
				return (Severity, WarmMsg);
			}
		}
	}
}
