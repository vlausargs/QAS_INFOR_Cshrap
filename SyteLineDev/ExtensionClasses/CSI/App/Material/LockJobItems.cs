//PROJECT NAME: Material
//CLASS NAME: LockJobItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class LockJobItems : ILockJobItems
	{
		readonly IApplicationDB appDB;
		
		
		public LockJobItems(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LockJobItemsSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? QtyMoved,
		int? Lock = 1)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			QtyUnitType _QtyMoved = QtyMoved;
			ListYesNoType _Lock = Lock;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LockJobItemsSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lock", _Lock, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
