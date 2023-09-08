//PROJECT NAME: Production
//CLASS NAME: PmfAttrAddTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfAttrAddTables : IPmfAttrAddTables
	{
		readonly IApplicationDB appDB;
		
		public PmfAttrAddTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfAttrAddTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfAttrAddTablesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
