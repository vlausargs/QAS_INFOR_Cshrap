//PROJECT NAME: Data
//CLASS NAME: EdiOutPo2P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutPo2P : IEdiOutPo2P
	{
		readonly IApplicationDB appDB;
		
		public EdiOutPo2P(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutPo2PSp(
			decimal? ProcessId,
			string TranType)
		{
			TokenType _ProcessId = ProcessId;
			StringType _TranType = TranType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutPo2PSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranType", _TranType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
