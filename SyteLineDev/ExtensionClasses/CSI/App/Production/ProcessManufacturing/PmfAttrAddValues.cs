//PROJECT NAME: Production
//CLASS NAME: PmfAttrAddValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfAttrAddValues : IPmfAttrAddValues
	{
		readonly IApplicationDB appDB;
		
		public PmfAttrAddValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfAttrAddValuesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfAttrAddValuesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
