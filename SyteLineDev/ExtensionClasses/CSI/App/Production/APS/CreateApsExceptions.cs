//PROJECT NAME: Production
//CLASS NAME: CreateApsExceptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsExceptions : ICreateApsExceptions
	{
		readonly IApplicationDB appDB;
		
		public CreateApsExceptions(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsExceptionsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsExceptionsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
