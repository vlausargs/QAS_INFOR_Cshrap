//PROJECT NAME: Production
//CLASS NAME: PmfLogSpecCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfLogSpecCopy : IPmfLogSpecCopy
	{
		readonly IApplicationDB appDB;
		
		public PmfLogSpecCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfLogSpecCopySp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfLogSpecCopySp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
