//PROJECT NAME: Data
//CLASS NAME: LastJobtran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LastJobtran : ILastJobtran
	{
		readonly IApplicationDB appDB;
		
		public LastJobtran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string OutPayRate,
			int? OutStartTime,
			int? OutEndTime,
			int? OutOperNum) LastJobtranSp(
			decimal? InTransNum,
			string OutPayRate,
			int? OutStartTime,
			int? OutEndTime,
			int? OutOperNum)
		{
			HugeTransNumType _InTransNum = InTransNum;
			PayBasisType _OutPayRate = OutPayRate;
			TimeSecondsType _OutStartTime = OutStartTime;
			TimeSecondsType _OutEndTime = OutEndTime;
			OperNumType _OutOperNum = OutOperNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LastJobtranSp";
				
				appDB.AddCommandParameter(cmd, "InTransNum", _InTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutPayRate", _OutPayRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutStartTime", _OutStartTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutEndTime", _OutEndTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutOperNum", _OutOperNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutPayRate = _OutPayRate;
				OutStartTime = _OutStartTime;
				OutEndTime = _OutEndTime;
				OutOperNum = _OutOperNum;
				
				return (Severity, OutPayRate, OutStartTime, OutEndTime, OutOperNum);
			}
		}
	}
}
