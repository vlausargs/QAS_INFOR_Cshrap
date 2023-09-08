//PROJECT NAME: Logistics
//CLASS NAME: CreateCoBlnHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateCoBlnHistory : ICreateCoBlnHistory
	{
		readonly IApplicationDB appDB;
		
		public CreateCoBlnHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateCoBlnHistorySp(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCoBlnHistorySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
