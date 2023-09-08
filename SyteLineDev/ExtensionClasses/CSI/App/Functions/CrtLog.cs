//PROJECT NAME: Data
//CLASS NAME: CrtLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CrtLog : ICrtLog
	{
		readonly IApplicationDB appDB;
		
		public CrtLog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CrtLogSp(
			string PDbUM,
			string PUM,
			string PCoNum,
			int? PCoLine)
		{
			UMType _PDbUM = PDbUM;
			UMType _PUM = PUM;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CrtLogSp";
				
				appDB.AddCommandParameter(cmd, "PDbUM", _PDbUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
