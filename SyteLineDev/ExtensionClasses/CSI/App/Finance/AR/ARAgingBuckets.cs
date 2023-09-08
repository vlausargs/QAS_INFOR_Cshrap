//PROJECT NAME: Finance.AR
//CLASS NAME: ARAgingBuckets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARAgingBuckets : IARAgingBuckets
	{
		readonly IApplicationDB appDB;


		public ARAgingBuckets(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? ARAgingBucketsSp()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARAgingBucketsSp";

				var Severity = appDB.ExecuteNonQuery(cmd);

				return (Severity);
			}
		}
	}
}
