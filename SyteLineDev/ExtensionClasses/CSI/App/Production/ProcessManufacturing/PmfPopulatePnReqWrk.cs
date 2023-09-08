//PROJECT NAME: Production
//CLASS NAME: PmfPopulatePnReqWrk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPopulatePnReqWrk
	{
		(int? ReturnCode, string InfoBar) PmfPopulatePnReqWrkSp(string InfoBar = null,
		                                                        Guid? PnRp = null,
		                                                        Guid? JobRp = null,
		                                                        int? BackflushBomReq = 0,
		                                                        Guid? SessionId = null,
		                                                        int? PopulateCompleteJobs = 0);
	}
	
	public class PmfPopulatePnReqWrk : IPmfPopulatePnReqWrk
	{
		readonly IApplicationDB appDB;
		
		public PmfPopulatePnReqWrk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPopulatePnReqWrkSp(string InfoBar = null,
		                                                               Guid? PnRp = null,
		                                                               Guid? JobRp = null,
		                                                               int? BackflushBomReq = 0,
		                                                               Guid? SessionId = null,
		                                                               int? PopulateCompleteJobs = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			RowPointerType _JobRp = JobRp;
			IntType _BackflushBomReq = BackflushBomReq;
			GuidType _SessionId = SessionId;
			IntType _PopulateCompleteJobs = PopulateCompleteJobs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPopulatePnReqWrkSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackflushBomReq", _BackflushBomReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PopulateCompleteJobs", _PopulateCompleteJobs, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
