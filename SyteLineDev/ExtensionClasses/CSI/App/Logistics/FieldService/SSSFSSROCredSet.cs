//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROCredSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROCredSet : ISSSFSSROCredSet
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROCredSet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSROCredSetSp(
			string SroNum,
			string ArReasonCode)
		{
			FSSRONumType _SroNum = SroNum;
			ReasonCodeType _ArReasonCode = ArReasonCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROCredSetSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArReasonCode", _ArReasonCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
