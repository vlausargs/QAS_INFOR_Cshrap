//PROJECT NAME: Production
//CLASS NAME: PmfRptInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptInit : IPmfRptInit
	{
		readonly IApplicationDB appDB;
		
		public PmfRptInit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfRptInitSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptInitSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
