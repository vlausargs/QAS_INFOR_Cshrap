//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSUnitConfigAutoCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSUnitConfigAutoCreate : IEXTSSSFSUnitConfigAutoCreate
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSUnitConfigAutoCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSUnitConfigAutoCreateSp(
			decimal? TrackNum)
		{
			MatlTransNumType _TrackNum = TrackNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSUnitConfigAutoCreateSp";
				
				appDB.AddCommandParameter(cmd, "TrackNum", _TrackNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
