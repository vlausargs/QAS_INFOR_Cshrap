//PROJECT NAME: Production
//CLASS NAME: CreateApsPlanDetailROP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsPlanDetailROP : ICreateApsPlanDetailROP
	{
		readonly IApplicationDB appDB;
		
		public CreateApsPlanDetailROP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsPlanDetailROPSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsPlanDetailROPSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
