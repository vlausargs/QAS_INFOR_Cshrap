//PROJECT NAME: Logistics
//CLASS NAME: CreatePoBlnHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreatePoBlnHistory : ICreatePoBlnHistory
	{
		readonly IApplicationDB appDB;
		
		public CreatePoBlnHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreatePoBlnHistorySp(
			string PoNum)
		{
			PoNumType _PoNum = PoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePoBlnHistorySp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
