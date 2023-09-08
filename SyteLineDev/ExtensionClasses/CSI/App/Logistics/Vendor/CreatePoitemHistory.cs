//PROJECT NAME: Logistics
//CLASS NAME: CreatePoitemHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreatePoitemHistory : ICreatePoitemHistory
	{
		readonly IApplicationDB appDB;
		
		public CreatePoitemHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreatePoitemHistorySp(
			string PoNum)
		{
			PoNumType _PoNum = PoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePoitemHistorySp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
