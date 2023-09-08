//PROJECT NAME: Logistics
//CLASS NAME: RSQC_CustomerNeedsQC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RSQC_CustomerNeedsQC : IRSQC_CustomerNeedsQC
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CustomerNeedsQC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NeedsQC) RSQC_CustomerNeedsQCSp(decimal? ShipmentID,
		int? NeedsQC)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			IntType _NeedsQC = NeedsQC;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CustomerNeedsQCSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NeedsQC", _NeedsQC, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NeedsQC = _NeedsQC;
				
				return (Severity, NeedsQC);
			}
		}
	}
}
