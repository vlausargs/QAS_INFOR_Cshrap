//PROJECT NAME: Production
//CLASS NAME: PmfUserHasPerm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfUserHasPerm : IPmfUserHasPerm
	{
		readonly IApplicationDB appDB;
		
		public PmfUserHasPerm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfUserHasPermSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfUserHasPermSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}

		public int? PmfUserHasPermFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfUserHasPerm]()";

				var Output = appDB.ExecuteNonQuery(cmd);

				return Output;
			}
		}
	}
}
