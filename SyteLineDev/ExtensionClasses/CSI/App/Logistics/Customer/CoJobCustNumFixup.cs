//PROJECT NAME: Logistics
//CLASS NAME: CoJobCustNumFixup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoJobCustNumFixup : ICoJobCustNumFixup
	{
		readonly IApplicationDB appDB;
		
		public CoJobCustNumFixup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoJobCustNumFixupSp(
			string CoNum,
			string CustNum)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoJobCustNumFixupSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
