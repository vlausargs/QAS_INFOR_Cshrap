//PROJECT NAME: Production
//CLASS NAME: PmfAttrCastDecimals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfAttrCastDecimals : IPmfAttrCastDecimals
	{
		readonly IApplicationDB appDB;
		
		public PmfAttrCastDecimals(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfAttrCastDecimalsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfAttrCastDecimalsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
