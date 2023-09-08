//PROJECT NAME: Production
//CLASS NAME: ApsBomOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBomOrderId : IApsBomOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsBomOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBomOrderIdSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsBomOrderIdSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
		public int? ApsBomOrderIdFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsBomOrderId]()";

				var Output = appDB.ExecuteNonQuery(cmd);

				return Output;
			}
		}

	}
}
