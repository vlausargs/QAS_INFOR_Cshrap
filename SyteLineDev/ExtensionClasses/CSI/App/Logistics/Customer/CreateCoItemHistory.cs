//PROJECT NAME: Logistics
//CLASS NAME: CreateCoItemHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateCoItemHistory : ICreateCoItemHistory
	{
		readonly IApplicationDB appDB;
		
		public CreateCoItemHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateCoItemHistorySp(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCoItemHistorySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
