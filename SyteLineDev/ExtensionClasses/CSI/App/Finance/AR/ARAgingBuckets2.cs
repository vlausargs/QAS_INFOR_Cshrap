//PROJECT NAME: Finance
//CLASS NAME: ARAgingBuckets2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARAgingBuckets2 : IARAgingBuckets2
	{
		readonly IApplicationDB appDB;
		
		public ARAgingBuckets2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ARAgingBuckets2Sp(
			int? PSubordinate = 0,
			int? PSiteQuery = 0)
		{
			FlagNyType _PSubordinate = PSubordinate;
			FlagNyType _PSiteQuery = PSiteQuery;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARAgingBuckets2Sp";
				
				appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteQuery", _PSiteQuery, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
