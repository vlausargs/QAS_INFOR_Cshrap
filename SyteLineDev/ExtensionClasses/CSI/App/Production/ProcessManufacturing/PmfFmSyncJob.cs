//PROJECT NAME: Production
//CLASS NAME: PmfFmSyncJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmSyncJob
	{
		(int? ReturnCode, string Infobar) PmfFmSyncJobSp(string Infobar,
		                                                 Guid? FmRp = null,
		                                                 Guid? JobRp = null,
		                                                 decimal? Factor = null,
		                                                 Guid? PnRp = null);
	}
	
	public class PmfFmSyncJob : IPmfFmSyncJob
	{
		readonly IApplicationDB appDB;
		
		public PmfFmSyncJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmfFmSyncJobSp(string Infobar,
		                                                        Guid? FmRp = null,
		                                                        Guid? JobRp = null,
		                                                        decimal? Factor = null,
		                                                        Guid? PnRp = null)
		{
			InfobarType _Infobar = Infobar;
			RowPointer _FmRp = FmRp;
			RowPointer _JobRp = JobRp;
			DecimalType _Factor = Factor;
			RowPointer _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmSyncJobSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Factor", _Factor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
