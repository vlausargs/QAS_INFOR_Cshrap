//PROJECT NAME: Production
//CLASS NAME: PmfSpecValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfSpecValidate
	{
		int? PmfSpecValidateSp();
	}
	
	public class PmfSpecValidate : IPmfSpecValidate
	{
		readonly IApplicationDB appDB;
		
		public PmfSpecValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfSpecValidateSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfSpecValidateSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
