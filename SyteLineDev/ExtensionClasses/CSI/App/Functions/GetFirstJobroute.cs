//PROJECT NAME: Data
//CLASS NAME: GetFirstJobroute.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFirstJobroute : IGetFirstJobroute
	{
		readonly IApplicationDB appDB;
		
		public GetFirstJobroute(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OutCntrlPoint,
			string OutWc,
			int? OutOperNum,
			int? OutNextOper) GetFirstJobrouteSp(
			string InJob,
			int? InSuffix,
			int? OutCntrlPoint,
			string OutWc,
			int? OutOperNum,
			int? OutNextOper)
		{
			JobType _InJob = InJob;
			SuffixType _InSuffix = InSuffix;
			ListYesNoType _OutCntrlPoint = OutCntrlPoint;
			WcType _OutWc = OutWc;
			OperNumType _OutOperNum = OutOperNum;
			OperNumType _OutNextOper = OutNextOper;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFirstJobrouteSp";
				
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCntrlPoint", _OutCntrlPoint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutWc", _OutWc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutOperNum", _OutOperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutNextOper", _OutNextOper, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutCntrlPoint = _OutCntrlPoint;
				OutWc = _OutWc;
				OutOperNum = _OutOperNum;
				OutNextOper = _OutNextOper;
				
				return (Severity, OutCntrlPoint, OutWc, OutOperNum, OutNextOper);
			}
		}
	}
}
