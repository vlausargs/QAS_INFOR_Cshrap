//PROJECT NAME: Production
//CLASS NAME: PmfValidateSpec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfValidateSpec : IPmfValidateSpec
	{
		readonly IApplicationDB appDB;
		
		public PmfValidateSpec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfValidateSpecSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfValidateSpecSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
