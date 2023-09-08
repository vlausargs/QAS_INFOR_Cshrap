//PROJECT NAME: Data
//CLASS NAME: Setordch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Setordch : ISetordch
	{
		readonly IApplicationDB appDB;
		
		public Setordch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetordchSp(
			string CoNum,
			string ArReasonCode)
		{
			CoNumType _CoNum = CoNum;
			ReasonCodeType _ArReasonCode = ArReasonCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetordchSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArReasonCode", _ArReasonCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
