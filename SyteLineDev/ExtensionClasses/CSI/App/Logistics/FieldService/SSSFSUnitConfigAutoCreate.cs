//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigAutoCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigAutoCreate : ISSSFSUnitConfigAutoCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitConfigAutoCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSUnitConfigAutoCreateSp(
			decimal? TrackNum)
		{
			MatlTransNumType _TrackNum = TrackNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigAutoCreateSp";
				
				appDB.AddCommandParameter(cmd, "TrackNum", _TrackNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
