//PROJECT NAME: Logistics
//CLASS NAME: LockCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class LockCo : ILockCo
	{
		readonly IApplicationDB appDB;
		
		
		public LockCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LockCoSp(string CoNum,
		int? Lock)
		{
			CoNumType _CoNum = CoNum;
			ListYesNoType _Lock = Lock;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LockCoSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lock", _Lock, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
