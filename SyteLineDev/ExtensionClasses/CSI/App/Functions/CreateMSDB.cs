//PROJECT NAME: Data
//CLASS NAME: CreateMSDB.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateMSDB : ICreateMSDB
	{
		readonly IApplicationDB appDB;
		
		public CreateMSDB(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateMSDBSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateMSDBSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
