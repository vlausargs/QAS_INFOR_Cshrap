//PROJECT NAME: Logistics
//CLASS NAME: CoBlnCfSans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoBlnCfSans : ICoBlnCfSans
	{
		readonly IApplicationDB appDB;
		
		
		public CoBlnCfSans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PAnyFound) CoBlnCfSansSp(string PCoNum,
		int? PCoLine,
		string PStatus,
		int? PAnyFound)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoBlnStatusType _PStatus = PStatus;
			FlagNyType _PAnyFound = PAnyFound;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoBlnCfSansSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStatus", _PStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAnyFound", _PAnyFound, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAnyFound = _PAnyFound;
				
				return (Severity, PAnyFound);
			}
		}
	}
}
