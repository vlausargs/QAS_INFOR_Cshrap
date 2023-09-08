//PROJECT NAME: Data
//CLASS NAME: DataMaint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DataMaint : IDataMaint
	{
		readonly IApplicationDB appDB;
		
		public DataMaint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DataMaintSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DataMaintSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
