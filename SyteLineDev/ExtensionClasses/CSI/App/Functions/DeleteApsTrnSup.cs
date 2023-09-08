//PROJECT NAME: Data
//CLASS NAME: DeleteApsTrnSup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteApsTrnSup : IDeleteApsTrnSup
	{
		readonly IApplicationDB appDB;
		
		public DeleteApsTrnSup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteApsTrnSupSp(
			string POrderID)
		{
			ApsOrderType _POrderID = POrderID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteApsTrnSupSp";
				
				appDB.AddCommandParameter(cmd, "POrderID", _POrderID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
