//PROJECT NAME: Production
//CLASS NAME: CreateApsExceptionsXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsExceptionsXref : ICreateApsExceptionsXref
	{
		readonly IApplicationDB appDB;
		
		public CreateApsExceptionsXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsExceptionsXrefSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsExceptionsXrefSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
