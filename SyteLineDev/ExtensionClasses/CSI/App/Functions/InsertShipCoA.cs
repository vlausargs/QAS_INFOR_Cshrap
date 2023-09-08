//PROJECT NAME: Data
//CLASS NAME: InsertShipCoA.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InsertShipCoA : IInsertShipCoA
	{
		readonly IApplicationDB appDB;
		
		public InsertShipCoA(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InsertShipCoASp(
			string PShipCoCoNum,
			int? PBatchId)
		{
			CoNumType _PShipCoCoNum = PShipCoCoNum;
			BatchIdType _PBatchId = PBatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertShipCoASp";
				
				appDB.AddCommandParameter(cmd, "PShipCoCoNum", _PShipCoCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
