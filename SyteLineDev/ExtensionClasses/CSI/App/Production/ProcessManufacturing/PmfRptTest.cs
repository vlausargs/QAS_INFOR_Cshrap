//PROJECT NAME: Production
//CLASS NAME: PmfRptTest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptTest : IPmfRptTest
	{
		readonly IApplicationDB appDB;
		
		public PmfRptTest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfRptTestSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptTestSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
