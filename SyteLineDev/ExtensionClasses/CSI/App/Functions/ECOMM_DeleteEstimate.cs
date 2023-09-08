//PROJECT NAME: Data
//CLASS NAME: ECOMM_DeleteEstimate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ECOMM_DeleteEstimate : IECOMM_DeleteEstimate
	{
		readonly IApplicationDB appDB;
		
		public ECOMM_DeleteEstimate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ECOMM_DeleteEstimateSp(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ECOMM_DeleteEstimateSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
